using System.Collections.Generic;
using System.Linq;

namespace snakes_and_ladders {
    public class Game {
        public readonly int numberOfPlayers;

        private readonly List<IPlayer> players;
        private readonly IConsole console;

        public Game(IConsole console, List<IPlayer> players) {
            this.console = console;
            this.players = players;
            numberOfPlayers = this.players.Count;
        }

        public List<string> PlayerNames() {
            return players.Select(player => player.Name()).ToList();
        }

        public void Start() {
            SnakesAndLaddersBoard board = new SnakesAndLaddersBoard();
            players[0].TakeTurn(console, board);
        }
    }
}