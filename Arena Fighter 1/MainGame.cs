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
        List<Log> log = new List<Log>();

        public MainGame() {
            GenerateStore();
            Console.WriteLine("Welcome to the Arena!");

            //This sets up the main game loop.                
                GeneratePlayerCharacter();
                

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
                    "5. Show your Character Logs" + Environment.NewLine +
                    "6. Exit Game.");
                string s = Console.ReadLine();
                if (s == "1")
                {
                    Console.Clear();
                    //Sends the player character, and some gear for his enemy, to the Arena
                    //log.Add(new Log());
                    log.Add(new Log());

                    Battle battle = new Battle(playerCharacter, store.GetWeapon(0), store.GetArmor(0), log.Last());
                    WhoWonBattle(battle.GetWhoWon());
                    
                }
                else if (s == "2")
                {
                    Console.Clear();
                    store.CheckStore(playerCharacter);
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
                    Console.WriteLine("Are you sure you want to retire your character?" + Environment.NewLine +
                        "You will be able to make a new character once your current one is retiered." + 
                        " type Yes/Y to procceed");
                    string s2 = Console.ReadLine();
                    if (s2 == "Yes" || s2 == "yes" || s2 == "Y" || s2 == "y")
                    {
                        Console.WriteLine("Retiering character...");
                        //Since the player got to retire, they get an extra point of score
                        playerCharacter.UpdateScore(1);
                        Console.WriteLine("Would you like to view the log of this character one last time before retiering them?");
                        string s3 = Console.ReadLine();
                        if (s2 == "Yes" || s2 == "yes" || s2 == "Y" || s2 == "y")
                        {
                            WriteLog();
                        }
                        GeneratePlayerCharacter();
                    }
                }
                else if (s == "5")
                {
                    WriteLog();
                }
                else if (s == "6")
                {
                    return;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Something went wrong, try to reenter what you want to do (1-6)" + Environment.NewLine);
                }
            }
        }

        private void GenerateStore()
        {
            store = new Store();
        }
        private void GeneratePlayerCharacter()
        {
            bool b = true;
            while (b == true)
            {
                Console.Write("Let us make you a gladiator. Please enter a name for your gladiator: ");
                // The user enters a name, then the lowest weapon and armor are fetched from the store
                playerCharacter = new Character(Console.ReadLine(), store.GetWeapon(0), store.GetArmor(0));
                Console.Write("Type Yes/Y if you're happy with your character, else we'll make a new one: ");
                string s = Console.ReadLine();
                if (s == "Yes" || s == "yes" || s == "Y" || s == "y")
                {
                    b = false;
                    Console.Clear();
                }
            }
        }

        private void WriteLog()
        {
            Console.Clear();
            //First we check to see if there's anything in the log
            bool isEmpty = log == null;
            if (isEmpty)
            {
                Console.WriteLine("There is nothing here.");
            }
            else
            {
                for (int i = 0; log.Count > i; i++)
                {
                    Console.WriteLine("Battle nr" + (i + 1) + " took " + log[i].GetAmountOfRounds() + " rounds");
                    Console.WriteLine("The battle was agains " + log[i].GetEnemyName() + Environment.NewLine);
                }
                Console.WriteLine("Press anything to return to continue");
                Console.ReadKey();

            }
        }

        //whoWon = 0 = player won; whoWon = 1 = enemy won; whoWon = 2 = Error
        private void WhoWonBattle(int whoWon)
        {
            if (whoWon == 0)
            {
                //If the player took any damage, their hp, and other stats will be returned to the usual value here
                playerCharacter.UpdateDerivedAttributes();
            }
            if (whoWon == 1)
            {
                Console.WriteLine("You have lost, " + playerCharacter.GetCharacterName() + " is dead");
                Console.WriteLine("If you want to make a new character, type Yes/Y, otherwise, the game will close");
                string s = (Console.ReadLine());
                if (s == "Yes" || s == "yes" || s == "Y" || s == "y")
                {
                    GeneratePlayerCharacter();
                }
                else
                {
                    System.Environment.Exit(1);
                }
            }
        }
    }
}
