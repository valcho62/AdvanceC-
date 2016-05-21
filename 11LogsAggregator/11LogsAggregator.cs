using System;
using System.Collections.Generic;
using System.Linq;

class LogsAggregator
{
    static void Main()
    {
        int lines = int.Parse(Console.ReadLine());
        var logs = new SortedDictionary<string, SortedSet<string>>();
        var userDura = new Dictionary<string, int>();
        for (int i = 0; i < lines; i++)
        {
            string[] input = Console.ReadLine().Split(' ');
            string user = input[1];
            string ipAdress = input[0];
            int duration = int.Parse(input[2]);
            if (! logs.ContainsKey(user))
            {
                logs.Add(user, new SortedSet<string>());
                userDura.Add(user, 0);
            }

            logs[user].Add(ipAdress);
            userDura[user] += duration;
        }
        foreach (var user in logs)
        {
            int count = 0, countIP = user.Value.Count;
            Console.Write("{0}: {1} [",user.Key,userDura[user.Key]);
            foreach (var ipadress in user.Value)
            {
                count++;
                if(count < countIP)
                {
                    Console.Write("{0}, ",ipadress);
                }
                else
                {
                    Console.Write("{0}]", ipadress);
                }
            }
            Console.WriteLine();
        }
    }
}

