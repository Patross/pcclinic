using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pcclinic.classes
{
    class Inventory
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public string ItemQuantity{ get; set; }
        public string ItemValue{ get; set; }


        private Inventory()
        {

        }
        public Inventory(string itemName, string itemDescription, string itemQuantity, string itemValue) : this()
        {
            ItemName = itemName;
            ItemDescription = itemDescription;
            ItemQuantity = itemQuantity;
            ItemValue = itemValue;

        }
    }
}
