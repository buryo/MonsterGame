using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MonstersEveryWhere
{
    class Program
    {
        public static Monster OwnedMonster { get; set; }
        public static Monster EnemyMonster { get; set; }

        static void Main(string[] args)
        {
            Battle();
            Console.Read();
        }

        public enum MonsterType
        {
            Horse, Orc, Crocodile, MikeTyson, Camel, Kangaroo, MantisShrimp
        }

        public static Monster CreateMonster(MonsterType monsterType)
        {
            Monster monster;

            switch (monsterType)
            {
                case MonsterType.Horse:
                    monster = new Monster(85);
                    monster.AddAttackType(Monster.AttackType.Biting, 6);
                    monster.AddAttackType(Monster.AttackType.Kicking, 6);
                    break;
                case MonsterType.Orc:
                    monster = new Monster(185);
                    monster.AddAttackType(Monster.AttackType.Biting, 8);
                    monster.AddAttackType(Monster.AttackType.Kicking, 10);
                    monster.AddAttackType(Monster.AttackType.Punching, 10);
                    break;
                case MonsterType.Crocodile:
                    monster = new Monster(145);
                    monster.AddAttackType(Monster.AttackType.Biting, 10);
                    monster.AddAttackType(Monster.AttackType.Tackling, 16);
                    monster.AddAttackType(Monster.AttackType.Spitting, 6);
                    break;
                case MonsterType.MikeTyson:
                    monster = new Monster(125);
                    monster.AddAttackType(Monster.AttackType.Biting, 10);
                    monster.AddAttackType(Monster.AttackType.Kicking, 28);
                    monster.AddAttackType(Monster.AttackType.Tackling, 12);
                    break;
                case MonsterType.Camel:
                    monster = new Monster(140);
                    monster.AddAttackType(Monster.AttackType.Biting, 15);
                    monster.AddAttackType(Monster.AttackType.Tackling, 23);
                    monster.AddAttackType(Monster.AttackType.Spitting, 12);
                    break;
                case MonsterType.Kangaroo:
                    monster = new Monster(122);
                    monster.AddAttackType(Monster.AttackType.Kicking, 25);
                    monster.AddAttackType(Monster.AttackType.Tackling, 4);
                    break;
                case MonsterType.MantisShrimp:
                    monster = new Monster(65);
                    monster.AddAttackType(Monster.AttackType.Biting, 13);
                    monster.AddAttackType(Monster.AttackType.Tackling, 15);
                    monster.AddAttackType(Monster.AttackType.Spitting, 6);
                    break;
                default:
                    throw new ArgumentException();
            }

            return monster;
        }

        public static void Battle()
        {
            Console.WriteLine("Let the battle start!");
            Console.WriteLine("Choose your monster");
            Console.WriteLine("---------------------");

            foreach (var monster in Enum.GetValues(typeof(MonsterType)))
            {
                Console.WriteLine(monster);
                Console.WriteLine("*******");
            }

            var MonsterChosen = Console.ReadLine();

            if (Enum.TryParse(MonsterChosen, true, out MonsterType monsterType))
            { 
                if (!Enum.IsDefined(typeof(MonsterType), monsterType))
                {
                    throw new InvalidOperationException();
                }
            }

            Console.Clear();
            Console.WriteLine("You have chosen: " + MonsterChosen);
            Console.WriteLine("************");
            Console.WriteLine("Choose your enemy now:");
            Console.WriteLine("*******");
            foreach (var monster in Enum.GetValues(typeof(MonsterType)))
            {
                Console.WriteLine(monster);
                Console.WriteLine("*******");
            }

            var EnemyChosen = Console.ReadLine();

            if (Enum.TryParse(EnemyChosen, true, out monsterType))
            {
                if (!Enum.IsDefined(typeof(MonsterType), monsterType))
                {
                    throw new InvalidOperationException();
                }
            }

            Fight(MonsterChosen, EnemyChosen);
        }

        public static void Fight(string ChosenMonster, string ChosenEnemy)
        {
            Console.Clear();
            Console.WriteLine(ChosenMonster + " Versus " + ChosenEnemy);
            Console.WriteLine("********** Who is going to win!? **********");
            Thread.Sleep(3000);

            if (Enum.TryParse(ChosenMonster, true, out MonsterType ownedMonster))
                OwnedMonster = CreateMonster(ownedMonster);

            if (Enum.TryParse(ChosenEnemy, true, out MonsterType enemyMonster))
                EnemyMonster = CreateMonster(enemyMonster);

            if (OwnedMonster.Hitpoints - EnemyMonster.Hitpoints > 0)
            {
                Console.WriteLine(OwnedMonster.Hitpoints - EnemyMonster.Hitpoints + " Hitpoints left");
                Console.WriteLine("You have won this battle..");
            }
            else
            {
                Console.WriteLine(OwnedMonster.Hitpoints - EnemyMonster.Hitpoints + " Hitpoints left");
                Console.WriteLine("You have lost this battle.. =(");
            }
            
            Console.Read();
        }
    }
}
