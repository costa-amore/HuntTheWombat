using System;
using HuntTheWombat.core;

namespace HuntTheWombat.console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var adventure = new Adventure();
            var hunter = adventure.CreateHunter();

            PrintVisibleMap(adventure.Map);
        }

        private static void PrintVisibleMap(Map map)
        {
            var visibleMap = new string[3, 9];
            //todo: map adventure map.layout to rooms

            visibleMap = Add(visibleMap, 1, 1, Rooms._NSE);
            visibleMap = Add(visibleMap, 2, 1, Rooms.W_SE);
            visibleMap = Add(visibleMap, 3, 1, Rooms.__SW);

            visibleMap = Add(visibleMap, 1, 2, Rooms._N_E);
            visibleMap = Add(visibleMap, 2, 2, Rooms.WNSE);
            visibleMap = Add(visibleMap, 3, 2, Rooms.WNS_);

            visibleMap = Add(visibleMap, 1, 3, Rooms.___E);
            visibleMap = Add(visibleMap, 2, 3, Rooms.WN__);
            visibleMap = Add(visibleMap, 3, 3, Rooms._NS_);

            Print(visibleMap);
            Console.Read();
        }

        private static string[,] Add(string[,] visibleMap, int col, int row, string[] room)
        {
            var c = col - 1;
            var r = 3 * (row - 1) -1;

            visibleMap[c, ++r] = room[0];
            visibleMap[c, ++r] = room[1];
            visibleMap[c, ++r] = room[2];

            return visibleMap;
        }

        private static void Print(string[,] visibleMap)
        {
            for (int r = 0; r < 9; r++)
            {
                var line = string.Empty;
                for (int c = 0; c < 3; c++)
                {
                    line += visibleMap[c, r];
                }
                Console.WriteLine(line);
            }
        }
    }
}
