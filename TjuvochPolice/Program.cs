namespace TjuvochPolice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int gridWidth = 100; // stadens bredd
            int gridHeight = 25;

            //Skapa en lista för personer i listan
            List<Person> grid = new List<Person>();

            int numberOfCitizens = 30;
            int numberOfPolice = 10;
            int numberOfThieves = 20;

            //Skapa medborgarna
            for (int i = 0; i < numberOfCitizens; i++)
            {
                // gridWidth och gridHeight skickas vidare till konstruktorn för varje ny medborgare.
                // och används för att placera medborgaren slumpmässigt inom detta område vilket blir mellan (0-100 och 0-25)
                grid.Add(new Citizen(gridWidth, gridHeight));

            }

            //Skapa poliserna
            for (int i = 0 ; i < numberOfPolice; i++)
            {
                grid.Add(new Police(gridWidth, gridHeight));
            }

            //Skapa tjuvar
            for (int i = 0 ;i < numberOfThieves; i++)
            {
                grid.Add(new Thief(gridWidth, gridHeight));
            }

        }
    }
}
