using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arena_Fighter_1
{
    class Weather
    {
        String weather;
        static private int defenceEffect = -3;
        static private int hitEffect = -3;
        public Weather()
        {
            int randomNumber = DiceRoll();
            CurrentWeather(randomNumber);

        }
        private int DiceRoll()
        {
            Random randomGenerator = new Random();
            int i = randomGenerator.Next(1, 100);
            return i;
        }
        private void CurrentWeather (int randomNumber)
        {
            if (randomNumber <= 50)
            {
                weather = "Sunny";
            }
            if (randomNumber > 50 && randomNumber <= 75)
            {
                weather = "Raining";

            }
            if (randomNumber > 75)
            {
                weather = "Foggy";
            }
        }
        public string GetWeather()
        {
            return weather;
        }
        public int GetWeatherDefenceEffect()
        {
            return defenceEffect;
        }
        public int GetWeatherHitEffect()
        {
            return hitEffect;
        }
    }
}
