using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arena_Fighter_1
{
    class Round
    {
        Character playerCharacter;
        Character enemyCharacter;
        Weather weather;
        Random randomGenerator = new Random();
        int weatherDefenceEffect;
        int weatherHitEffect;

        public Round(Character character1, Character character2, Weather w)
        {
            weather = w;
            playerCharacter = character1;
            enemyCharacter = character2;
            if (weather.GetWeather() == "Sunny")
            {
                SunnyWeatherEffect();
            }
            else if (weather.GetWeather() == "Raining")
            {
                RainingWeatherEffect();
            }
            else if (weather.GetWeather() == "Foggy")
            {
                FoggyWeatherEffect();
            }
            else
            {
                Console.WriteLine("Weather Bug");
            }

            // Here the characters will roll their initiative, and we figure out who goes first
            List<int> init =RollInitiative();
            if (init[0] > init[1] || (init[0] == init[1] && playerCharacter.GetDex() > enemyCharacter.GetDex()))
            {
                Console.WriteLine(playerCharacter.GetCharacterName() + " Attacks first!");
                AttackMove(playerCharacter, enemyCharacter);
                if (enemyCharacter.IsCharacterAlive() == true) {
                    AttackMove(enemyCharacter, playerCharacter);
                }
                else
                {
                    //Enemy character just died, do something cool here
                    Console.WriteLine(enemyCharacter.GetCharacterName() + " died!");
                    return;
                }
            }
            else if (init[1] > init[0] || (init[1] == init[0] && enemyCharacter.GetDex() > playerCharacter.GetDex()))
            {
                Console.WriteLine(enemyCharacter.GetCharacterName() + " Attacks First!");
                AttackMove(enemyCharacter, playerCharacter);
                if (playerCharacter.IsCharacterAlive() == true) {
                    AttackMove(playerCharacter, enemyCharacter);
                }
                else
                {
                    Console.WriteLine(playerCharacter.GetCharacterName() + " died!");
                    //playerCharacter just died, do something here
                }
            }
            else
            {
                Console.WriteLine(playerCharacter.GetCharacterName() + " and " + 
                    enemyCharacter.GetCharacterName() + " attacks at the same time, nothing happens...");
            }
            Console.WriteLine(playerCharacter.GetCharacterName() + " has " + playerCharacter.GetCharacterHp());
            Console.WriteLine(enemyCharacter.GetCharacterName() + " has " + enemyCharacter.GetCharacterHp());
            Console.ReadLine();
            Console.WriteLine(" ");
        }

        private void AttackMove(Character character1, Character character2)
        {
            int atemptToHit = ((character1.GetCharacterBonusToHit() + DiceCreator(20)) - weatherHitEffect);
            if (atemptToHit > (character2.GetCharacterDefence() - weatherDefenceEffect))
            {
                Console.WriteLine(character1.GetCharacterName()+ " rolled " + atemptToHit + " and hits " + character2.GetCharacterName() + "!");
                DealDamage(character1, character2);
            }
            else
            {
                Console.WriteLine(character1.GetCharacterName() + " rolled " + atemptToHit + " and missed " + character2.GetCharacterName() + "!");
            }
        }
        private void DealDamage(Character character1, Character character2)
        {
            int damageDiceResult = DiceCreator(character1.GetCharacterWeaponDiceSize(), character1.GetCharacterWeaponDiceNumber());
            int damage = (character1.GetCharacterBonusToDamage());
            int damageResult = (damageDiceResult + damage);
            Console.WriteLine(character1.GetCharacterName() + " dealt " + (damageDiceResult + damage) + " damage!");
            // Here we'll check if we did negative damage, and change it to 0, as we'd otherwise heal the other character
            if (damageResult < 0)
            {
                damageResult = 0;
            }
            character2.TakeDamage(damageResult);
        }

        private List<int> RollInitiative()
        {
            List<int> init = new List<int>();
            init.Add(playerCharacter.GetCharacterInitiative() + DiceCreator(20));
            Console.WriteLine(playerCharacter.GetCharacterName() + " initiative is: " + init[0]);
            init.Add(enemyCharacter.GetCharacterInitiative() + DiceCreator(20));
            Console.WriteLine(enemyCharacter.GetCharacterName() + " initiative is: " + init[1]);
            return init;
        }

        private int DiceCreator(int dice)
        {
            return randomGenerator.Next(1, dice);
        }
        private int DiceCreator(int dice, int numberOfDice)
        {
            List<int> diceResult = new List<int>();
            for (int i = 0; i < numberOfDice; i++)
            {
                diceResult.Add(randomGenerator.Next(1, dice));
            }
            return diceResult.Sum();

        }

        private void SunnyWeatherEffect()
        {
            //What a great day for battle!
        }
        private void RainingWeatherEffect()
        {
            weatherDefenceEffect = weather.GetWeatherDefenceEffect();
        }
        private void FoggyWeatherEffect()
        {
            weatherHitEffect = weather.GetWeatherHitEffect();
        }
    }
}
