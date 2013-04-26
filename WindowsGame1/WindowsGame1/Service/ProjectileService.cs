using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGameOfForever.Entities;
using TheGameOfForever.Component;
using Microsoft.Xna.Framework;
using TheGameOfForever.GameState;
using TheGameOfForever.Draw;
using TheGameOfForever.Geometry;
using TheGameOfForever.Ui.Editor;
using Microsoft.Xna.Framework.Graphics;

namespace TheGameOfForever.Service
{
    public class ProjectileService : AbstractGameService
    {
        public ProjectileService(EntityManager entityManager) : base(entityManager)
        {
            subscribeToComponentGroup(typeof(IsProjectile)); // 0
        }

        public override void update(GameTime gameTime, AbstractGameState gameState)
        {
            foreach (int e in entityIds[0])
            {
                Entity entity = entityManager.getEntity(e);
                LocationComponent loc = entity.getComponent<LocationComponent>();
                Vector2 distance = gameTime.ElapsedGameTime.Milliseconds * entity.getComponent<MovementComponent>().getVelocity() * 0.1f;
                loc.setCurrentLocation(loc.getCurrentLocation() 
                    + distance);
            }
        }

        public override void draw(GameTime gameTime, AbstractGameState gameState, Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            foreach (int id in entityIds[0])
            {
                Entity entity = entityManager.getEntity(id);
                MovementComponent movement = entity.getComponent<MovementComponent>();
                SpriteBatchWrapper.DrawGame(EditorContent.yellowBullet,
                    entity.getComponent<LocationComponent>().getCurrentLocation(), new Rectangle(0, 0, 10, 10), Color.HotPink,
                    GeometryHelper.CalculateAngle(Vector2.Zero, movement.getVelocity()), new Vector2(5f),
                    new Vector2(1), SpriteEffects.None, 1);
            }
        }
    }
}
