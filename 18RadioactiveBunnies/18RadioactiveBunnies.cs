using System;
using System.Collections.Generic;
using System.Linq;

class RadioactiveBunnies
{
    public static void Print(char[,] lair)
    {
        for (int i = 0; i < lair.GetLength(0); i++)
        {
            for (int j = 0; j < lair.GetLength(1); j++)
            {
                Console.Write(lair[i, j]);
            }
            Console.WriteLine();
        }
    }
    public static void Spread(char[,] lair)
    {
        var help = (char[,])lair.Clone();
        for (int i = 0; i < lair.GetLength(0); i++)
        {
            for (int j = 0; j < lair.GetLength(1); j++)
            {
                
                    if (help[i, j] == 'B')
                    {
                        if (i > 0)
                        {
                            lair[i - 1, j] = 'B'; 
                        }
                        if (i < lair.GetLength(0)-1)
                        {
                            lair[i + 1, j] = 'B'; 
                        }
                        if (j > 0)
                        {
                            lair[i, j - 1] = 'B'; 
                        }
                        if (j< lair.GetLength(1) -1)
                        {
                            lair[i, j + 1] = 'B'; 
                        }
                    }               
            }
        }
        //return lair;
    }
    static void Main()
    {
        string[] size = Console.ReadLine().Split(' ');
        int rows = int.Parse(size[0]);
        int cols = int.Parse(size[1]);
        char[,] lair = new char[rows, cols];
        int playerCol = 0, playerRow = 0;
        //Stack<int> playerOldCol = new Stack<int>();
        // var playerOldRow = new Stack<int>();
        for (int i = 0; i < rows; i++)
        {
            string input = Console.ReadLine();
            for (int j = 0; j < cols; j++)
            {
                lair[i, j] = input[j];
                if (input[j] == 'P')
                {
                    playerCol = j;
                    playerRow = i;
                    //playerOldCol.Push(j);
                    //playerOldRow.Push(i);
                }
            }
        }
        string commands = Console.ReadLine();
        int oldCol = 0, oldRow = 0;
        for (int i = 0; i < commands.Length; i++)
        {
            lair[playerRow, playerCol] = '.';
            switch (commands[i])
            {
                case 'U':
                    {
                        oldRow = playerRow;
                        oldCol = playerCol;
                        playerRow--;
                        //playerOldRow.Push(playerRow);
                    }
                    break;
                case 'D':
                    {
                        oldRow = playerRow;
                        oldCol = playerCol;
                        playerRow++;
                        //playerOldRow.Push(playerRow);
                    }
                    break;
                case 'L':
                    {
                        oldRow = playerRow;
                        oldCol = playerCol;
                        playerCol--;
                        //playerOldCol.Push(playerCol);
                    }
                    break;
                case 'R':
                    {
                        oldRow = playerRow;
                        oldCol = playerCol;
                        playerCol++;
                        //playerOldCol.Push(playerCol);
                    }
                    break;
            }

            if (playerRow < 0 || playerRow > rows - 1 || playerCol < 0 || playerCol > cols - 1)
            {
                Spread(lair);
                Print(lair);
                //playerOldCol.Pop();
                //playerOldRow.Pop();
                Console.WriteLine("won: {0} {1}", oldRow, oldCol);
                return;
            }
            else
            {
                if (lair[playerRow, playerCol] == 'B')
                {
                    Spread(lair);
                    Print(lair);
                    Console.WriteLine("dead: {0} {1}", playerRow, playerCol);
                    return;
                }
                Spread(lair);
                if (lair[playerRow, playerCol] == 'B')
                {
                    Print(lair);
                    Console.WriteLine("dead: {0} {1}", playerRow, playerCol);
                    return;
                }
            }
        }
    }
}

