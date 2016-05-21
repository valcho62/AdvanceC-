using System;
using System.Collections.Generic;
using System.Linq;

class PopulationCounter
{
    static void Main()
    {
        var population = new Dictionary<string, Dictionary<string, int>>();
        var countryPop = new Dictionary<string, ulong>();
        string[] input = Console.ReadLine().Split('|');
        while (input[0] != "report")
        {
            string country = input[1];
            string city = input[0];
            int popul = int.Parse(input[2]);
            if (!population.ContainsKey(country))
            {
                population.Add(country, new Dictionary<string, int>());
                countryPop.Add(country, 0);
            }
            if (!population[country].ContainsKey(city))
            {
                population[country].Add(city, 0);
            }
            population[country][city] = popul;
            countryPop[country] += (ulong)popul;
            input = Console.ReadLine().Split('|');
        }
        var countries = from s in population
                   orderby countryPop[s.Key] descending
                   select s;
        foreach (var country in countries)
        {
            Console.WriteLine("{0} (total population: {1})",country.Key,countryPop[country.Key]);
            var city = from s in country.Value
                            orderby s.Value descending
                            select s;
            foreach (var item in city)
            {
                Console.WriteLine("=>{0}: {1}",item.Key,item.Value);
            }
        }
    }
}

