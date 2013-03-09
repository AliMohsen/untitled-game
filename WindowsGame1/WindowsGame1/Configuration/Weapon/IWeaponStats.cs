using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheGameOfForever.Configuration.Weapon
{
    interface IWeaponStats
    {
        int getAccuracy();
        int getShotsPerTurn();
        int getPower();
        float getRange();
        int getWeight();
        float getCrit();
    }
}
