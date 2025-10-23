namespace AdventureGame
{
    using System;
    using System.Text;

    class Program
    {
        static void Main(string[] args)
        {
            TimeSpan maxPlayTime = TimeSpan.Parse("00:15:00");
            Console.WriteLine("Välkommen till Äventyraren!");
            var character = CreateCharacter();
            Console.WriteLine($"Hej {character.Name}. Din hälsa är nu {character.Health} och du har {character.Gold} guld.");

            DateTime startTime = DateTime.Now;
            TimeSpan playTime = DateTime.Now - startTime;
            StartAdventure(character.Name, ref character.Health, ref character.Gold);
            if (character.Health <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t\t\t---- GAME OVER ----\n\t\t\tDu har dött.");
            }
            else if (playTime >= maxPlayTime)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\t\t\t---- GAME OVER ----\n\t\t\tTiden är ute.");
            }

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
                        Console.WriteLine("Du hittar en skatt med 10guld.");
                        Console.ReadLine();
                        break;
                    case "Möta mönster": health -= 5; gold -= 3;
                        Console.WriteLine("Du möter ett monster och förlorar 5 hälsa och tappar 3 guld.");
                        Console.ReadLine();
                        break;
                    case "Vila vid lägereld": health += 5;
                        Console.WriteLine("Du vilar vid lägerelden och återfår 5 hälsa.");
                        Console.ReadLine();
                        break;
                    case "Hitta läkande vatten": health += 5;
                        Console.WriteLine("Du hittar en bäck med läkande vatten och återfår 5 hälsa.");
                        Console.ReadLine();
                        break;
                    case "Döda stort monster": gold += 5;
                        Console.WriteLine("Du möter och dödar ett stort monster utan skador och hittar 5 guld i monstrets mage.");
                        Console.ReadLine();
                        break;
                    case "Rånad": gold = 0;
                        Console.WriteLine("Du blir rånad på allt ditt guld!");
                        Console.ReadLine();
                        break;
                    default: Console.WriteLine("Invalid occurence");
                        break;

                }
            } while (health > 0);
        }

        static string GenerateRandomEvent()
        {
            var rnd = new Random();
            // Implementera slumpmässiga händelser här 
            int randomEvent = rnd.Next(1, 7);

            switch (randomEvent)
            {
                case 1:
                    return "Hitta skatt";
                case 2:
                    return "Möta monster";
                case 3:
                    return "Vila vid lägereld";
                case 4:
                    return "Hitta läkande vatten";
                case 5:
                    return "Döda stort monster";
                case 6:
                    return "Rånad";
            }
            return "INGET HÄNDE ERROR";
        }

        static void DisplayStats(string name, int health, int gold)
        {
            // Visa spelarens statistik här 
        }
    }

}
