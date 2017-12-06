using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arena_Fighter_1
{
    class Battle
    {
        Weather weather;
        Character enemyCharacter;
        Character playerCharacter;
        List<string> log;
        public Battle(Character character, Weapon enemyWeapon, Armor enemyArmor)
        {
            playerCharacter = character;
            enemyCharacter = new Character(enemyWeapon, enemyArmor);
            Console.WriteLine("Your Enemy for this battle will be: "+ Environment.NewLine);
            enemyCharacter.DisplayCharacter();
            GenerateWeather();
            Console.WriteLine("The weather is: " + weather.GetWeather() +Environment.NewLine);
            Console.Write("Press any button to start the battle ");
            Console.ReadKey();
            Console.Clear();

            CombatRoundLoop();

        }
        private void CombatRoundLoop()
        {
            while (playerCharacter.GetCharacterHp() > 0 || enemyCharacter.GetCharacterHp() > 0)
            {
                Round round = new Round(playerCharacter, enemyCharacter, weather);
            }
        }

        private void GenerateWeather()
        {
            weather = new Weather();
        }
    }
}
