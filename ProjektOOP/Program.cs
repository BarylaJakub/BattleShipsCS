using System;

namespace BattleshipGame
{
    class Program
    {
        class Board {
        static void InitializeBoard(char[,] board)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    board[i, j] = ' ';
                }
            }
        }

        static void DrawBoard(char[,] board)
        {
            Console.WriteLine("   A B C D E F G H I J");
            for (int i = 0; i < 10; i++)
            {
                Console.Write(i + "  ");
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        
        static bool IsValidPosition(int x, int y)
        {
            return x >= 0 && x < 10 && y >= 0 && y < 10;
        }

        static bool CanPlaceShip(char[,] board, int x, int y, int length, char direction)
        {
            for (int i = x - 1; i <= x + 1; i++)
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    if (IsValidPosition(i, j) && board[i, j] != ' ')
                    {
                        return false;
                    }
                }
            }

            if (direction == 'H')
            {
                if (y + length > 10)
                {
                    return false;
                }
                for (int i = y; i < y + length; i++)
                {
                    if (!IsValidPosition(x, i) || board[x, i] != ' ')
                        return false;
                }
            }
            else if (direction == 'V')
            {
                if (x + length > 10)
                {
                    return false;
                }
                for (int i = x; i < x + length; i++)
                {
                    if (!IsValidPosition(i, y) || board[i, y] != ' ')
                        return false;
                }
            }
            else
            {
                Console.WriteLine("Błąd.");
                return false;
            }
            return true;
        }
        
        class Ships{
        static void PlaceShip(char[,] board, int x, int y, int length, char direction)
        {
            if (direction == 'H')
            {
                for (int i = y; i < y + length; i++)
                {
                    board[x, i] = 'S';
                }
            }
            else if (direction == 'V')
            {
                for (int i = x; i < x + length; i++)
                {
                    board[i, y] = 'S';
                }
            }
        }

        static bool IsHit(char[,] board, int x, int y)
        {
            return board[x, y] == 'S';
        }

        static bool AllShipsSunk(char[,] board)
        {
            foreach (var cell in board)
            {
                if (cell == 'S')
                    return false;
            }
            return true;
        }


        class Player{
        static char[,] player1Board = new char[10, 10];
        static char[,] player2Board = new char[10, 10];
        static int player1SingleMasted = 4;
        static int player1TwoMasted = 3;
        static int player1ThreeMasted = 2;
        static int player1FourMasted = 1;
        static int player2SingleMasted = 4;
        static int player2TwoMasted = 3;
        static int player2ThreeMasted = 2;
        static int player2FourMasted = 1;
        static void Main(string[] args)
        {
            Console.WriteLine("Graczu 1 - ustawiaj statki.");
            InitializeBoard(player1Board);
            DrawBoard(player1Board);

            for (int i = 0; i < player1SingleMasted; i++)
            {
                Console.WriteLine($"Ustawianie jednomasztowego statku nr.: {i + 1}.");
                Console.Write("Wpisz koordynaty (np. A0): ");
                string[] input = Console.ReadLine().Trim().Split();
                string coordinates = input[0].ToUpper();
                int x = coordinates[1] - '0';
                int y = coordinates[0] - 'A';
                Console.Write("Podaj kierunek (H - poziomo, V - pionowo): ");
                char direction = Console.ReadLine().ToUpper()[0];

                if (!CanPlaceShip(player1Board, x, y, 1, direction))
                {
                    Console.WriteLine("Błąd.");
                    i--;
                    continue;
                }

                PlaceShip(player1Board, x, y, 1, direction);
                DrawBoard(player1Board);
            }

            for (int i = 0; i < player1TwoMasted; i++)
            {
                Console.WriteLine($"Ustawianie dwumasztowego statku nr.: {i + 1}.");
                Console.Write("Wpisz koordynaty (np. A0): ");
                string[] input = Console.ReadLine().Trim().Split();
                string coordinates = input[0].ToUpper();
                int x = coordinates[1] - '0';
                                int y = coordinates[0] - 'A';
                Console.Write("Podaj kierunek (H - poziomo, V - pionowo): ");
                char direction = Console.ReadLine().ToUpper()[0];

                if (!CanPlaceShip(player1Board, x, y, 2, direction))
                {
                    Console.WriteLine("Błąd - podano złą pozycję.");
                    i--;
                    continue;
                }

                PlaceShip(player1Board, x, y, 2, direction);
                DrawBoard(player1Board);
            }

            for (int i = 0; i < player1ThreeMasted; i++)
            {
                Console.WriteLine($"Ustawianie trzymasztowego statku nr.: {i + 1}.");
                Console.Write("Wpisz koordynaty (np. A0): ");
                string[] input = Console.ReadLine().Trim().Split();
                string coordinates = input[0].ToUpper();
                int x = coordinates[1] - '0';
                int y = coordinates[0] - 'A';
                Console.Write("Podaj kierunek (H - poziomo, V - pionowo): ");
                char direction = Console.ReadLine().ToUpper()[0];

                if (!CanPlaceShip(player1Board, x, y, 3, direction))
                {
                    Console.WriteLine("Błąd - podano złą pozycję");
                    i--;
                    continue;
                }

                PlaceShip(player1Board, x, y, 3, direction);
                DrawBoard(player1Board);
            }

            for (int i = 0; i < player1FourMasted; i++)
            {
                Console.WriteLine($"Ustawianie czteromasztowego statku nr.: {i + 1}.");
                Console.Write("Wpisz koordynaty (np. A0): ");
                string[] input = Console.ReadLine().Trim().Split();
                string coordinates = input[0].ToUpper();
                int x = coordinates[1] - '0';
                int y = coordinates[0] - 'A';
                Console.Write("Podaj kierunek (H - poziomo, V - pionowo): ");
                char direction = Console.ReadLine().ToUpper()[0];

                if (!CanPlaceShip(player1Board, x, y, 4, direction))
                {
                    Console.WriteLine("Błąd - podano złą pozycję");
                    i--;
                    continue;
                }

                PlaceShip(player1Board, x, y, 4, direction);
                DrawBoard(player1Board);
            }

            Console.Clear();
            Console.WriteLine("Graczu 2 - ustawiaj statki.");
            InitializeBoard(player2Board);
            DrawBoard(player2Board);

            for (int i = 0; i < player2SingleMasted; i++)
            {
                Console.WriteLine($"Ustawianie jednomasztowego statku nr.: {i + 1}.");
                Console.Write("Wpisz koordynaty (np. A0): ");
                string[] input = Console.ReadLine().Trim().Split();
                string coordinates = input[0].ToUpper();
                int x = coordinates[1] - '0';
                int y = coordinates[0] - 'A';
                Console.Write("Podaj kierunek (H - poziomo, V - pionowo): ");
                char direction = Console.ReadLine().ToUpper()[0];

                if (!CanPlaceShip(player2Board, x, y, 1, direction))
                {
                    Console.WriteLine("Błąd - podano złą pozycję");
                    i--;
                    continue;
                }

                PlaceShip(player2Board, x, y, 1, direction);
                DrawBoard(player2Board);
            }

            for (int i = 0; i < player2TwoMasted; i++)
            {
                Console.WriteLine($"Ustawianie dwumasztowego statku nr.: {i + 1}.");
                Console.Write("Wpisz koordynaty (np. A0): ");
                string[] input = Console.ReadLine().Trim().Split();
                string coordinates = input[0].ToUpper();
                int x = coordinates[1] - '0';
                int y = coordinates[0] - 'A';
                Console.Write("Podaj kierunek (H - poziomo, V - pionowo): ");
                char direction = Console.ReadLine().ToUpper()[0];

                if (!CanPlaceShip(player2Board, x, y, 2, direction))
                {
                    Console.WriteLine("Błąd - podano złą pozycję");
                    i--;
                    continue;
                }

                PlaceShip(player2Board, x, y, 2, direction);
                DrawBoard(player2Board);
            }

            for (int i = 0; i < player2ThreeMasted; i++)
            {
                Console.WriteLine($"Ustawianie trzymasztowego statku nr.: {i + 1}.");
                Console.Write("Wpisz koordynaty (np. A0): ");
                string[] input = Console.ReadLine().Trim().Split();
                string coordinates = input[0].ToUpper();
                int x = coordinates[1] - '0';
                int y = coordinates[0] - 'A';
                Console.Write("Podaj kierunek (H - poziomo, V - pionowo): ");
                char direction = Console.ReadLine().ToUpper()[0];

                if (!CanPlaceShip(player2Board, x, y, 3, direction))
                {
                    Console.WriteLine("Błąd - podano złą pozycję");
                    i--;
                    continue;
                }

                PlaceShip(player2Board, x, y, 3, direction);
                DrawBoard(player2Board);
            }

            for (int i = 0; i < player2FourMasted; i++)
            {
                Console.WriteLine($"Ustawianie czteromasztowego statku nr.: {i + 1}.");
                Console.Write("Wpisz koordynaty (np. A0): ");
                string[] input = Console.ReadLine().Trim().Split();
                string coordinates = input[0].ToUpper();
                int x = coordinates[1] - '0';
                int y = coordinates[0] - 'A';
                Console.Write("Podaj kierunek (H - poziomo, V - pionowo): ");
                char direction = Console.ReadLine().ToUpper()[0];

                if (!CanPlaceShip(player2Board, x, y, 4, direction))
                {
                    Console.WriteLine("Błąd - podano złą pozycję");
                    i--;
                    continue;
                }

                PlaceShip(player2Board, x, y, 4, direction);
                DrawBoard(player2Board);
            }
            }
          }
          }
        }
    }
}

