namespace AdventureGame
{
    using System;
    using System.Text;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Välkommen till Äventyraren!");
            CreateCharacter();
            // Huvudlogiken för spelet kommer här 
        }

        static (string Name, int Health, int Gold) CreateCharacter()
        {
            Console.WriteLine("Vad är ditt namn?");
            string namn = Console.ReadLine();
            Console.WriteLine("välj din klass!");
            Console.WriteLine($"[1] - Magiker \n [2] - Krigare \n [3] - Tjuv");
            string klass = "";
            Int32.TryParse(Console.ReadLine(), out int input);
            switch (input)
            {
                case 1:
                    klass = "Magiker";
                    break;
                case 2:
                    klass = "Krigare";
                    break;
                case 3:
                    klass = "Tjuv";
                    break;
                default:
                    klass = "Anka";
                    break;
            }
            int hp = 100;
            int gold = 0;
            return (namn, hp, gold);
        }

        static void StartAdventure(string name, ref int health, ref int gold)
        {
            do
            {
                string occurrence = GenerateRandomEvent();
                switch(occurrence)
                {
                    case "Hitta skatt": gold += 10;
                        break;
                    case "Möta mönster": health -= 5; gold -= 3;
                        break;
                    case "Vila vid lägereld": health += 5;
                        break;
                    case "Hitta läkande vatten": health += 5;
                        break;
                    case "Döda stort monster": gold += 5;
                        break;
                    case "Rånad": gold = 0;
                        break;
                    default: Console.WriteLine("Invalid occurence");
                        break;

                }
            } while (health > 0);
        }

        static string GenerateRandomEvent()
        {
            // Implementera slumpmässiga händelser här 
            return "";
        }

        static void DisplayStats(string name, int health, int gold)
        {
            // Visa spelarens statistik här 
        }
    }

}
