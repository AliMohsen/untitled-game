using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGameOfForever.Service;

namespace TheGameOfForever.GameState
{
    public class MovementState : AbstractGameState
    {

        public MovementState(GameStateManager gameStateManager) : base(gameStateManager)
        {
            gameServices.Add(gameStateManager.getService<MovementControlService>());
        }

        public override bool isPropagateUpdate()
        {
            // Do not allow other states to run underneath this one.
            return false;
        }

        public override bool isPropagateDraw()
        {
            // Do not allow other states to draw underneath this one.
            return false;
        }
    }
}
