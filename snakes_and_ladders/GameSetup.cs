using System.Collections.Generic;
using System.Linq;

namespace snakes_and_ladders {
    public class GameSetup {
        private readonly IConsole console;

        public GameSetup(IConsole console) {
            this.console = console;
        }

        public Game CreateGame() {
            console.Print("Who is playing? (comma separated names)");
            string consoleInput = console.Read();
            while (consoleInput == "" || !consoleInput.Contains(",")) {
                console.Print("Who is playing? (comma separated names) [for example \"Emese,Hashim\"]");
                consoleInput = console.Read();
            }
            List<Player> players = consoleInput.Split(",").Select(name => new Player(name.Trim())).ToList();
            return new Game(console, players);
        }
    }
}