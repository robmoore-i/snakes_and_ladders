using System;

namespace snakes_and_ladders {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Snakes & Ladders");
            IConsole console = new CommandLineConsole();
            Board board = new Board(console, 30,
                new Ladder(3, 22),
                new Ladder(5, 8),
                new Ladder(11, 26),
                new Ladder(20, 29),
                new Snake(17, 4),
                new Snake(19, 7),
                new Snake(21, 9),
                new Snake(27, 1)
            );
            GameSetup gameSetup = new GameSetup(console, board, new Dice());
            Game game = gameSetup.CreateGame();
            game.Start();
        }
    }
}