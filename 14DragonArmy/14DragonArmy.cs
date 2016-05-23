using System;
using System.Collections.Generic;
using System.Linq;

class DragonArmy
{
    static void Main()
    {
        int lines = int.Parse(Console.ReadLine());
        var dragons = new Dictionary<string, SortedDictionary<string, List<int>>>();
        for (int i = 0; i < lines; i++)
        {
            string[] input = Console.ReadLine().Split(' ');
            string type = input[0];
            string name = input[1];
            int damage = (input[2] == "null") ? 45:int.Parse(input[2]);
            int health = (input[3] == "null") ? 250 : int.Parse(input[3]);
            int armor = (input[4] == "null") ? 10 : int.Parse(input[4]);
            if (!dragons.ContainsKey(type))
            {
                dragons.Add(type, new SortedDictionary<string, List<int>>());
            }
            if (! dragons[type].ContainsKey(name))
            {
                dragons[type].Add(name, new List<int>());
            }
            dragons[type][name].Clear();
            dragons[type][name].Add(damage);
            dragons[type][name].Add(health);
            dragons[type][name].Add(armor);
        }
        foreach (var type in dragons)
        {
            int sumDamage = 0, sumHealth = 0, sumArmor = 0;
            Console.Write("{0}::(",type.Key);
            foreach (var name in type.Value)
            {
                sumDamage += name.Value[0];
                sumHealth += name.Value[1];
                sumArmor += name.Value[2];
            }
            Console.WriteLine("{0:f2}/{1:f2}/{2:f2})",sumDamage*1.0/type.Value.Count, sumHealth*1.0 / type.Value.Count, sumArmor*1.0 / type.Value.Count);
            foreach (var name in type.Value)
            {
                Console.WriteLine("-{0} -> damage: {1}, health: {2}, armor: {3}",name.Key,name.Value[0],name.Value[1],name.Value[2]);
            }
        }
    }
}

