using System;
using System.Collections.Generic;
using System.Linq;

class LegoBlocks
{
    static void Main()
    {
        int rows = int.Parse(Console.ReadLine());
        List<List<string>> first = new List<List<string>>();
        var second = new List<List<string>>();
        for (int i = 0; i < rows; i++)
        {
            string[] input =(Console.ReadLine().Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
            first.Add(input.ToList());
        }
        for (int i = 0; i < rows; i++)
        {
            string[] input = (Console.ReadLine().Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
            second.Add(input.ToList());
        }
        int count = 0,sum = first[0].Count + second[0].Count;
        int elements = sum;
        for (int i = 1; i < rows; i++)
        {
            elements += first[i].Count + second[i].Count;
            if (first[i].Count + second[i].Count == sum)
            {
                count++;
            }
        }
        if ( count == rows-1)
        {
            for (int i = 0; i < rows; i++)
            {
                Console.Write("[{0}",string.Join(", ",first[i]));
                for (int j = second[i].Count-1; j > 0; j--)
                {
                    Console.Write(", {0}",second[i][j]);
                }
                Console.Write(", "+ second[i][0]);
                Console.WriteLine("]");
            }
        }
        else
        {
            Console.WriteLine("The total number of cells is: {0}",elements);
        }
    }

}

