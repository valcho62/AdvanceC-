using System;
using System.Collections.Generic;
using System.Linq;

class Crossfire
{
    public static void Print ( List<List<int>> matrix)
    {
        for (int i = 0; i < matrix.Count; i++)
        {            
            for (int j = 0; j < matrix[i].Count-1; j++)
            {
                Console.Write(matrix[i][j] +" ");
            }
            Console.Write(matrix[i][matrix[i].Count-1]);
            Console.WriteLine();
            
        }
    }
    static void Main()
    {
        string[] size = Console.ReadLine().Split(' ');
        int rows = int.Parse(size[0]);
        int cols = int.Parse(size[1]);
        var matrix = new List<List<int>>();
        int filler = 0;
        for (int i = 0; i < rows; i++)
        {
            var temp = new List<int>();
            for (int j = 0; j < cols; j++)
            {
                filler++;
                temp.Add(filler);
            }
            matrix.Add(new List<int>(temp));
        }
        string[] input = Console.ReadLine().Split(' ');
        while (input[0] != "Nuke")
        {
            int shotRow = int.Parse(input[0]);
            int shotCol = int.Parse(input[1]);
            int radius = int.Parse(input[2]);
            uint sum = (uint)shotRow + (uint)radius;
            uint sum1 = (uint)shotCol + (uint)radius;
            for (int i = Math.Max(0,shotRow-radius); i <= Math.Min(sum,matrix.Count-1); i++)
            {
                for (int j = Math.Max(0, shotCol - radius); j <= Math.Min(sum1, matrix[i].Count-1); j++)
                {
                    if (i == shotRow || j == shotCol)
                    {
                        matrix[i][j] = 0;   
                    }
                }                
            }
           

            for (int i = matrix.Count-1; i >=0; i--)
            {
                //matrix[i].RemoveAll(x => x==0);
                for (int j = matrix[i].Count-1; j >=0; j--)
                {
                    if ( matrix[i][j] == 0)
                    {
                        matrix[i].RemoveAt(j);
                    }
                    
                }
                if (matrix[i].Count == 0)
                {
                    matrix.Remove(matrix[i]);
                }
            }
            

            input = Console.ReadLine().Split(' ');
        }
        Print(matrix);
    }
}

