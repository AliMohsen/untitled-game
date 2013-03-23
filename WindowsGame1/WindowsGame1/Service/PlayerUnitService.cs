using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGameOfForever.Entities;
using TheGameOfForever.Component;
using Microsoft.Xna.Framework;
using TheGameOfForever.GameState;
using TheGameOfForever.Control;

namespace TheGameOfForever.Service
{
    /// <summary>
    /// Primarily used in the UnitSelect state. Allows the game state to see all available players.
    /// </summary>
    public class PlayerUnitService : AbstractGameService
    {
        public PlayerUnitService(EntityManager entityManager) : base(entityManager)
        {
            subscribeToComponentGroup(typeof(Controllable));
        }

        public override void update(GameTime gameTime, AbstractGameState gameState)
        {
            IControl control = DefaultControl.Instance;
            UnitSelectState state = ((UnitSelectState)gameState);
            List<int> selectableIds = new List<int>();
            foreach(int id in entityIds)
            {
                if (entityManager.getEntity(id).getComponent<AllegianceComponent>()
                    .getControlId() == state.getControlId())
                {
                    selectableIds.Add(id);
                }
            }

            //If the player presses next.
            if (control.isLRightPressed())
            {
                state.setSelectId((state.getSelectId() + 1) % selectableIds.Count);
            }

            //If the player presses back.
            if (control.isLLeftPressed())
            {
                state.setSelectId((state.getSelectId() - 1) % selectableIds.Count);
            }

            //If the player presses action(one).
            if (control.isActionAPressed())
            {
                state.selectUnit(entityManager.getEntity(state.getSelectId())
                    .getComponent<Controllable>().getCommandCost());
            }
        }

    }
}
