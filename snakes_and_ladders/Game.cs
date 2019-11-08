using System.Collections.Generic;
using System.Linq;

namespace snakes_and_ladders {
    public class Game {
        public readonly int numberOfPlayers;

        private readonly List<Player> players;
        private readonly IConsole console;

        public Game(IConsole console, List<Player> players) {
            this.console = console;
            this.players = players;
            numberOfPlayers = this.players.Count;
        }

        public void Start() {
            string firstPlayerName = players[0].name;
            console.Print(firstPlayerName + ", press enter to roll the dice.");
        }

        public List<string> PlayerNames() {
            return players.Select(player => player.name).ToList();
        }
    }
}