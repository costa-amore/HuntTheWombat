using System;
using HuntTheWombat.core;

namespace HuntTheWombat.console
{
    class Game
    { 
        internal static void PlayGame()
        {
            string response;
            var adventure = new Adventure();
            var hunter = adventure.CreateHunter();

            do
            {
                PrintMap(adventure);
                Console.Write("In what direction do you want to move [N]orth, [E]ast, [S]outh, [W]est ([I]ntro / E[x]it): ");
                response = GetPlayerResponse();

                if (response == "I")
                {
                    PrintIntro();
                    Console.Write("Continue Game ([Y]es / E[x]it): ");
                    response = GetPlayerResponse();
                    if (response != "X") response = "Y";
                }
                else
                {
                    switch (response)
                    {
                        case "N": adventure.HunterMovesThrough(Passage.North); break;
                        case "S": adventure.HunterMovesThrough(Passage.South); break;
                        case "E": adventure.HunterMovesThrough(Passage.East); break;
                        case "W": adventure.HunterMovesThrough(Passage.West); break;
                    }
                }
            } while (response != "X");
        }

        internal static string GetPlayerResponse()
        {
            string response = Console.ReadKey().KeyChar.ToString().ToUpper();
            Console.WriteLine();

            return response;
        }

        internal static void PrintIntro()
        {
            Console.WriteLine("Hunt The wombat!");
            Console.WriteLine("----------------");
            Console.WriteLine("Game purpose: The hunter needs to search the labyrinth for the Wombat and bring it back to safety.");
            Console.WriteLine("");
            Console.WriteLine("Labyrinth legenda:");
            Console.WriteLine(" 'H' indicates where the hunter is           (when not carrying the wombat)");
            Console.WriteLine(" 'M' indicates a room with a monster         (Hunter will lose a life in the fight)");
            Console.WriteLine(" 'P' indicates a room with a healing-Potion  (Hunter will gain a life, then the potion is spent");
            Console.WriteLine(" 'W' indicates a room where the wombat is    (Hunter will now be carrying the Wombat)");
            Console.WriteLine("");
        }

        #region private parts
        private static void PrintMap(Adventure adventure)
        {
            Console.WriteLine("Hunter life : " + adventure.HunterLife);
            Console.WriteLine("---------------------------------------------------------------------------");

            PrintVisibleMap(adventure.Map);

            Console.WriteLine("---------------------------------------------------------------------------");
        }

        private static void PrintVisibleMap(Map map)
        {
            var visibleMap = new string[3, 3 * Rooms.RoomTemplateRowSize];

            //todo: map adventure map.layout to rooms

            visibleMap = Add(visibleMap, 1, 1, Rooms._NSE_room);
            visibleMap = Add(visibleMap, 2, 1, Rooms.W_SE_room);
            visibleMap = Add(visibleMap, 3, 1, Rooms.W_S__room);

            visibleMap = Add(visibleMap, 1, 2, Rooms._N_E_hall);
            visibleMap = Add(visibleMap, 2, 2, Rooms.WNSE_room);
            visibleMap = Add(visibleMap, 3, 2, Rooms.WNS__room);

            visibleMap = Add(visibleMap, 1, 3, Rooms.___E_room);
            visibleMap = Add(visibleMap, 2, 3, Rooms.WN___room);
            visibleMap = Add(visibleMap, 3, 3, Rooms._NS__hall);

            var hunter = "H";
            visibleMap = Add(visibleMap, 2, 2, hunter);

            Print(visibleMap);
        }

        private static string[,] Add(string[,] visibleMap, int col, int row, string roomContent)
        {
            var centerRoomLine = visibleMap[col-1, 13];

            centerRoomLine = centerRoomLine.Substring(0, 12) + roomContent + centerRoomLine.Substring(13);

            visibleMap[col-1, 13] = centerRoomLine;

            return visibleMap;
        }

        private static string[,] Add(string[,] visibleMap, int col, int row, string[] room)
        {
            var c = col - 1;
            var r = 9  * (row - 1) -1;

            visibleMap[c, ++r] = room[0];
            visibleMap[c, ++r] = room[1];
            visibleMap[c, ++r] = room[2];
            visibleMap[c, ++r] = room[3];
            visibleMap[c, ++r] = room[4];
            visibleMap[c, ++r] = room[5];
            visibleMap[c, ++r] = room[6];
            visibleMap[c, ++r] = room[7];
            visibleMap[c, ++r] = room[8];

            return visibleMap;
        }

        private static void Print(string[,] visibleMap)
        {
            for (int r = 0; r < 3 * Rooms.RoomTemplateRowSize; r++)
            {
                var line = string.Empty;
                for (int c = 0; c < 3; c++)
                {
                    line += visibleMap[c, r];
                }
                Console.WriteLine(line);
            }
        }
        #endregion
    }
}
