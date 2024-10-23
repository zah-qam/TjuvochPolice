using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvochPolice
{
    internal class City
    {
         

        public static List<string> InteractionInfo = new List<string>(); //Skapar en lista för information om möten
        public static int totalRobbedCitizens = 0;
        public static int totalCauthThieves= 0;
        public static void CheckInteractions(List<Person> persons, int cityHeight)
        {
            // Loopa genom alla personer för att hitta tjuvar och medborgare som är på samma plats
            foreach (Person person in persons)
            {
                foreach (Person otherPerson in persons) // skapar en till variabel otherPerson för att jämföra med person, för att inte ska jämföra med själva person
                {
                    //att det inte är samma person som jämförs med sig själv under de två loopen
                    if (person != otherPerson && person.XPosition == otherPerson.XPosition && person.YPosition == otherPerson.YPosition)
                    {
                        if (person is Thief thief && otherPerson is Citizen citizen)
                        {

                            if (citizen.Belongings.Count > 0)
                            {
                                string stolenItemName = thief.Steal(citizen); // Tjuven stjäl från medborgaren
                                InteractionInfo.Add($"Tjuven {thief.Name} stal {stolenItemName} från medborgaren {citizen.Name}!");
                                totalRobbedCitizens++;
                            }

                            else
                            {
                                InteractionInfo.Add($"Tjuven {thief.Name} och medborgaren {citizen.Name} går bara förbi varann! ");

                            }


                        }


                        else if (person is Police police && otherPerson is Thief thiefCaught)
                        {
                            if (thiefCaught.StolenItems.Count > 0)
                            {

                                police.CatchThief(thiefCaught); // Polisen tar tjuven och (thiefCaught) menas den tjuver som polisen anhåller
                                InteractionInfo.Add($"Polisen {police.Name} fångade {thiefCaught.Name} och tog allt som denne hade rånat!");
                                totalCauthThieves++;
                            }

                            else
                            {
                                InteractionInfo.Add($"Policen {police.Name} och tjuven {thiefCaught.Name} går bara förbi varann! ");

                            }

                        }

                        Thread.Sleep(1000);
                        InteractionInfo.Clear();
                       }
                }
            }

        }

        


        // en metod för en visuell representation av staden och de personer som befinner sig där.
        public static void DrawGrid(List<Person> persons, int cityWidth, int cityHeight)
        {  // Rita ut en tom stad
            for (int y = 0; y <= cityHeight; y++)
            {
                for (int x = 0; x <= cityWidth; x++)
                    Console.Write(""); // Tom plats
            }
            Console.WriteLine(); // Ny rad efter varje rad i griden



            foreach (Person person in persons)
            {
                Console.SetCursorPosition(person.XPosition, person.YPosition);

                //Använder en switch för att bestämma vilken symbol som ska skrivas ut
                switch (person)
                {
                    case Police:
                        Console.Write('P'); // Polis = 'P'
                        break;
                    case Thief:
                        Console.Write('T'); // Tjuv = 'T'
                        break;
                    case Citizen:
                        Console.Write('M'); // Medborgare = 'M'
                        break;


                }

            }

        }



    }


}
