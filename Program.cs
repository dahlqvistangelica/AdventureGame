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
            // Implementera äventyrslogiken här 
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
