using System;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;

namespace WarshipsGame.Menu
{
    public class NewGame
    {
        //Tworzenie plansz gry dostępnych globalnie
        static string[,] p1Board = new string[10, 10];
        static string[,] p2Board = new string[10, 10];

        static string[,] p1Hit = new string[10, 10];
        static string[,] p2Hit = new string[10, 10];

        //licznik punktów
        static int pointsP1 = 0;
        static int pointsP2 = 0;

        //Flaga sprawdzająca zwycięzce
        static bool winner = false;

        //Konstruktory statków
        static int selectionX, selectionY;
        static string selectorX, selectorY;

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

        static void DrawBoard(string board)
        {
            if (board == "p1")
            {
                Console.WriteLine("   | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 | ");

                for (int i = 0; i < 10; i++)
                {
                    Console.Write(" {0} |", i);
                    for (int j = 0; j < 10; j++)
                    {
        
                        Console.Write(" {0} |", p1Board[i, j]);
                    }
                    Console.WriteLine();
                }
            }
            else if (board == "p2")
            {
                Console.WriteLine("   | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 | ");

                for (int i = 0; i < 10; i++)
                {
                    Console.Write(" {0} |", i);
                    for (int j = 0; j < 10; j++)
                    {
                        Console.Write(" {0} |", p2Board[i, j]);
                    }
                    Console.WriteLine();
                }
            }
            else if (board == "p1Hit")
            {
                Console.WriteLine("   | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 | ");

                for (int i = 0; i < 10; i++)
                {
                    Console.Write(" {0} |", i);
                    for (int j = 0; j < 10; j++)
                    {
                        Console.Write(" {0} |", p1Hit[i, j]);
                    }
                    Console.WriteLine();
                }
            }
            else if (board == "p2Hit")
            {
                Console.WriteLine("   | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 | ");

                for (int i = 0; i < 10; i++)
                {
                    Console.Write(" {0} |", i);
                    for (int j = 0; j < 10; j++)
                    {
                        Console.Write(" {0} |", p2Hit[i, j]);
                    }
                    Console.WriteLine();
                }
            }

        }

