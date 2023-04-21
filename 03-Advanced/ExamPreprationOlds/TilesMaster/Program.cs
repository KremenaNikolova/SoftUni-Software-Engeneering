using System;
using System.Collections.Generic;
using System.Linq;

namespace TilesMaster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> whiteTiles = new Stack<int>(Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Queue<int> greyTiles = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());

            Dictionary<string, int> counter = new Dictionary<string, int>
            {
                {"Sink", 0},
                {"Oven", 0},
                {"Countertop", 0},
                {"Wall", 0},
                {"Floor",0 },
            };


            while (whiteTiles.Count>0 && greyTiles.Count>0)
            {
                int whiteTile = whiteTiles.Pop();
                int greyTile = greyTiles.Dequeue();

                if (whiteTile==greyTile)
                {
                    int largerTile = whiteTile + greyTile;
                    switch (largerTile)
                    {
                        case 40:
                            counter["Sink"]++;
                            break;
                        case 50:
                            counter["Oven"]++;
                            break;
                        case 60:
                            counter["Countertop"]++;
                            break;
                        case 70:
                            counter["Wall"]++;
                            break;
                        default:
                            counter["Floor"]++;
                            break;
                    }

                }
                else
                {
                    whiteTiles.Push(whiteTile / 2);
                    greyTiles.Enqueue(greyTile);
                }

            }
            string whiteTilesLeft = whiteTiles.Count == 0 ? "none" : string.Join(", ", whiteTiles);
            string greyTilesLeft = greyTiles.Count == 0 ? "none" : string.Join(", ", greyTiles);

            Console.WriteLine($"White tiles left: {whiteTilesLeft}");
            Console.WriteLine($"Grey tiles left: {greyTilesLeft}");

            var finalCounter = counter.Where(x => x.Value > 0).OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToList();

            foreach (var item in finalCounter)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
