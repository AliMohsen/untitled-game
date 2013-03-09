using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheGameOfForever.Configuration.Character
{
    interface ICharacterStats
    {
        int getHealth();
        float getMovementSpeed();
        int getAccuracy();
        int getMovementTimeMs();
        int getDefense();
        int getArmour();
        int getLuck();
        int getEvasion();
    }
}
