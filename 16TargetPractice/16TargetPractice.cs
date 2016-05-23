using System;
using System.Collections.Generic;
using System.Linq;

class TargetPractice
{
    public static void Print(char[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] );
            }
            Console.WriteLine();
        }
    }
    static void Main()
    {
        string[] size = Console.ReadLine().Split(' ');
        int rows = int.Parse(size[0]);
        int cols = int.Parse(size[1]);
        char[,] matrix = new char[rows, cols];
        string text = Console.ReadLine();
        Queue<char> snake = new Queue<char>();
        for (int i = 0; i < text.Length; i++)
        {
            snake.Enqueue(text[i]);
        }
        for (int i = rows - 1; i >= 0; i--)
        {
            if ((rows - 1 - i) % 2 == 0)
            {
                for (int j = cols - 1; j >= 0; j--)
                {
                    matrix[i, j] = snake.Peek();
                    snake.Enqueue(snake.Peek());
                    snake.Dequeue();
                }
            }
            else
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = snake.Peek();
                    snake.Enqueue(snake.Peek());
                    snake.Dequeue();
                }
            }
        }
        int[] shot = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int shotRow = shot[0];
        int shotCol = shot[1];
        int radius = shot[2];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                bool inRow = shotRow == i && j >= shotCol - radius && j <= shotCol + radius;
                bool inCol = shotCol == j && i >= shotRow - radius && i <= shotRow + radius;
                int colMin = (shotCol - j) * (shotCol - j);
                //int colMax = (shotCol + j) * (shotCol + radius);
                int rowMin = (shotRow - i) * (shotRow - i);
                // int rowMax = (shotRow + radius) * (shotRow + radius);
                bool uL = Math.Sqrt(colMin + rowMin) < radius;
                // bool uR = Math.Sqrt(colMax + rowMin) < radius;
                bool dL = Math.Sqrt(colMin + rowMin) < radius;
                // bool dR = Math.Sqrt(colMax + rowMax) < radius;
                if (inRow || inCol || uL || dL)
                {
                    matrix[i, j] = ' ';
                }
            }
        }
        for (int i = 1; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (matrix[i, j] == ' ' && matrix[i - 1, j] != ' ')
                {

                    for (int k = i; k > 0; k--)
                    {
                        matrix[k, j] = matrix[k - 1, j];
                    }
                    matrix[0, j] = ' ';
                }
            }
        }
        Print(matrix);
    }
}

