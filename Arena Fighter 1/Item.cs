using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arena_Fighter_1
{
    public class Item
    {
        protected string itemName;
        protected int itemCost;
        public Item(string name, int cost) {
            SetName(name);
            SetCost(cost);
        }
        protected void SetName(string name) {
            itemName = name;
        }
        protected void SetCost(int cost) {
            itemCost = cost;
        }
    }
}
