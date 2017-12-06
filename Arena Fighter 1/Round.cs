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
                Console.WriteLine("Uhh, this should not be here...");
            }
            List<int> init =RollInitiative();

            if (init[0] > init[1] || (init[0] == init[1] && playerCharacter.GetDex() > enemyCharacter.GetDex()))
            {
                Console.WriteLine(playerCharacter.GetCharacterName() + " Attacks first!");
                AttackMove(playerCharacter, enemyCharacter);
                AttackMove(enemyCharacter, playerCharacter);
            }
            else if (init[1] > init[0] || (init[1] == init[0] && enemyCharacter.GetDex() > playerCharacter.GetDex()))
            {
                Console.WriteLine(enemyCharacter.GetCharacterName() + " Attacks First!");
                AttackMove(enemyCharacter, playerCharacter);
                AttackMove(playerCharacter, enemyCharacter);
            }
            else
            {
                Console.WriteLine(playerCharacter.GetCharacterName() + " and " + 
                    enemyCharacter.GetCharacterName() + " attacks at the same time, nothing happens...");
            }
        }

        private void AttackMove(Character character1, Character character2)
        {
            int atemptToHit = ((character1.GetCharacterBonusToHit() + DiceCreator(20)) - weatherHitEffect);
            if (atemptToHit > (character2.GetCharacterDefence() - weatherDefenceEffect))
            {
                Console.WriteLine(character1.GetCharacterName() + " Hits " + character2.GetCharacterName() + "!");
                DealDamage(character1, character2);
            }
            else
            {
                Console.WriteLine(character2.GetCharacterName() + " Dodges " + character1.GetCharacterName() + "'s attack!");
            }
        }
        private void DealDamage(Character character1, Character character2)
        {
            int damageDiceResult = DiceCreator(character1.GetCharacterWeaponDiceSize(), character1.GetCharacterWeaponDiceNumber());
            int damage = (character1.GetCharacterBonusToDamage() + damageDiceResult);
        }
        private List<int> RollInitiative()
        {
            List<int> init = new List<int>();
            init.Add(playerCharacter.GetCharacterInitiative() + DiceCreator(20));
            init.Add(enemyCharacter.GetCharacterInitiative() + DiceCreator(20));
            return init;
        }
        private int DiceCreator(int dice)
        {
            Random randomGenerator = new Random();
            return randomGenerator.Next(1, dice);
        }
        private int DiceCreator(int dice, int numberOfDice)
        {
            Random randomGenerator = new Random();
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
