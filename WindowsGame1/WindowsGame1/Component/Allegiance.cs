using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheGameOfForever.Component
{
    class AllegianceComponent : BaseComponent
    {
        private int teamId;

        public AllegianceComponent(int teamId)
        {
            this.teamId = teamId;
        }

        public void setTeamId(int id)
        {
            teamId = id;
        }

        public int getTeamId()
        {
            return teamId;
        }
    }
}
