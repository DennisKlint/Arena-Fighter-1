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
        public Weapon(string name, int cost, int toHitBonus, int damageBonus, int damageDiceSize, int damageDiceNumber) : base(name, cost)
        {
            SetName(name);
            SetCost(cost);
            SetToHitBonus(toHitBonus);
            SetDamageDiceNumber(damageDiceNumber);
            SetDamageDice(damageDiceSize);
            SetDamageBonus(damageBonus);
        }
        private void SetToHitBonus(int toHitBonus)
        {
            itemToHitBonus = toHitBonus;
        }
        private void SetDamageDiceNumber(int damageDiceNumber)
        {
            itemDamageDiceNumber = damageDiceNumber;
        }
        private void SetDamageDice(int damageDice)
        {
            itemDamageDiceSize = damageDice;
        }
        private void SetDamageBonus(int damageBonus)
        {
            itemDamageBonus = damageBonus;
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
