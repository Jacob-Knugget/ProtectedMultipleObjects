using System;

namespace Inheritance
{
    //Base Class
    class PlayerCharacter
    {
        protected int _level;
        protected int _hp;
        protected int _ac;

        public PlayerCharacter()
        {
            _level = 0;
            _hp = 0;
            _ac = 0;
        }

        public PlayerCharacter(int level, int hp, int ac)
        {
            _level = level;
            _hp = hp;
            _ac = ac;
        }

        public virtual void addChange()
        {
            Console.Write("Level: ");
            _level = int.Parse(Console.ReadLine());
            Console.Write("Hitpoints: ");
            _hp = int.Parse(Console.ReadLine());
            Console.Write("Armor Class: ");
            _ac = int.Parse(Console.ReadLine());
        }

        public virtual void display()
        {
            Console.WriteLine("Player Information: ");
            Console.WriteLine($"Level: {_level}");
            Console.WriteLine($"Hit Points: {_hp}");
            Console.WriteLine($"Armor Class: {_ac}");
        }
    }

    class Barbarian : PlayerCharacter
    {
        protected int _rage;
        protected string _weapon;

        public Barbarian()
        {
            _rage = 0;
            _weapon = "";
        }

        public Barbarian(int level, int hp, int ac, int rage, string weapon)
        {
            _level = level;
            _hp = hp;
            _ac = ac;
            _rage = rage;
            _weapon = weapon;
        }

        public override void addChange()
        {
            base.addChange();
            Console.Write("Number of Rages: ");
            _rage = int.Parse(Console.ReadLine());
            Console.Write("Weapon of Choice: ");
            _weapon = Console.ReadLine();
        }

        public override void display()
        {
            base.addChange();
            Console.WriteLine($"Number of Rages: {_rage}");
            Console.WriteLine($"Weapon of Choice: {_weapon}");
        }

        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("How many players do you want to enter?");
                int maxPlayers;
                while (!int.TryParse(Console.ReadLine(), out maxPlayers))
                    Console.WriteLine("Please enter a whole number");
                PlayerCharacter[] players = new PlayerCharacter[maxPlayers];
                Console.WriteLine("How many barbarians do you want to enter?");
                int maxBarb;
                while (!int.TryParse(Console.ReadLine(), out maxBarb))
                    Console.WriteLine("Please enter a whole number");
                Barbarian[] barb = new Barbarian[maxBarb];

                int choice, rec, type;
                int playerCounter = 0, barbCounter = 0;
                choice = Menu();
                while (choice != 4)
                {
                    Console.WriteLine("Please enter 1 for Barbarian or 2 for Player Character");
                    while (!int.TryParse(Console.ReadLine(), out type))
                        Console.WriteLine("1 for Barbarian or 2 for Player Character");
                    try
                    {
                        switch (choice)
                        {
                            case 1:
                                if (type == 1)
                                {
                                    if (barbCounter <= maxPlayers)
                                    {
                                        barb[barbCounter] = new Barbarian();
                                        barb[barbCounter].addChange();
                                        barbCounter++;
                                    }
                                    else
                                        Console.WriteLine("The maximum number of Barbarians have been added");

                                }
                                else
                                {
                                    if (playerCounter <= maxPlayers)
                                    {
                                        players[playerCounter] = new PlayerCharacter();
                                        players[playerCounter].addChange();
                                        playerCounter++;
                                    }
                                    else
                                        Console.WriteLine("The maximum number of Player Characters have been added");
                                }

                                break;
                            case 2:
                                Console.Write("Enter the record number you want to change: ");
                                while (!int.TryParse(Console.ReadLine(), out rec))
                                    Console.Write("Enter the record number you want to change: ");
                                rec--;
                                if (type == 1)
                                {
                                    while (rec > barbCounter - 1 || rec < 0)
                                    {
                                        Console.Write("The number you entered was out of range, try again");
                                        while (!int.TryParse(Console.ReadLine(), out rec))
                                            Console.Write("Enter the record number you want to change: ");
                                        rec--;
                                    }
                                    barb[rec].addChange();
                                }
                                else
                                {
                                    while (rec > playerCounter - 1 || rec < 0)
                                    {
                                        Console.Write("The number you entered was out of range, try again");
                                        while (!int.TryParse(Console.ReadLine(), out rec))
                                            Console.Write("Enter the record number you want to change: ");
                                        rec--;
                                    }
                                    players[rec].addChange();
                                }
                                break;
                            case 3:
                                if (type == 1)
                                {
                                    for (int i = 0; i < playerCounter; i++)
                                        players[i].display();
                                }
                                else
                                {
                                    for (int i = 0; i < playerCounter; i++)
                                        players[i].display();
                                }
                                break;
                            default:
                                Console.WriteLine("You made an invalid selection, please try again");
                                break;
                        }
                    }


                    catch (IndexOutOfRangeException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    choice = Menu();
                }


            }
            private static int Menu()
            {
                Console.WriteLine("Please make a selection from the menu");
                Console.WriteLine("1-Add  2-Change  3-Print  4-Quit");
                int selection = 0;
                while (selection < 1 || selection > 4)
                    while (!int.TryParse(Console.ReadLine(), out selection))
                        Console.WriteLine("1-Add  2-Change  3-Print  4-Quit");
                return selection;
            }
        }
    }
}