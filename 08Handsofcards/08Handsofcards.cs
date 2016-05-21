using System;
using System.Collections.Generic;
using System.Linq;

class Handsofcards
{
    public static int cardsValue(string card)
    {
        switch (card[0])
        {
            case 'J': return 11; 
            case 'Q': return 12; 
            case 'K': return 13; 
            case 'A': return 14; 
            case '1': return 10; 

        }
        return (int)card[0] - 48;
    }
    public static int colorValue(string color)
    {
        switch (color[color.Length-1])
        {
            case 'S': return 4; 
            case 'H': return 3; 
            case 'D': return 2; 
            case 'C': return 1;        

        }
        return 1;
    }
    static void Main()
    {
        string[] input = Console.ReadLine().Split(':');
        var hands = new Dictionary<string, HashSet<string>>();

        while (input[0] != "JOKER")
        {
            string name = input[0];
            string[] cards = input[1].Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (!hands.ContainsKey(name))
            {
                hands.Add(name, new HashSet<string>());
            }
            for (int i = 0; i < cards.Length; i++)
            {
                hands[name].Add(cards[i]);
            }
            input = Console.ReadLine().Split(':');
        }
        int value = 0;
        foreach (var names in hands)
        {
            foreach (var val in names.Value)
            {
                value += cardsValue(val) * colorValue(val);
            }
            Console.WriteLine("{0}: {1}",names.Key,value);
            value = 0;
        }
    }
}

