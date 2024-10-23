namespace TjuvochPolice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int gridWidth = 80; // stadens bredd
            int gridHeight = 20;

            //Skapa en lista för personer i listan
            List<Person> grid = new List<Person>();

            int numberOfCitizens = 30;
            int numberOfPolice = 10;
            int numberOfThieves = 20;

            //Skapa medborgarna
            for (int i = 0; i <= numberOfCitizens; i++)
            {
                // gridWidth och gridHeight skickas vidare till konstruktorn för varje ny medborgare.
                // och används för att placera medborgaren slumpmässigt inom detta område vilket blir mellan (0-100 och 0-25)
                grid.Add(new Citizen(gridWidth, gridHeight));

            }

            //Skapa poliserna
            for (int i = 0 ; i <= numberOfPolice; i++)
            {
                grid.Add(new Police(gridWidth, gridHeight));
            }

            //Skapa tjuvar
            for (int i = 0 ;i <= numberOfThieves; i++)
            {
                grid.Add(new Thief(gridWidth, gridHeight));
            }

            while (true)
            {
                Console.Clear();

                //Ritar ut staden
                City.DrawGrid(grid, gridWidth, gridHeight);


                foreach (Person person in grid)
                {
                    // Flytta personen
                    person.Move(gridWidth, gridHeight);

                    // Rita ut personen på den nya positionen
                    Console.SetCursorPosition(person.XPosition, person.YPosition);

                }

                int statusPosition = gridHeight + 2; // Starta ifo under staden
                Console.SetCursorPosition(0, statusPosition); // Flytta markören

                Console.WriteLine($"Antal rånade medborgare: {City.totalRobbedCitizens}\nAntal gripna tjuvar: {City.totalCauthThieves}");

                City.CheckInteractions(grid, gridHeight);
                Thread.Sleep(1000);
            }
        }
    }
}
