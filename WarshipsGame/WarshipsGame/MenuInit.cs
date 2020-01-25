using System;
namespace WarshipsGame
{
    public class MenuInit
    {
        public MenuInit()
        {
            Console.WriteLine("Hi, welcome in Warships Battle Game. Please select one of the menu options.\n");
            while (true)
            {
                try
                {
                    Console.WriteLine("1. New game \n2. Results history \n3. TBD \n0. Exit\n");
                    ushort menuSecetion = ushort.Parse(Console.ReadLine());

                    switch (menuSecetion)
                    {
                        case 1:
                            var newGame = new Menu.NewGame();
                            break;
                        case 2:
                            var Results = new Menu.Results();
                            break;
                        case 3:
                            break;
                        case 0:
                            var exit = new Menu.Exit();
                            break;
                        default:
                            Console.WriteLine("Please select from given options.");
                            break;
                    }

                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Null here? Good try :), but please try again.");

                }
                catch (FormatException)
                {
                    Console.WriteLine("Bad input format. Please try with numbers!");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Overflow, please try with numbers only!");
                }
            }

        }
    }
}
