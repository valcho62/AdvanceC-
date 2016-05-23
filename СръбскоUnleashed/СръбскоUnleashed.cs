using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class СръбскоUnleashed
{
    static void Main()
    {
        string pat = @"^([a-zA-Z]+\s*[a-zA-Z]+\s*[a-zA-Z]+)\s@([a-zA-Z]+\s*[a-zA-Z]+\s*[a-zA-Z]+)\s(\d+)\s+(\d+)$";
        string input = Console.ReadLine();
        var singerBase = new Dictionary<string, Dictionary<string, uint>>();
        while (input != "End")
        {
            Match match = Regex.Match(input, pat);
            if (match.Success)
            {
                var singer = match.Groups[1].Value;
                var venue = match.Groups[2].Value;
                var ticketPrice = int.Parse(match.Groups[3].Value);
                var ticketCount = int.Parse(match.Groups[4].Value);
                if (! singerBase.ContainsKey(venue))
                {
                    singerBase.Add(venue, new Dictionary<string, uint>());
                }
                if (! singerBase[venue].ContainsKey(singer))
                {
                    singerBase[venue].Add(singer, 0);
                }
                singerBase[venue][singer] += (uint) ticketCount * (uint) ticketPrice;
            }
            input = Console.ReadLine();
        }
        foreach (var venue in singerBase)
        {
            Console.WriteLine(venue.Key);
            
                var profit = from s in venue.Value
                             orderby s.Value descending
                             select s;
            foreach (var item in profit)
            {
                Console.WriteLine("#  {0} -> {1}",item.Key,item.Value);
            }
            
        }
    }
}