        static void InputShipLocation()
        {

            //Statek 2 maszty pion: za argument ("p1", "p2")
            void PatrolShipHorizontal(string player, string[,] playerBoard)
            {
                Console.WriteLine("\n\nSet sails! \nIt would be patrol (2 slots) ship. \nThis ship will be placed horizontaly! \nPlease select starting location:");
                DrawBoard(player);

                while (true)
                {
                    //Wybór pierwszej koordynaty
                    while (true)
                    {
                        Console.WriteLine("Please select X coordinate: ");
                        selectorX = Console.ReadLine();
                        if (int.TryParse(selectorX, out selectionX) && selectionX >= 0 && selectionX < 9)
                        {
                            Console.WriteLine("You have successfully selected {0}", selectionX);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Please try again.");
                        }
                    }


                    //Wybór drugiej koordynaty

                    while (true)
                    {
                        Console.WriteLine("Please select Y coordinate: ");
                        selectorY = Console.ReadLine();
                        if (int.TryParse(selectorY, out selectionY) && selectionY >= 0 && selectionY < 10)
                        {
                            Console.WriteLine("You have successfully selected {0},{1}", selectionX, selectionY);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Please try again.");
                        }
                    }


                    if (playerBoard[selectionY, selectionX] != "S" && playerBoard[selectionY + 1, selectionX] != "S")
                    {
                        playerBoard[selectionY, selectionX] = "S";
                        playerBoard[selectionY + 1, selectionX] = "S";
                        break;
                    }
                    else
                    {
                        Console.WriteLine("You already have placed ship here. Please try again with different location.");
                    }
                }
                
            }

            //Statek 2 maszty poziom: za argument ("p1", "p2")
            void PatrolShipVertical(string player, string[,] playerBoard)
            {
                Console.WriteLine("\n\nSet sails! \nIt would be patrol (2 slots) ship. \nThis ship will be placed verticaly! \nPlease select starting location:");
                DrawBoard(player);

                while (true)
                {
                    //Wybór pierwszej koordynaty
                    while (true)
                    {
                        Console.WriteLine("Please select X coordinate: ");
                        selectorX = Console.ReadLine();
                        if (int.TryParse(selectorX, out selectionX) && selectionX >= 0 && selectionX < 10)
                        {
                            Console.WriteLine("You have successfully selected {0}", selectionX);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Please try again.");
                        }
                    }


                    //Wybór drugiej koordynaty

                    while (true)
                    {
                        Console.WriteLine("Please select Y coordinate: ");
                        selectorY = Console.ReadLine();
                        if (int.TryParse(selectorY, out selectionY) && selectionY >= 0 && selectionY < 9)
                        {
                            Console.WriteLine("You have successfully selected {0},{1}", selectionX, selectionY);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Please try again.");
                        }
                    }



                    if (playerBoard[selectionY, selectionX] != "S" && playerBoard[selectionY, selectionX + 1] != "S")
                    {
                        playerBoard[selectionY, selectionX] = "S";
                        playerBoard[selectionY, selectionX + 1] = "S";
                        break;
                    }
                    else
                    {
                        Console.WriteLine("You already have placed ship here. Please try again with different location.");
                    }
                }
                
            }

            //Statek 3 maszty pion: za argument ("p1", "p2")
            void DestroyerShipHorizontal(string player, string[,] playerBoard)
            {
                Console.WriteLine("\n\nSet sails! \nIt would be a destroyer (3 slots). \nThis ship will placed horizontaly! \nPlease select starting location:");
                DrawBoard(player);

                while (true)
                {
                    //Wybór pierwszej koordynaty
                    while (true)
                    {
                        Console.WriteLine("Please select X coordinate: ");
                        selectorX = Console.ReadLine();
                        if (int.TryParse(selectorX, out selectionX) && selectionX >= 0 && selectionX < 8)
                        {
                            Console.WriteLine("You have successfully selected {0}", selectionX);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Please try again.");
                        }
                    }

                    //Wybór drugiej koordynaty
                    while (true)
                    {
                        Console.WriteLine("Please select Y coordinate: ");
                        selectorY = Console.ReadLine();
                        if (int.TryParse(selectorY, out selectionY) && selectionY >= 0 && selectionY < 10)
                        {
                            Console.WriteLine("You have successfully selected {0},{1}", selectionX, selectionY);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Please try again.");
                        }
                    }

                    if (playerBoard[selectionY, selectionX] != "S" && playerBoard[selectionY + 1, selectionX] != "S" && playerBoard[selectionY + 2, selectionX] != "S")
                    {
                        playerBoard[selectionY, selectionX] = "S";
                        playerBoard[selectionY+ 1, selectionX] = "S";
                        playerBoard[selectionY + 2, selectionX] = "S";
                        break;
                    }
                    else
                    {
                        Console.WriteLine("You already have placed ship here. Please try again with different location.");
                    }

                }
            }

            //Statek 3 maszty poziom: za argument ("p1", "p2")
            void DestroyerShipVertical(string player, string[,] playerBoard)
            {
                Console.WriteLine("\n\nSet sails! \nIt would be a destroyer (3 slots). \nThis ship will placed vertically! \nPlease select starting location:");
                DrawBoard(player);

                while (true)
                {
                    //Wybór pierwszej koordynaty
                    while (true)
                    {
                        Console.WriteLine("Please select X coordinate: ");
                        selectorX = Console.ReadLine();
                        if (int.TryParse(selectorX, out selectionX) && selectionX >= 0 && selectionX < 10)
                        {
                            Console.WriteLine("You have successfully selected {0}", selectionX);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Please try again.");
                        }
                    }

                    //Wybór drugiej koordynaty
                    while (true)
                    {
                        Console.WriteLine("Please select Y coordinate: ");
                        selectorY = Console.ReadLine();
                        if (int.TryParse(selectorY, out selectionY) && selectionY >= 0 && selectionY < 8)
                        {
                            Console.WriteLine("You have successfully selected {0},{1}", selectionX, selectionY);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Please try again.");
                        }
                    }


                    if (playerBoard[selectionY, selectionX] != "S" && playerBoard[selectionY, selectionX + 1] != "S" && playerBoard[selectionY, selectionX + 2] != "S")
                    {
                        playerBoard[selectionY, selectionX] = "S";
                        playerBoard[selectionY, selectionX + 1] = "S";
                        playerBoard[selectionY, selectionX + 2] = "S";
                        break;
                    }
                    else
                    {
                        Console.WriteLine("You already have placed ship here. Please try again with different location.");
                    }

                }
            }

            //Statek 4 maszty pion: za argument ("p1", "p2")
            void SubmarineShipHorizontal(string player, string[,] playerBoard)
            {
                Console.WriteLine("\n\nSet sails! \nIt would be a submarine (4 slots). \nThis ship will placed horizontaly! \nPlease select starting location:");
                DrawBoard(player);

                while (true)
                {
                    //Wybór pierwszej koordynaty
                    while (true)
                    {
                        Console.WriteLine("Please select X coordinate: ");
                        selectorX = Console.ReadLine();
                        if (int.TryParse(selectorX, out selectionX) && selectionX >= 0 && selectionX < 7)
                        {
                            Console.WriteLine("You have successfully selected {0}", selectionX);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Please try again.");
                        }
                    }

                    //Wybór drugiej koordynaty
                    while (true)
                    {
                        Console.WriteLine("Please select Y coordinate: ");
                        selectorY = Console.ReadLine();
                        if (int.TryParse(selectorY, out selectionY) && selectionY >= 0 && selectionY < 10)
                        {
                            Console.WriteLine("You have successfully selected {0},{1}", selectionX, selectionY);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Please try again.");
                        }
                    }

                    if (playerBoard[selectionY, selectionX] != "S" && playerBoard[selectionY + 1, selectionX] != "S" && playerBoard[selectionY + 2, selectionX] != "S" && playerBoard[selectionY + 3, selectionX] != "S")
                    {
                        playerBoard[selectionY, selectionX] = "S";
                        playerBoard[selectionY + 1, selectionX] = "S";
                        playerBoard[selectionY + 2, selectionX] = "S";
                        playerBoard[selectionY + 3, selectionX] = "S";

                        break;
                    }
                    else
                    {
                        Console.WriteLine("You already have placed ship here. Please try again with different location.");
                    }

                }
            }

            //Statek 4 maszty poziom: za argument ("p1", "p2")
            void SubmarineShipVertical(string player, string[,] playerBoard)
            {
                Console.WriteLine("\n\nSet sails! \nIt would be a submarine (4 slots). \nThis ship will placed vertically! \nPlease select starting location:");
                DrawBoard(player);

                while (true)
                {
                    //Wybór pierwszej koordynaty
                    while (true)
                    {
                        Console.WriteLine("Please select X coordinate: ");
                        selectorX = Console.ReadLine();
                        if (int.TryParse(selectorX, out selectionX) && selectionX >= 0 && selectionX < 10)
                        {
                            Console.WriteLine("You have successfully selected {0}", selectionX);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Please try again.");
                        }
                    }

                    //Wybór drugiej koordynaty
                    while (true)
                    {
                        Console.WriteLine("Please select Y coordinate: ");
                        selectorY = Console.ReadLine();
                        if (int.TryParse(selectorY, out selectionY) && selectionY >= 0 && selectionY < 7)
                        {
                            Console.WriteLine("You have successfully selected {0},{1}", selectionX, selectionY);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Please try again.");
                        }
                    }

                    if (playerBoard[selectionY, selectionX] != "S" && playerBoard[selectionY, selectionX + 1] != "S" && playerBoard[selectionY, selectionX + 2] != "S" && playerBoard[selectionY, selectionX + 3] != "S")
                    {
                        playerBoard[selectionY, selectionX] = "S";
                        playerBoard[selectionY, selectionX + 1] = "S";
                        playerBoard[selectionY, selectionX + 2] = "S";
                        playerBoard[selectionY, selectionX + 3] = "S";
                        break;
                    }
                    else
                    {
                        Console.WriteLine("You already have placed ship here. Please try again with different location.");
                    }

                }
            }


            Console.Clear();
            Console.WriteLine("Player 1 turn. \nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();

            //Gracz 1 ustawianie statków

            //czteromasztowiec - pion
            SubmarineShipHorizontal("p1", p1Board);
            //czteromasztowiec - poziom
            SubmarineShipVertical("p1", p1Board);
            //dwa trzymasztowce - pion
            DestroyerShipHorizontal("p1", p1Board);
            DestroyerShipHorizontal("p1", p1Board);
            //dwa trzymasztowce - poziom
            DestroyerShipVertical("p1", p1Board);
            DestroyerShipVertical("p1", p1Board);
            //dwumasztowiec - pion
            PatrolShipHorizontal("p1", p1Board);
            //dwumasztowiec - poziom
            PatrolShipVertical("p1", p1Board);

            Console.WriteLine("\n\nThank you for your selection! Press any key to continue...");
            Console.ReadKey();
            Console.Clear();

            //Gracz 2 ustawianie statków

            Console.WriteLine("Player 2 turn. \nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();

            //czteromasztowiec - pion
            SubmarineShipHorizontal("p2", p2Board);
            //czteromasztowiec - poziom
            SubmarineShipVertical("p2", p2Board);
            //dwa trzymasztowce - pion
            DestroyerShipHorizontal("p2", p2Board);
            DestroyerShipHorizontal("p2", p2Board);
            //dwa trzymasztowce - poziom
            DestroyerShipVertical("p2", p2Board);
            DestroyerShipVertical("p2", p2Board);
            //dwumasztowiec - pion
            PatrolShipHorizontal("p2", p2Board);
            //dwumasztowiec - poziom
            PatrolShipVertical("p2", p2Board);

        }

        static void ShootingPhase()
        {
            //int points = 0;

            void PlayerHit1(string playerHit, string[,] opponentBoard, string[,] playerHitboard)
            {
                Console.Clear();
                Console.WriteLine("Your current score: {0}", pointsP1);
                Console.WriteLine("Here is your shootboard. Good luck Captain!");
                DrawBoard(playerHit);

                //Wybór pierwszej koordynaty
                while (true)
                {
                    Console.WriteLine("Please select X coordinate: ");
                    selectorX = Console.ReadLine();
                    if (int.TryParse(selectorX, out selectionX) && selectionX >= 0 && selectionX < 10)
                    {
                        Console.WriteLine("You have successfully selected {0}", selectionX);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please try again.");
                    }
                }


                //Wybór drugiej koordynaty

                while (true)
                {
                    Console.WriteLine("Please select Y coordinate: ");
                    selectorY = Console.ReadLine();
                    if (int.TryParse(selectorY, out selectionY) && selectionY >= 0 && selectionY < 10)
                    {
                        Console.WriteLine("You have successfully selected {0},{1}", selectionX, selectionY);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please try again.");
                    }
                }

                //Strzał
                if (opponentBoard[selectionY, selectionX] == "S")
                {
                    Console.WriteLine("Hit!");
                    playerHitboard[selectionY, selectionX] = "H";
                    pointsP1++;
                    if (pointsP1 == 24)
                    {
                        winner = true;
                    }
                }
                else
                {
                    Console.WriteLine("Miss");
                    playerHitboard[selectionY, selectionX] = "M";
                }

                
                Console.WriteLine("Next turn. Press any key to continue...");
                Console.ReadKey();
            }

            void PlayerHit2(string playerHit, string[,] opponentBoard, string[,] playerHitboard)
            {
                Console.Clear();
                Console.WriteLine("Your current score: {0}", pointsP2);
                Console.WriteLine("Here is your shootboard. Good luck Captain!");
                DrawBoard(playerHit);

                //Wybór pierwszej koordynaty
                while (true)
                {
                    Console.WriteLine("Please select X coordinate: ");
                    selectorX = Console.ReadLine();
                    if (int.TryParse(selectorX, out selectionX) && selectionX >= 0 && selectionX < 10)
                    {
                        Console.WriteLine("You have successfully selected {0}", selectionX);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please try again.");
                    }
                }


                //Wybór drugiej koordynaty

                while (true)
                {
                    Console.WriteLine("Please select Y coordinate: ");
                    selectorY = Console.ReadLine();
                    if (int.TryParse(selectorY, out selectionY) && selectionY >= 0 && selectionY < 10)
                    {
                        Console.WriteLine("You have successfully selected {0},{1}", selectionX, selectionY);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please try again.");
                    }
                }

                //Strzał
                if (opponentBoard[selectionY, selectionX] == "S")
                {
                    Console.WriteLine("Hit!");
                    playerHitboard[selectionY, selectionX] = "H";
                    pointsP2++;
                    if (pointsP2 == 24)
                    {
                        winner = true;
                    }
                }
                else
                {
                    Console.WriteLine("Miss");
                    playerHitboard[selectionY, selectionX] = "M";
                }

                Console.WriteLine("Next turn. Press any key to continue...");
                Console.ReadKey();
            }

            //Gracz pierwszy - tura strzału
            PlayerHit1("p1Hit", p2Board, p1Hit);
            //Gracz drugi - tura strzału
            PlayerHit2("p2Hit", p1Board, p2Hit);




            //void PlayerHit(string playerHit, string[,] opponentBoard, string[,] playerHitboard, int playerPoint, out int points)
            //{
            //    Console.Clear();
            //    Console.WriteLine("Your current score: {0}", playerPoint);
            //    Console.WriteLine("Here is your shootboard. Good luck Captain!");
            //    DrawBoard(playerHit);

            //    //Wybór pierwszej koordynaty
            //    while (true)
            //    {
            //        Console.WriteLine("Please select X coordinate: ");
            //        selectorX = Console.ReadLine();
            //        if (int.TryParse(selectorX, out selectionX) && selectionX >= 0 && selectionX < 10)
            //        {
            //            Console.WriteLine("You have successfully selected {0}", selectionX);
            //            break;
            //        }
            //        else
            //        {
            //            Console.WriteLine("Please try again.");
            //        }
            //    }


            //    //Wybór drugiej koordynaty

            //    while (true)
            //    {
            //        Console.WriteLine("Please select Y coordinate: ");
            //        selectorY = Console.ReadLine();
            //        if (int.TryParse(selectorY, out selectionY) && selectionY >= 0 && selectionY < 10)
            //        {
            //            Console.WriteLine("You have successfully selected {0},{1}", selectionX, selectionY);
            //            break;
            //        }
            //        else
            //        {
            //            Console.WriteLine("Please try again.");
            //        }
            //    }

            //    //Strzał
            //    if (opponentBoard[selectionY, selectionX] == "S")
            //    {
            //        Console.WriteLine("Hit!");
            //        playerHitboard[selectionY, selectionX] = "H";
            //        playerPoint++;
            //        points = playerPoint;
         
            //        if (playerPoint == 24)
            //        {
            //            winner = true;
            //        }
            //    }
            //    else
            //    {
            //        Console.WriteLine("Miss");
            //        playerHitboard[selectionY, selectionX] = "M";
            //    }

            //    ref playerPoint;
            //    Console.WriteLine("Next turn. Press any key to continue...");
            //    Console.ReadKey();
            //}

            //PlayerHit("p1Hit", p2Board, p1Hit, pointsP1, out pointsP1);
        }

        static void Game()
        {
            InputShipLocation();
            while (winner == false)
            {
                ShootingPhase();
            }
        }

        static void Summary()
        {
            string gameID;

            //Metoda - wysłanie wyniku do bazy noSQL
            void DBInput(string GameID, int p1score, int p2score)
            {
                var client = new AmazonDynamoDBClient();

                var request = new PutItemRequest
                {
                    TableName = "WarshipsScores",
                    Item = new System.Collections.Generic.Dictionary<string, AttributeValue>
                {
                    { "GameID", new AttributeValue { S = GameID} },
                    { "Player1-score-index", new AttributeValue { N = p1score.ToString()} },
                    { "Player2-score-index", new AttributeValue { N = p2score.ToString()} }
                }
                };

                client.PutItem(request);
            }


            if (pointsP1 > pointsP2)
            {
                Console.WriteLine("Player 1 has won {0} to {1}!\n Congratulations!\n Your score will be saved to scorebox.", pointsP1, pointsP2);
            }
            else if (pointsP1 == pointsP2)
            {
                Console.WriteLine("Wow! It's a draw! But that's very rare! \nYour score will be saved to the scorebox.");
            }
            else
            {
                Console.WriteLine("Player 2 has won {0} to {1}!\n Congratulations!\n Your score will be saved to scorebox.", pointsP2, pointsP1);
            }

            gameID = DateTime.Now.ToString();

            DBInput(gameID, pointsP1, pointsP2);
        }

        public NewGame()
        {

            BoardInit();
            Game();
            Summary();


        }
    }
}
