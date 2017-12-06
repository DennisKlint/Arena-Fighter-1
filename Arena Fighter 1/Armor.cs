using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arena_Fighter_1
{
    class Armor : Item
    {
        int itemDefenceBonus;
        int itemHpBonus;
        public Armor(string name, int cost, int defenceBonus, int hpBonus) : base(name, cost)
        {
            SetName(name);
            SetCost(cost);
            SetDefenceBonus(defenceBonus);
            SetHpBonus(hpBonus);
        }
        private void SetDefenceBonus(int defenceBonus)
        {
            itemDefenceBonus = defenceBonus;
        }
        private void SetHpBonus(int hpBonus)
        {
            itemHpBonus = hpBonus;
        }
        public int GetitemDefenceBonus()
        {
            return itemDefenceBonus;
        }
        public int GetItemHpBonus()
        {
            return itemHpBonus;
        }
    }
}
