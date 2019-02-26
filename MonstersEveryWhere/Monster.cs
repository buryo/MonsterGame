using System;
using System.Collections.Generic;

namespace MonstersEveryWhere
{
    public class Monster
    {
        public enum AttackType
        {
            Biting, Kicking, Punching, Spitting, Tackling
        }

        public int Hitpoints { get; set; }
        public Dictionary<AttackType, int> AttackTypes { get; set; } = new Dictionary<AttackType, int>();

        public bool CanBite => AttackTypes.ContainsKey(AttackType.Biting);
        public bool CanKick => AttackTypes.ContainsKey(AttackType.Kicking);
        public bool CanPunch => AttackTypes.ContainsKey(AttackType.Punching);
        public bool CanSpit => AttackTypes.ContainsKey(AttackType.Spitting);
        public bool CanTackle => AttackTypes.ContainsKey(AttackType.Tackling);

        public int BiteDamage
        {
            get
            {
                if (CanBite)
                {
                    return AttackTypes[AttackType.Biting];
                }
                throw new InvalidOperationException("This monster cannot bite.");
            }
        }

        public int KickDamage
        {
            get
            {
                if (CanKick)
                {
                    return AttackTypes[AttackType.Kicking];
                }
                throw new InvalidOperationException("This monster cannot kick.");
            }
        }

        public int PunchDamage
        {
            get
            {
                if (CanPunch)
                {
                    return AttackTypes[AttackType.Punching];
                }
                throw new InvalidOperationException("This monster cannot punch.");
            }
        }

        public int SpitDamage
        {
            get
            {
                if (CanPunch)
                {
                    return AttackTypes[AttackType.Spitting];
                }
                throw new InvalidOperationException("This monster cannot spit.");
            }
        }

        public int TackleDamage
        {
            get
            {
                if (CanTackle)
                {
                    return AttackTypes[AttackType.Tackling];
                }
                throw new InvalidOperationException("This monster cannot tackle.");
            }
        }

        public Monster(int hitpoints)
        {
            Hitpoints = hitpoints;
        }

        public void AddAttackType(AttackType attackType, int amountOfDamage)
        {
            AttackTypes[attackType] = amountOfDamage;
        }

    }
}
