using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arena_Fighter_1
{
    class Store
    {
        List<Weapon> weapons = new List<Weapon>();
        List<Armor> armors = new List<Armor>();
        List<Ring> rings = new List<Ring>();

        public Store()
        {
            AddWeapons();
            AddArmors();
        }
        private void AddWeapons()
        {
            // Valuesare as follows: name, cost, toHitBonus, damageBonus, damageDice
            weapons.Add(new Weapon("Wood Sword  ",01,01,01,"1d6"));
            weapons.Add(new Weapon("Copper Sword",02,02,02,"1d8"));
            weapons.Add(new Weapon("Iron Sword  ",04,03,03,"1d12"));
            weapons.Add(new Weapon("Silver Sword",08,04,04,"2d6"));
            weapons.Add(new Weapon("Gold Sword  ",15,05,05,"3d6"));
        }
        private void AddArmors()
        {
            // Values as follows: name, cost, defenceBonus, hpBonus
            armors.Add(new Armor("Birthday Suit", 00, 00, 00));
            armors.Add(new Armor("Copper Armor ", 02, 01, 02));
            armors.Add(new Armor("Iron Armor   ", 08, 02, 04));
            armors.Add(new Armor("Silver Armor ", 20, 03, 06));
            armors.Add(new Armor("Gold Armor   ", 60, 04, 10));
        }
        public void CheckStore()
        {
            bool checkStore = true;
            while (checkStore == true)
            {
                Console.WriteLine("Welcome to the store!");
                Console.Write("What are you interested in, weapons, armors, or rings? type Exit to leave");
                string choise = Console.ReadLine();

                if (choise == "weapons" || choise == "Weapons")
                {
                    ShowWeapons();
                }
                if (choise == "armors" || choise == "Armors")
                {
                    ShowArmors();
                }
                if (choise == "rings" || choise == "Rings")
                {
                    ShowRings();
                }
                if (choise == "exit" || choise == "Exit")
                {
                    return;
                }
                else {
                    Console.WriteLine("I don't understand, can you repeat that?");
                }
            }
        }
        private void ShowWeapons()
        {
            Console.WriteLine("The better the weapon, the more damage you'll do, and your chances to hit increase!");
            for (int i = 0; weapons.Capacity < i; i++)
            {
                Console.WriteLine("| " +weapons[i].GetName() + " | " + 
                    weapons[i].GetCost() + " | " + 
                    weapons[i].GetToHitBonus() + " | " + 
                    weapons[i].GetDamageBonus() + " | " + 
                    weapons[i].GetDamageDice() + " |");
            }
        }
        private void ShowArmors() { }
        private void ShowRings() { }
    }
}
