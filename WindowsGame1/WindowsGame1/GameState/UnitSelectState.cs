using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGameOfForever.Service;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace TheGameOfForever.GameState
{
    public class UnitSelectState : AbstractGameState, TrackingCameraService.TrackingCameraObserver
    {
        private int controlId;
        private int commandPoints;
        private int selectedId = 0;

        public UnitSelectState(int controlId, GameStateManager gameStateManager) : base(gameStateManager)
        {
            commandPoints = 10;
            this.controlId = controlId;
            gameServices.Add(gameStateManager.getService<UnitDrawService>());
            gameServices.Add(gameStateManager.getService<PlayerUnitService>());
            gameServices.Add(gameStateManager.getService<TrackingCameraService>());
        }

        public void selectUnit(int commandCost)
        {
            commandPoints -= commandCost;
            // Now we move to the unit move state.
            addStateOnTopOfThis(new MovementState(selectedId, gameStateManager));
        }

        public void endTurn()
        {
            int nextId = ++controlId;
            if(controlId == GlobalStateInfo.getTotalPlayers())
            {
                nextId = 0;
            }
            gameStateManager.swapState(this, new UnitSelectState(nextId, gameStateManager));
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

        public int getCommandPoints()
        {
            return commandPoints;
        }

        public override bool isPropagateUpdate()
        {
            return false;
        }

        public override bool isPropagateDraw()
        {
            return true;
        }

        public Vector2 getLocationToTrack()
        {
            return Vector2.Zero;
        }

        public float getRotationToTrack()
        {
            return 0;
        }
    }
}
