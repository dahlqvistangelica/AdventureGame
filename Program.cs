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
            // Implementera slumpmässiga händelser här 
            return "";
        }

        static void DisplayStats(string name, int health, int gold)
        {
            // Visa spelarens statistik här 
        }
    }

}
