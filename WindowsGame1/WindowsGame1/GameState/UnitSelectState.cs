using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGameOfForever.Service;

namespace TheGameOfForever.GameState
{
    public class UnitSelectState : AbstractGameState
    {
        private int controlId;
        private int commandPoints;
        private int selectedId = 0;

        public UnitSelectState(int controlId, GameStateManager gameStateManager) : base(gameStateManager)
        {
            commandPoints = 10;
            this.controlId = controlId;
            gameServices.Add(gameStateManager.getService<PlayerUnitService>());
        }

        public void selectUnit(int commandCost)
        {
            commandPoints -= commandCost;
            // Now we move to the unit move state.
            addStateOnTopOfThis(new MovementState(selectedId, gameStateManager));
        }

        public int getSelectId()
        {
            return selectedId;
        }

        public void setSelectId(int selectId)
        {
            this.selectedId = selectId;
        }

        public int getControlId()
        {
            return controlId;
        }

        public override bool isPropagateUpdate()
        {
            return false;
        }

        public override bool isPropagateDraw()
        {
            return true;
        }
    }
}
