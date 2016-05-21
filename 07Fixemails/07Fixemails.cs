using System;
using System.Collections.Generic;
using System.Linq;

class Aminertask
{
    static void Main()
    {
        string input = Console.ReadLine();
        int k = 0;
        var resources = new Dictionary<string, string>();
        string name = "",emails = "";
        while (input != "stop")
        {
            k++;
            if (k % 2 != 0)
            {
                name = input;
            }
            else
            {
                emails = input;
                if (emails.Substring(emails.Length -2) != "uk" && emails.Substring(emails.Length - 2) != "us")
                {
                    if (!resources.ContainsKey(name))
                    {
                        resources.Add(name, string.Empty);
                    }
                    resources[name] = emails; 
                }
            }
            input = Console.ReadLine();
        }
        foreach (var item in resources)
        {
            Console.WriteLine("{0} -> {1}", item.Key, item.Value);
        }
    }
}


