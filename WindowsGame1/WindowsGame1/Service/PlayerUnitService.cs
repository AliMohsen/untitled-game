﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGameOfForever.Entities;
using TheGameOfForever.Component;
using Microsoft.Xna.Framework;
using TheGameOfForever.GameState;
using TheGameOfForever.Control;
using Microsoft.Xna.Framework.Graphics;
using TheGameOfForever.Ui.Editor;
using TheGameOfForever.Ui.Font;

namespace TheGameOfForever.Service
{
    /// <summary>
    /// Primarily used in the UnitSelect state. Allows the game state to see all available players.
    /// </summary>
    public class PlayerUnitService : AbstractGameService
    {
        public PlayerUnitService(EntityManager entityManager)
            : base(entityManager)
        {
            subscribeToComponentGroup(typeof(Controllable)); // 0
        }

        public override void update(GameTime gameTime, AbstractGameState gameState)
        {
            IControl control = DefaultControl.Instance;
            UnitSelectState state = ((UnitSelectState)gameState);
            List<int> selectableIds = new List<int>();
            Entity selected = null;

            foreach (int id in entityIds[0])
            {
                Entity entity = entityManager.getEntity(id);
                if (entity.getComponent<AllegianceComponent>()
                    .getControlId() == GameEntity.turnId)
                {
                    selectableIds.Add(id);
                }

                if (entity.hasComponent<Selected>())
                {
                    selected = entity;
                }
            }

            if (selected == null)
            {
                selected = entityManager.getEntity(selectableIds[0]);
                selected.addComponent(new Selected());
            }
            int index = selectableIds.IndexOf(selected.getId());

            //If the player presses next.
            if (control.isLRightPressed())
            {
                index = (index + 1) % selectableIds.Count;
            }

            //If the player presses back.
            if (control.isLLeftPressed())
            {
                if (index == 0) index = selectableIds.Count - 1;
                else index = (index - 1) % selectableIds.Count;
            }

            if (selectableIds[index] != selected.getId())
            {
                // Switch selected entity.
                selected.removeComponent<Selected>();
                selected = entityManager.getEntity(selectableIds[index]);
                selected.addComponent(new Selected());
            }

            //If the player presses action(one).
            if (control.isActionAPressed())
            {
                selected.addComponent(new TrackingComponent());
                int commandCost = selected.getComponent<Controllable>().getCommandCost();
                if (state.getCommandPoints() >= commandCost)
                {
                    state.selectUnit(commandCost);
                }
            }

            if (control.isActionCPressed())
            {
                state.endTurn();
            }
        }

        public override void draw(GameTime gameTime, AbstractGameState gameState, SpriteBatch spriteBatch)
        {
            foreach (int id in entityIds[0])
            {
                Entity entity = entityManager.getEntity(id);
                Vector2 location = entity.getComponent<LocationComponent>().getCurrentLocation();
                if (entity.getComponent<AllegianceComponent>()
                    .getControlId() == GameEntity.turnId)
                {
                    if (entity.hasComponent<Selected>())
                    {
                        spriteBatch.Draw(EditorContent.blank, location, new Rectangle(0,0,1,1), Color.Orange, 
                            (float)Math.PI/2, new Vector2(0.5f), new Vector2(5), SpriteEffects.None,1);
                    }
                    else
                    {
                        spriteBatch.Draw(EditorContent.blank, location, new Rectangle(0, 0, 1, 1), Color.Green,
                            (float)Math.PI / 2, new Vector2(0.5f), new Vector2(5), SpriteEffects.None, 1);
                    }
                }
                else
                {
                    spriteBatch.Draw(EditorContent.blank, location, new Rectangle(0, 0, 1, 1), Color.Red,
                        (float)Math.PI / 2, new Vector2(0.5f), new Vector2(5), SpriteEffects.None, 1);
                }
            }
            DrawStringHelper.drawString(spriteBatch, "Command points remaining: " + ((UnitSelectState)gameState).getCommandPoints(),
                "mentone", 12, Color.Black, new Vector2(5));
        }
    }
}
