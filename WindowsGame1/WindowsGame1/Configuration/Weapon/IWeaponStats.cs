using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheGameOfForever.Configuration.Weapon
{
    public interface IWeaponStats
    {
        float getAccuracy();
        int getShotsPerTurn();
        int getPower();
        float getRange();
        int getWeight();
        float getCritical();
        long getTimeBetweenShots();
    }
}
