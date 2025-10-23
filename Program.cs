namespace AdventureGame
{
    using System;
    using System.Diagnostics;
    using System.Reflection;
    using System.Text;
    using System.Xml;
    enum Klass { Magiker, Krigare, Tjuv, Anka}
    class Program
    {
        static void Main(string[] args)
        {
            TimeSpan maxPlayTime = TimeSpan.Parse("00:03:00");
            Console.WriteLine("Välkommen till Äventyraren!");
            var character = CreateCharacter();

            DateTime startTime = DateTime.Now;
            Stopwatch.StartNew();
            TimeSpan playTime = DateTime.Now - startTime;

            while (character.Health > 0 && playTime < maxPlayTime)
            {
                playTime = DateTime.Now - startTime;
                DisplayStats(character.Name, character.Health, character.Gold, playTime);
                StartAdventure(character.Name, ref character.Health, ref character.Gold);
            }
            if (character.Health <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t\t\t---- GAME OVER ----\n\t\t\tDu har dött.");
            }
            else if (playTime >= maxPlayTime)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\t\t\t---- GAME OVER ----\n\t\t\tTiden är ute, du överlevde!");
            }

            static (string Name, string Klass, int Health, int Gold) CreateCharacter()
            {
                Console.WriteLine("Vad är ditt namn?");
                string? namn = Console.ReadLine();
                int hp = 0;
                int gold = 0;
                Console.WriteLine("välj din klass!");
                Console.WriteLine($"[1] - Magiker \n[2] - Krigare \n[3] - Tjuv");
                string klass = "";
                Int32.TryParse(Console.ReadLine(), out int input);
                switch (input)
                {
                    case 1:
                        klass = Klass.Magiker.ToString().ToLower();
                        gold = 100;
                        hp = 75;
                        break;
                    case 2:
                        klass = Klass.Krigare.ToString().ToLower(); ;
                        hp = 200;
                        gold = 10;
                        break;
                    case 3:
                        klass = Klass.Tjuv.ToString().ToLower();
                        gold = 1500000;
                        hp = 100;
                        break;
                    default:
                        klass = Klass.Anka.ToString().ToLower();
                        hp = 6000;
                        gold = 0;
                        break;
                }
                Console.WriteLine(CharacterStory(namn, klass));
                return (namn, klass, hp, gold);
            }
            static string CharacterStory(string name, string klass)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Du vaknar på en strand...");
                sb.AppendLine($"Du har ett vagt minne av att ditt namn är {name}...");
                sb.AppendLine($"Du känner igen föremålet vid din sida. en perfekt kompanjon för en {klass} som dig!");
                string story = sb.ToString();
                return story;
            }

            static void StartAdventure(string name, ref int health, ref int gold)
            {

                string occurrence = GenerateRandomEvent();
                switch (occurrence)
                {
                    case "Hitta skatt":
                        gold += 25;
                        Console.WriteLine("Du hittar en skatt med 10 guld.");
                        Console.ReadLine();
                        break;
                    case "Möta monster":
                        health -= 50; gold -= 3;
                        if (gold <= 0)
                            gold = 0;
                        Console.WriteLine("Du möter ett monster och förlorar 5 hälsa och tappar 3 guld.");
                        Console.ReadLine();
                        break;
                    case "Vila vid lägereld":
                        health += 5;
                        if (health >= 100)
                            health = 100;
                        Console.WriteLine("Du vilar vid lägerelden och återfår 5 hälsa.");
                        Console.ReadLine();
                        break;
                    case "Hitta läkande vatten":
                        health += 5;
                        if (health >= 100)
                            health = 100;
                        Console.WriteLine("Du hittar en bäck med läkande vatten och återfår 5 hälsa.");
                        Console.ReadLine();
                        break;
                    case "Döda stort monster":
                        gold += 5;
                        if (health >= 100)
                            health = 100;
                        Console.WriteLine("Du möter och dödar ett stort monster utan skador och hittar 5 guld i monstrets mage.");
                        Console.ReadLine();
                        break;
                    case "Rånad":
                        gold = 0; health -= 20;
                        if (health >= 100)
                            health = 100;
                        Console.WriteLine("Du blir nerslagen och rånad på allt ditt guld!");
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Invalid occurence");
                        break;

                }

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

            static void DisplayStats(string name, int health, int gold, TimeSpan timePlayed)
            {
                // Visa spelarens statistik här 
                Console.WriteLine($"Namn: {name} \nHP: {health} \nGuld: {gold}");
                Console.WriteLine($"Tid spelat: {timePlayed.ToString("mm' : 'ss")}");
            }
        }

    }
}
