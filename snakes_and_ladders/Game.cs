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

        public IEnumerable<string> PlayerNames() {
            return players.Select(player => player.Name()).ToList();
        }

        public void Start() {
            int currentPlayer = 0;
            while (!players[currentPlayer].TakeTurn(console)) {
                currentPlayer += 1;
            }
            console.Print($"We have a winner! Congratulations, {players[currentPlayer].Name()}!");
        }
    }
}