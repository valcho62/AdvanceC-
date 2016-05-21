using System;
using System.Collections.Generic;
using System.Linq;

class UserLogs
{
    static void Main()
    {
        var ipLogs = new SortedDictionary<string, Dictionary<string, int>>();
        string[] input = Console.ReadLine().Split(' ');
        while (input[0] != "end")
        {
            string[] user = input[2].Split('=');
            string[] ipAdress = input[0].Split('=');
            if (!ipLogs.ContainsKey(user[1]))
            {
                ipLogs.Add(user[1], new Dictionary<string, int>());
            }
            if (!ipLogs[user[1]].ContainsKey(ipAdress[1]))
            {
                ipLogs[user[1]].Add(ipAdress[1], 0);
            }
            ipLogs[user[1]][ipAdress[1]]++;
            input = Console.ReadLine().Split(' ');
        }
        foreach (var names in ipLogs)
        {
            Console.WriteLine("{0}:",names.Key);
            int count = 0,valueSize = names.Value.Count;
            foreach (var item in names.Value)
            {
                count++;
                if (count == valueSize)
                {
                    Console.WriteLine("{0} => {1}.",item.Key,item.Value); 
                }
                else
                {
                    Console.Write("{0} => {1}, ", item.Key, item.Value);
                }
            }
        }
    }
}

