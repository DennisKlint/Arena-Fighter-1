using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arena_Fighter_1
{
    class MainGame
    {
        Store store;
        Character playerCharacter;

        public MainGame() {
            GenerateStore();
            Console.WriteLine("Welcome to the Arena!");

            //This sets up the main game loop.
            bool b = true;
            while (b == true)
            {
                Console.Write("Let us make you a gladiator. Please enter a name for your gladiator: ");
                // The user enters a name, then the lowest weapon and armor are fetched from the store
                GeneratePlayerCharacter();
                Console.Write("Type Yes/Y if you're happy with your character, else we'll make a new one: ");
                string s = Console.ReadLine();
                if (s == "Yes" || s == "yes" || s == "Y" || s == "y")
                {
                    b = false;
                    Console.Clear();
                }
            }
            MainGameMenu();
            
        }

        private void MainGameMenu()
        {
            bool b = true;
            while (b==true)
            {
                Console.WriteLine("Your Character have been saved. What would you like to do?" + Environment.NewLine +
                    "1. Enter the Arena!" + Environment.NewLine +
                    "2. Go to the Store." + Environment.NewLine +
                    "3. Inspect your Character." + Environment.NewLine +
                    "4. Retire Character." + Environment.NewLine +
                    "5. Exit Game.");
                string s = Console.ReadLine();
                if (s == "1")
                {
                    Console.Clear();
                    //Sends the player character, and some gear for his enemy, to the Arena
                    Battle battle = new Battle(playerCharacter, store.GetWeapon(0), store.GetArmor(0));
                }
                else if (s == "2")
                {

                }
                else if (s == "3")
                {
                    playerCharacter.DisplayCharacter();
                    Console.Write("Press any key to return to the menu: ");
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (s == "4")
                {

                }
                else if (s == "5")
                {
                    return;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Something went wrong, try to reenter what you want to do (1-5)" + Environment.NewLine);
                }
            }
        }

        private void GenerateStore()
        {
            store = new Store();
        }
        private void GeneratePlayerCharacter()
        {
            playerCharacter = new Character(Console.ReadLine(), store.GetWeapon(0), store.GetArmor(0));
        }
    }
}
