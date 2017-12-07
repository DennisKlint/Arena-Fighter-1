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
        private int whoWon;
        Log log;
        public Battle(Character character, Weapon enemyWeapon, Armor enemyArmor, Log l)
        {
            log = l;
            playerCharacter = character;
            enemyCharacter = new Character(enemyWeapon, enemyArmor);
            log.AddEnemyName(enemyCharacter.GetCharacterName());
            Console.WriteLine("Your Enemy for this battle will be: "+ Environment.NewLine);
            enemyCharacter.DisplayCharacter();
            GenerateWeather();
            log.AddWeather(weather.GetWeather());
            Console.WriteLine("The weather is: " + weather.GetWeather() +Environment.NewLine);
            Console.Write("Press any button to start the battle ");
            Console.ReadKey();
            Console.Clear();

            // 0 = player won, 1 = enemy won, 2 = something went wrong
            whoWon = CombatRoundLoop();
             

        }
        private int CombatRoundLoop()
        {

            int amountOfRounds = 0;
            while ((playerCharacter.IsCharacterAlive() && enemyCharacter.IsCharacterAlive()) == true)
            {
                Round round = new Round(playerCharacter, enemyCharacter, weather);
                amountOfRounds += 1;
                
            }
            log.AddAmountOfRounds(amountOfRounds);
            if (enemyCharacter.GetCharacterHp() <= 0)
            {
                Console.WriteLine(playerCharacter.GetCharacterName() + " is victorious!");
                playerCharacter.UpdateMoney(5);
                playerCharacter.UpdateScore(1);
                return 0;
            }
            else if (playerCharacter.GetCharacterHp() <= 0)
            {
                Console.WriteLine(playerCharacter.GetCharacterName() + " have been slain by " + 
                    enemyCharacter.GetCharacterName());
                return 1;
            }
            else
            {
                Console.WriteLine("Error in Batle.CombatRoundLoop");
                return 2;
            }
        }

        private void GenerateWeather()
        {
            weather = new Weather();
        }

        public int GetWhoWon()
        {
            return whoWon;
        }
    }
}
