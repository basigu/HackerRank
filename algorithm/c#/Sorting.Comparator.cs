using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/*
 Given an array of  Player objects, write a comparator that sorts them in order of 
 decreasing score; if  or more players have the same score, sort those players alphabetically by name. 
 To do this, you must create a Checker class that implements the Comparator interface, 
 then write an int compare(Player a, Player b) method implementing the Comparator.compare(T o1, T o2) method.
 */

class Solution {
     static void Main(string[] args)
        {
            var players = new List<Player>
            {
                new Player {Name = "amy", Score = 100},
                new Player {Name = "david", Score = 100},
                new Player {Name = "heraldo", Score = 50},
                new Player {Name = "aakansha", Score = 75},
                new Player {Name = "aleksa", Score = 150},
            };
            players.Sort(new PlayerComparer(SortingOrder.Decending));

            foreach (var player in players)
            {
                Console.WriteLine($"{player.Name} {player.Score}");
            }
        }
}

public class Player : IComparable
{
    public string Name { get; set; }
    public int Score { get; set; }
    public int CompareTo(object obj)
    {
        if(!(obj is Player otherPlayer))
            throw new Exception("Invalid Player");
        var value = string.CompareOrdinal(Name, otherPlayer.Name);
        return value != 0 ? value : Score.CompareTo(otherPlayer.Score);
    }
}

public enum SortingOrder
{
    Ascending,
    Decending
}

public class PlayerComparer : IComparer<Player>
{
    private readonly int _orderValue = 1;
    public PlayerComparer(SortingOrder sortingOrder)
    {
        _orderValue = sortingOrder == SortingOrder.Decending ? -1 : 1;

    }
    public int Compare(Player x, Player y)
    {
        var value = x.Score.CompareTo(y.Score) * _orderValue;

        if (value == 0)
        {
            value = String.Compare(x.Name, y.Name, StringComparison.Ordinal);
        }
        return value;
    }
}



