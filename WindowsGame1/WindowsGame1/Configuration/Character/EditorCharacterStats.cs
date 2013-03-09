using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheGameOfForever.Configuration.Character
{
    /// <summary>
    /// Character to be used in editor, contains setter methods as opposed to being immutable.
    /// </summary>
    class EditorCharacterStats : ICharacterStats
    {
        private int health;
        private float movementSpeed;
        private int accuracy;
        private int movementTime;
        private int defense;
        private int armour;
        private int luck;
        private int evasion;

        #region Setters
        public int Health
        {
            set
            {
                health = value;
            }
        }

        public int Accuracy
        {
            set
            {
                accuracy = value;
            }
        }

        public float MovementSpeed
        {
            set
            {
                movementSpeed = value;
            }
        }

        public int MovementTime
        {
            set
            {
                movementTime = value;
            }
        }

        public int Defense
        {
            set
            {
                defense = value;
            }
        }

        public int Armour
        {
            set
            {
                armour = value;
            }
        }

        public int Luck
        {
            set
            {
                luck = value;
            }
        }

        public int Evasion
        {
            set
            {
                evasion = value;
            }
        }
        #endregion

        #region getters
        int ICharacterStats.getHealth()
        {
            return health;
        }

        float ICharacterStats.getMovementSpeed()
        {
            return movementSpeed;
        }

        int ICharacterStats.getAccuracy()
        {
            return accuracy;
        }

        int ICharacterStats.getMovementTimeMs()
        {
            return movementTime;
        }

        int ICharacterStats.getDefense()
        {
            return defense;
        }

        int ICharacterStats.getArmour()
        {
            return armour;
        }

        int ICharacterStats.getLuck()
        {
            return luck;
        }

        int ICharacterStats.getEvasion()
        {
            return evasion;
        }
        #endregion
    }
}
