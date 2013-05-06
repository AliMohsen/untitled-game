using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using TheGameOfForever.Entities;
using TheGameOfForever.Component;
using TheGameOfForever.Processor.Content.Effects;
using Microsoft.Xna.Framework;
using TheGameOfForever.Processor.Content.Model;
using TheGameOfForever.Ui.Editor;

namespace TheGameOfForever.Service
{
    public class MapDraw3DService : AbstractGameService
    {
        public static Matrix viewMatrix = Matrix.CreateLookAt(new Vector3(0, 300, 1.5f), Vector3.Zero, new Vector3(0, 1, 0));
        public static Matrix projectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, 1000f / 600f, 0.1f, 1500.0f);

        public MapDraw3DService(EntityManager entityManager) : base(entityManager)
        {
            subscribeToComponentGroup(typeof(Model3D));
            subscribeToComponentGroup(typeof(Model3D), typeof(LocationComponent));
            subscribeToComponentGroup(typeof(Model3D), typeof(LocationComponent), typeof(Selected), typeof(MovementTime));
        }

        Quaternion cameraRotation = Quaternion.Identity;
        Vector3 cameraPosition;
        Vector3 cameraUpDirection;

        public override void update(Microsoft.Xna.Framework.GameTime gameTime, GameState.AbstractGameState gameState)
        {
            foreach (int id in entityIds[1])
            {
                Entity entity = entityManager.getEntity(id);
                Model3D modelComponent = entity.getComponent<Model3D>();
                LocationComponent locationComponent = entity.getComponent<LocationComponent>();
                modelComponent.setLocation(new Vector3(locationComponent.getCurrentLocation().X, 0, locationComponent.getCurrentLocation().Y));
                modelComponent.setRotation(Quaternion.CreateFromAxisAngle(new Vector3(0,1,0), -locationComponent.getFacingRadians()));
            }
            foreach (int id in entityIds[2])
            {
                Entity selectedEntity = entityManager.getEntity(id);
                Model3D modelComponent = selectedEntity.getComponent<Model3D>();
                LocationComponent locationComponent = selectedEntity.getComponent<LocationComponent>();
                cameraRotation = modelComponent.getRotation();
                Vector3 camPos = new Vector3(0, 30, 50);
                camPos = Vector3.Transform(camPos, Matrix.CreateFromQuaternion(Quaternion.CreateFromAxisAngle(new Vector3(0, 1, 0), -locationComponent.getFacingRadians())));
                camPos += new Vector3(locationComponent.getCurrentLocation().X, 0, locationComponent.getCurrentLocation().Y);
                viewMatrix = Matrix.CreateLookAt(camPos, new Vector3(locationComponent.getCurrentLocation().X, 20, locationComponent.getCurrentLocation().Y)
                    , new Vector3(0, 1, 0));
            }

            if (entityIds[2].count() == 0)
            {
                viewMatrix = Matrix.CreateLookAt(new Vector3(0, 300, 1.5f), Vector3.Zero, new Vector3(0, 1, 0));
            }
        }

        public override void draw3d(Microsoft.Xna.Framework.GameTime gameTime, GameState.AbstractGameState state, GraphicsDevice device)
        {
            device.DepthStencilState = DepthStencilState.Default;
            foreach (int id in entityIds[0])
            {
               Model3D modelComponent = entityManager.getEntity(id).getComponent<Model3D>();
               Effect effect = EffectLibrary.basicEffect;
               effect.CurrentTechnique = effect.Techniques["Textured"];
               effect.Parameters["xWorld"].SetValue(Matrix.CreateScale(modelComponent.getScale() * 10)
                   * Matrix.CreateFromQuaternion(modelComponent.getRotation()) * Matrix.CreateTranslation(modelComponent.getLocation()));
               effect.Parameters["xView"].SetValue(viewMatrix);
               effect.Parameters["xProjection"].SetValue(projectionMatrix);
               effect.Parameters["xEnableLighting"].SetValue(true);
               Vector3 light = new Vector3(2, -20, 0);
               light.Normalize();
               effect.Parameters["xLightDirection"].SetValue(light);
               effect.Parameters["xAmbient"].SetValue(0.4f);
               effect.Parameters["xTexture"].SetValue(EditorContent.face);
               foreach (EffectPass pass in effect.CurrentTechnique.Passes)
               {
                   pass.Apply();
                   VertexPositionNormalTexture[] vertices = ModelLibrary.getModelFromId(modelComponent.getModelIndex()).getVertices();
                   device.DrawUserPrimitives(PrimitiveType.TriangleList, vertices
                       , 0, vertices.Length / 3, VertexPositionNormalTexture.VertexDeclaration);
               }
            }
        }
    }
}
