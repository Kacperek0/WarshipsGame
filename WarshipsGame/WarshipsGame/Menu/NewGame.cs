using System;
namespace WarshipsGame.Menu
{
    public class NewGame
    {
        //Tworzenie plansz gry dostępnych globalnie
        static string[,] p1Board = new string[10, 10];
        static string[,] p2Board = new string[10, 10];

        static string[,] p1Hit = new string[10, 10];
        static string[,] p2Hit = new string[10, 10];

        //licznik ruchów
        static int hitCounterP1 = 0;
        static int hitCounterP2 = 0;

        //licznik punktów
        static int pointsP1 = 0;
        static int pointsP2 = 0;

        //Flaga sprawdzająca zwycięzce
        static bool winner = false;

        static void BoardInit()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    p1Board[i, j] = " ";
                    p2Board[i, j] = " ";

                    p1Hit[i, j] = " ";
                    p2Hit[i, j] = " ";
                }
            }
        }


        public NewGame()
        {



        }
    }
}
