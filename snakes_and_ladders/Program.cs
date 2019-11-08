using System;

namespace snakes_and_ladders {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Snakes & Ladders");
            IConsole console = new CommandLineConsole();
            Board board = new Board(console, 100);
            GameSetup gameSetup = new GameSetup(console, board, new Dice());
            Game game = gameSetup.CreateGame();
            game.Start();
        }
    }
}
