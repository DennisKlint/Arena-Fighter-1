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
            // Valuesare as follows: name, cost, toHitBonus, damageBonus, damageDiceSize, damageDiceNumber
            weapons.Add(new Weapon("Wood Sword",00,01,1,6,1));
            weapons.Add(new Weapon("Copper Sword",02,02,2,8,1));
            weapons.Add(new Weapon("Iron Sword",04,03,3,12,1));
            weapons.Add(new Weapon("Silver Sword",08,04,4,6,2));
            weapons.Add(new Weapon("Gold Sword",15,05,5,6,3));
        }
        private void AddArmors()
        {
            // Values as follows: name, cost, defenceBonus, hpBonus
            armors.Add(new Armor("Birthday Suit", 00, 00, 00));
            armors.Add(new Armor("Copper Armor", 02, 01, 02));
            armors.Add(new Armor("Iron Armor", 08, 02, 04));
            armors.Add(new Armor("Silver Armor", 20, 03, 06));
            armors.Add(new Armor("Gold Armor", 60, 04, 10));
        }

        public void CheckStore(Character playerCharacter)
        {
            bool checkStore = true;
            while (checkStore == true)
            {
                Console.WriteLine("Welcome to the store, you have " + playerCharacter.GetCharacterMoney() + " money to spend!");
                Console.WriteLine("What are you interested in, weapons or armors? type Exit to leave");
                string choise = Console.ReadLine();


                if (choise == "weapons" || choise == "Weapons")
                {
                    ShowWeapons(playerCharacter);
                }
                else if (choise == "armors" || choise == "Armors")
                {
                    ShowArmors(playerCharacter);
                }
//                else if (choise == "rings" || choise == "Rings")
//                {
//                    ShowRings();
//                }
                else if (choise == "exit" || choise == "Exit")
                {
                    return;
                }
                else {
                    Console.Clear();
                    Console.WriteLine("I don't understand, can you repeat that?");
                }
            }
        }
        private void ShowWeapons(Character playerCharacter)
        {
            Console.WriteLine("The better the weapon, the more damage you'll do, and your chances to hit increase!" + Environment.NewLine);
            Console.WriteLine("Name :: Cost :: HitBonus :: DamageBonus :: DamageDiceSize :: DamageDiceNumber");

            //Generate a list of all the weapons and their stats
            for (int i = 0; weapons.Count > i; i++)
            {
                Console.WriteLine("| " +weapons[i].GetName() + " | " + 
                    weapons[i].GetCost() + " | " + 
                    weapons[i].GetToHitBonus() + " | " + 
                    weapons[i].GetDamageBonus() + " | " + 
                    weapons[i].GetDamageDice() + " |" +
                    weapons[i].GetDamageDiceNumber());
                
            }
            Console.WriteLine(Environment.NewLine + "Please tell me if you see anything you like! Type Exit if you want to leave");
            bool b = true;
            while (b == true)
            {
                string buyItem = Console.ReadLine();
                if (buyItem == "Exit" || buyItem == "exit")
                {
                    return;
                }
                for (int i = 0; weapons.Count > i; i++)
                {
                    if (buyItem == weapons[i].GetName())
                    {
                        BuyWeapon(playerCharacter, weapons[i]);
                        return;
                    }
                }
                
            }

        }
        private void BuyWeapon(Character playerCharacter, Weapon weapon)
        {
            if (playerCharacter.GetCharacterMoney() >= weapon.GetCost())
            {
                Console.WriteLine("You bought a " + weapon.GetName() + ", and it have now been equiped.");
                playerCharacter.EquipWeapon(weapon);
                playerCharacter.UpdateMoney(-weapon.GetCost());
                playerCharacter.UpdateDerivedAttributes();
            }
            else
            {
                Console.WriteLine("You dont have enough money...");
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }
 
        private void ShowArmors(Character playerCharacter)
        {
            Console.WriteLine("The better your armor, the more health points you'll have. You will also become harder to hit!");
            for (int i = 0; armors.Count > i; i++)
            {
                Console.WriteLine("| " +armors[i].GetName() + " | " +
                    armors[i].GetCost() + " | " +
                    armors[i].GetitemDefenceBonus() + " | " +
                    armors[i].GetItemHpBonus() + " | ");
            }
            Console.WriteLine(Environment.NewLine + "Please tell me if you see anything you like! Type Exit if you want to leave");
            bool b = true;
            while (b == true)
            {
                string buyItem = Console.ReadLine();
                if (buyItem == "Exit" || buyItem == "exit")
                {
                    return;
                }
                for (int i = 0; armors.Count > i; i++)
                {
                    if (buyItem == armors[i].GetName())
                    {
                        BuyArmor(playerCharacter, armors[i]);
                        return;
                    }
                }
            }
        }
        private void BuyArmor(Character playerCharacter, Armor armor)
        {
            if (playerCharacter.GetCharacterMoney() >= armor.GetCost())
            {
                Console.WriteLine("You bought a " + armor.GetName() + ", and it have now been equiped.");
                playerCharacter.EquipArmor(armor);
                playerCharacter.UpdateMoney(-armor.GetCost());
                playerCharacter.UpdateDerivedAttributes();
            }
            else
            {
                Console.WriteLine("You dont have enough money...");
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }

        private void ShowRings() { }

        public Weapon GetWeapon(int i)
        {
            return weapons[i];
        }
        public Armor GetArmor(int i)
        {
            return armors[i];
        }
    }
}
