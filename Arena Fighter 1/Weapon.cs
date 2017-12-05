using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arena_Fighter_1
{
    class Weapon : Item
    {
        private int itemToHitBonus;
        private int itemDamageBonus;
        private string itemDamageDice;
        public Weapon(string name, int cost, int toHitBonus, int damageBonus, string damageDice) : base(name, cost)
        {
            SetName(name);
            SetCost(cost);
            SetToHitBonus(toHitBonus);
            SetDamageBonus(damageBonus);
            SetDamageDice(damageDice);
        }
        private void SetToHitBonus(int toHitBonus)
        {
            itemToHitBonus = toHitBonus;
        }
        private void SetDamageBonus(int damageBonus)
        {
            itemDamageBonus = damageBonus;
        }
        private void SetDamageDice(string damageDice)
        {
            itemDamageDice = damageDice;
        }

        //The following methods allow other classes to 'get' values of the item
        public string GetName()
        {
            return itemName;
        }
        public int GetCost()
        {
            return itemCost;
        }
        public int GetToHitBonus()
        {
            return itemToHitBonus;
        }
        public int GetDamageBonus()
        {
            return itemDamageBonus;
        }
        public string GetDamageDice()
        {
            return itemDamageDice;
        }
    }
}
