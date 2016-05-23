using System;
using System.Collections.Generic;
using System.Linq;

class RubikMatrix
{
    public static void Print(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
    public static string Find(int x, int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] == x)
                {
                    return i.ToString() + " " + j.ToString();
                }
            }
        }
        return "1 1";
    }
    static void Main()
    {
        string[] size = Console.ReadLine().Split(' ');
        int row = int.Parse(size[0]);
        int col = int.Parse(size[1]);
        int lines = int.Parse(Console.ReadLine());
        int[,] matrix = new int[row, col];
        int[,] matrixMoved = new int[row, col];
        int filler = 1;
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                matrix[i, j] = filler;
                filler++;
            }
        }

        matrixMoved = (int[,])matrix.Clone();

        for (int i = 0; i < lines; i++)
        {
            string[] input = Console.ReadLine().Split(' ');
            int what = int.Parse(input[0]);
            string where = input[1];
            int moves = int.Parse(input[2]);

            if (where == "up")
            {
                moves %= row;
                for (int k = 0; k < row; k++)
                {
                    matrixMoved[k, what] = matrix[(k + moves) % row, what];
                }
            }
            else if (where == "down")
            {
                moves %= row;
                for (int k = 0; k < row; k++)
                {
                   // int help = (k >= moves) ? k - moves : row - 1;
                    matrixMoved[k, what] = matrix[(row + (k - moves)) % row, what];
                }
            }
            else if (where == "left")
            {
                moves %= col;
                for (int k = 0; k < col; k++)
                {

                    matrixMoved[what, k] = matrix[what, (k + moves) % row];
                }
            }
            else if (where == "right")
            {
                moves %= col;
                for (int k = 0; k < col; k++)
                {
                   // int help = (k >= moves) ? k - moves : col - 1;
                    matrixMoved[what, k] = matrix[what, (col + (k - moves)) % col];
                }
            }
            matrix = (int[,])matrixMoved.Clone();
            //Print(matrix);
        }
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                if (matrix[i, j] == i * col + j + 1)
                {
                    Console.WriteLine("No swap required");
                }
                else
                {
                    //string[] find = Find(i * col + j + 1, matrix).Split(' ');
                    //int k = int.Parse(find[0]);
                    //int m = int.Parse(find[1]);
                    for (int k = 0; k < row; k++)
                    {
                        for (int m = 0; m < col; m++)
                        {
                            if (matrix[k, m] == i * col + j + 1)
                            {
                                Console.WriteLine("Swap ({0}, {1}) with ({2}, {3})", i, j, k, m);
                                int temp = matrix[i, j];
                                matrix[i, j] = matrix[k, m];
                                matrix[k, m] = temp;
                                break;
                            }
                        }
                    }

                }
            }
        }
    }
}

