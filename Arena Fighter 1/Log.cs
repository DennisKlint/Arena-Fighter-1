using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arena_Fighter_1
{
    class Log
    {
        private string enemyName;
        private int amountOfRounds;
        private string weather;
//        public Log()
//        {      }
        
        public void AddWeather(string w)
        {
            weather = w;
        }
        public void AddAmountOfRounds(int a)
        {
            amountOfRounds = a;
        }
        public void AddEnemyName(string name)
        {
            enemyName = name;
        }

        public string GetEnemyName()
        {
            return enemyName;
        }
        public int GetAmountOfRounds()
        {
            return amountOfRounds;
        }
        public string GetWeather()
        {
            return weather;
        }
    }
}
