using System;
using System.Collections.Generic;
using System.Linq;

class LegendaryFarming
{
    static void Main()
    {
        var junk = new SortedDictionary<string, int>();
        var keyMat = new SortedDictionary<string, int>();
        string[] input = Console.ReadLine().ToLower().Split(' ');
        keyMat.Add("fragments", 0);
        keyMat.Add("shards", 0);
        keyMat.Add("motes", 0);
        while (true)
        {
            
            for (int i = 0; i < input.Length-1; i+=2)
            {
                int quantity = int.Parse(input[i]);
                string mater = input[i + 1];
                if(mater == "fragments" || mater == "shards" || mater == "motes")
                {
                    
                    keyMat[mater] += quantity;
                    if (keyMat[mater] >= 250)
                    {
                        switch (mater)
                        {
                            case "fragments": Console.WriteLine("Valanyr obtained!"); break;
                            case "shards": Console.WriteLine("Shadowmourne obtained!"); break;
                            case "motes": Console.WriteLine("Dragonwrath obtained!"); break;

                        }
                        keyMat[mater] -= 250;
                        var mat = from s in keyMat
                                  orderby s.Value descending
                                  select s;
                        foreach (var item in mat)
                        {
                            Console.WriteLine("{0}: {1}", item.Key, item.Value);
                        }
                        foreach (var item in junk)
                        {
                            Console.WriteLine("{0}: {1}", item.Key, item.Value);
                        }
                        return;
                    }
                }
                else
                {
                    if (!junk.ContainsKey(mater))
                    {
                        junk.Add(mater, 0);
                    }
                    junk[mater] += quantity;
                }
               
            }
            input = Console.ReadLine().ToLower().Split(' ');
        }
    }
}

