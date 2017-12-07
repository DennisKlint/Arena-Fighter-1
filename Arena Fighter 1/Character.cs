using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lexicon.CSharp.InfoGenerator;

namespace Arena_Fighter_1
{
    class Character
    {
        //Strength, Dexterity, Constitution
        private int str;
        private int dex;
        private int con;

        private string characterName;
        private int characterScore;
        private int characterMoney = 5;

        //These are "Derived Attributes", they are affected by a characters attributes, and gear
        private int bonusToDamage;
        private int bonusToHit;
        private int initiative;
        private int defence;
        private int hp;

        private Weapon characterWeapon;
        private Armor characterArmor;

        // This constructor will be used when we make a player character
        public Character(string name, Weapon weapon, Armor armor)
        {
            characterName = name;
            GenerateAttributes();
            GenerateGear(weapon, armor);
            UpdateDerivedAttributes();
            UpdateMoney(0);
            UpdateScore(0);

            Console.WriteLine(characterName + " have been generated, his stats and gear is as follows: " 
                + Environment.NewLine);
            DisplayCharacter();
        }
        // This constructor will be used to generate enemies
        public Character(Weapon weapon, Armor armor)
        {
            //Make a random number generator, put a random number in the "seed", 
            //and use that to pull a random name from InfoGenerator
            Random randomGenerator = new Random();
            int seed = randomGenerator.Next();
            InfoGenerator randomName = new InfoGenerator(seed);

            characterName = randomName.NextFullName();
            GenerateAttributes();
            GenerateGear(weapon, armor);
            UpdateDerivedAttributes();
            UpdateMoney(0);
            UpdateScore(0);
        }

        // Generates the basics for a Character
        private void GenerateAttributes()
        {
            Random dice1 = new Random();
            Random dice2 = new Random();
            Random dice3 = new Random();
            str = (dice1.Next(1,6) + dice2.Next(1,6) + dice3.Next(1,6));
            dex = (dice1.Next(1,6) + dice2.Next(1,6) + dice3.Next(1,6));
            con = (dice1.Next(1,6) + dice2.Next(1,6) + dice3.Next(1,6));

        }
        private void GenerateGear(Weapon weapon, Armor armor){
            EquipWeapon(weapon);
            EquipArmor(armor);
        }
        public void EquipWeapon(Weapon weapon)
        {
            characterWeapon = weapon;
        }
        public void EquipArmor(Armor armor)
        {
            characterArmor = armor;
        }

        // Updates ALL the Derived Attributes
        public void UpdateDerivedAttributes()
        {
            bonusToDamage = CalcAttribute(str) + characterWeapon.GetDamageBonus();
            bonusToHit = CalcAttribute(str) + characterWeapon.GetToHitBonus();
            initiative = CalcAttribute(dex);
            defence = CalcAttribute(dex) + characterArmor.GetitemDefenceBonus() + 10;
            hp = (con * 2) + characterArmor.GetItemHpBonus();
        }
        private int CalcAttribute(int a)
        {
            int x = a-10;
            if (x==0)
            {
                return x;
            }
            else
            {
                return x / 2;
            } 
        }

        public void UpdateMoney(int m)
        {
            characterMoney += m;
        }
        public void UpdateScore(int s)
        {
            characterScore += s;
        }

       public void DisplayCharacter()
        {
            Console.WriteLine(characterName + Environment.NewLine +
                "Strength: " + str + Environment.NewLine +
                "Dexterity: " + dex + Environment.NewLine +
                "Constitution: " + con + Environment.NewLine +
                "Weapon: " + characterWeapon.GetName() + Environment.NewLine +
                "Armor: " + characterArmor.GetName() + Environment.NewLine +
                "Money: " + characterMoney + Environment.NewLine +
                "Score: " + characterScore);
        }

        //Apply damage to characters hp
        public void TakeDamage(int damage) 
            {
            hp -= damage;
            }

        //Return true if alive, false if not
        public bool IsCharacterAlive()
        {
            if (hp >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Allows other objects to "inspect" the elements of Character
        public int GetStr()
        {
            return str;
        }
        public int GetDex()
        {
            return dex;
        }
        public int GetCon()
        {
            return con;
        }
        public string GetCharacterName()
        {
            return characterName;
        }
        public int GetCharacterScore()
        {
            return characterScore;
        }
        public int GetCharacterMoney()
        {
            return characterMoney;
        }
        public int GetCharacterBonusToDamage()
        {
            return bonusToDamage;
        }
        public int GetCharacterBonusToHit()
        {
            return bonusToHit;
        }
        public int GetCharacterInitiative()
        {
            return initiative;
        }
        public int GetCharacterDefence()
        {
            return defence;
        }
        public int GetCharacterHp()
        {
            return hp;
        }
        public int GetCharacterWeaponDiceSize()
        {
            return characterWeapon.GetDamageDice();
        }
        public int GetCharacterWeaponDiceNumber()
        {
            return characterWeapon.GetDamageDiceNumber();
        }
    }
}
