using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvochPolice
{
    internal class Item
    {
        public string ItemName { get; set; } //Här gör vi en klass för item för att sedan
                                             // lägga till i Citizens lista av items 

        public Item(string itemName)
        {
            ItemName = itemName;
        }
    }
}
