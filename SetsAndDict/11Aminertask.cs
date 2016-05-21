using System;
using System.Collections.Generic;
using System.Linq;

class Aminertask
{
    static void Main()
    {
        string input = Console.ReadLine();
        int k = 0, quantity = 0;
        var resources = new Dictionary<string, int>();
        string name = "";
        while (input != "stop")
        {
            k++;
            if (k % 2 != 0)
            {
                name = input;
            }
            else
            {
                quantity = int.Parse(input);
                if (!resources.ContainsKey(name))
                {
                    resources.Add(name, 0);
                }
                resources[name] += quantity;
            }
            input = Console.ReadLine();
        }
        foreach (var item in resources)
        {
            Console.WriteLine("{0} -> {1}",item.Key,item.Value);
        }
    }
}

