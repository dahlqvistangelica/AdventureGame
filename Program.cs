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
