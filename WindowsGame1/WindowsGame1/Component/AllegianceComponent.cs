using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheGameOfForever.Component
{
    class AllegianceComponent : BaseComponent
    {
        private int teamId;
        private int controlId;

        public AllegianceComponent(int teamId)
        {
            this.teamId = teamId;
            this.controlId = teamId;
        }

        public AllegianceComponent(int teamId, int controlId)
        {
            this.teamId = teamId;
            this.controlId = controlId;
        }

        public void setTeamId(int id)
        {
            teamId = id;
        }

        public int getTeamId()
        {
            return teamId;
        }

        public void setControlId(int id)
        {
            controlId = id;
        }

        public int getControlId()
        {
            return controlId;
        }
    }
}
