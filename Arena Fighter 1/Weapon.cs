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
        private int itemDamageDiceSize;
        private int itemDamageDiceNumber;
        public Weapon(string name, int cost, int toHitBonus, int damageBonus, int damageDice, int damageDiceNumber) : base(name, cost)
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
        private void SetDamageDice(int damageDice)
        {
            itemDamageDiceSize = damageDice;
        }

        //The following methods allow other classes to 'get' values of the item
        public int GetToHitBonus()
        {
            return itemToHitBonus;
        }
        public int GetDamageBonus()
        {
            return itemDamageBonus;
        }
        public int GetDamageDice()
        {
            return itemDamageDiceSize;
        }
        public int GetDamageDiceNumber()
        {
            return itemDamageDiceNumber;
        }
    }
}
