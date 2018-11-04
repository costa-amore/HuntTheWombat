using System;

namespace HuntTheWombat.console
{
    class Program
    {
        static void Main(string[] args)
        {
            Game.PrintIntro();
            Console.Write("Play Game ([Y]es/[N]o): ");
            var response = Game.GetPlayerResponse();

            if (response != "Y") return;

            Game.PlayGame();
        }
    }
}
