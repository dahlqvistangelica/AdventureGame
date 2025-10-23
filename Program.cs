namespace AdventureGame
{
    using System;
    using System.Text;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Välkommen till Äventyraren!");
            // Huvudlogiken för spelet kommer här 
        }

        static (string Name, int Health, int Gold) CreateCharacter()
        {
            // Implementera karaktärsskapande här 
            return ("", 0, 0);
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
            Console.WriteLine($"Tid spelat: {timePlayed}");
        }
    }

}
