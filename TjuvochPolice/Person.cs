using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvochPolice
{
    internal class Person //Basklassen
    {
        // Properties som är gemensamma för alla 3 personer (tjuv, polis, medborgare)
        public int XPosition { get; set; } // Positionen: var i x- eller y-led personen befinner sig i staden
        public int YPosition { get; set; }
        public int XDirection { get; set; } // Riktningen: hur de ska röra sig som: -1, 0, 1
        public int YDirection { get; set; }
        public string Name { get; set; }

        //En lista med 60 olika namn för att sedan ska personerna slumpmässigt välja en av dem här.
        private static string[] _availableNames =
        {   "Andersson","Johansson","Karlsson","Nilsson","Jansson","Hermansson","Jonsson",
            "Eriksson","Larsson","Olsson","Persson","Svensson","Gustafsson","Pettersson",
            "Hansson","Bengtsson","Jönsson","Lindberg","Sandberg","Berg","Lundgren","Ek",
            "Holm","Sjöberg","Lind","Lundin","Bergström","Jakobsson","Magnusson","Olofsson",
            "Dahlberg","Axelsson","Engström","Hellström","Mårtensson","Nordin","Åberg","Ström",
            "Forsberg","Hedlund","Ekström","Holmberg","Samuelsson","Blomqvist","Håkansson",
            "Öberg","Arvidsson","Nyberg","Wallin","Bergman","Lundberg","Rydberg","Viklund",
            "Holmgren","Bäckström","Nyström","Strömberg","Sandström","Mattsson","Eklund"
        };

        // Konstruktor för basklassen Person för slumpmässiga positioner och riktningar
        public Person(int gridWidth, int gridHeight)
        {
            Name = GetRandomName(); //Ger personerna ett radndom Name
            //Har tänkt att testa om man redan här i basklassen kan ge
            //ett random värde till x, y xD och yD
            XPosition = Random.Shared.Next(gridWidth);
            YPosition = Random.Shared.Next(gridHeight);
            XDirection = Random.Shared.Next(-1, 2);
            YDirection = Random.Shared.Next(-1, 2);

        }
        private static string GetRandomName() //Metod för slumpmässigt namn
        {
            int randomIndex = Random.Shared.Next(_availableNames.Length);
            return _availableNames[randomIndex];
        }

        //Metoden Move() är samma för alla subklasser därför tar vi bara public så att
        //andra subklasser inte skullr behöva skriva över den i onödan då de rör sig likadant
        public void Move(int gridWidth, int gridHeight)
        {
            //Detta för att om personen når gränsen tex. 100 så 
            //ska den nya xpositionen bli 0, (flytta till andra sidan av rutnätet).
            XPosition = (XPosition + XDirection + gridWidth) % gridWidth;
            YPosition = (YPosition + YDirection + gridHeight) % gridHeight;
        }
    }


    class Citizen : Person
    {
        public List<Item> Belongings { get; set; }
        // Här ska det vara något specifict med klassen Citizen
        public Citizen(int gridWidth, int gridHeight)
        : base(gridWidth, gridHeight)

        {
            // Eventuella specifika saker för medborgaren ska läggas till här
            // T.ex. Inventory fylls på med specifika objekt här
            Belongings = new List<Item>
            {
                new Item("pengar"),
                new Item("plånbok"),
                new Item("klocka"),
                new Item("mobil"),
            };
        }

    }
    class Thief : Person
    {
        public List<Item> StolenItems { get; set; }
        public Thief(int gridWidth, int gridHeight)
        : base(gridWidth, gridHeight)
        {
            StolenItems = new List<Item>();
        }

        //Metoden för att Thief ska stjäla från Citizen
        public string Steal(Citizen citizen)
        {
            int randomIndex = Random.Shared.Next(citizen.Belongings.Count); // välj en slumpmässigt föremål från Belongings
            Item stolenItem = citizen.Belongings[randomIndex]; //Hämtar den slumpmässiga Item från Belongings
            citizen.Belongings.RemoveAt(randomIndex); // Ta bort det från medborgarens Belongings
            StolenItems.Add(stolenItem); // Lägg till det i tjuvens Inventory
            return stolenItem.ItemName;
        }
    }


    class Police : Person
    {
        public List<Item> SeizedItems { get; set; }
        public Police(int gridWidth, int gridHeight)
        : base(gridWidth, gridHeight)
        {
            SeizedItems = new List<Item>();
        }
        // Polisen tar allt från tjuven
        public void CatchThief(Thief thief)
        {
            {
                SeizedItems.AddRange(thief.StolenItems);
                thief.StolenItems.Clear(); // Polisen tar alla stulna föremål

            }
        }
    }
}










