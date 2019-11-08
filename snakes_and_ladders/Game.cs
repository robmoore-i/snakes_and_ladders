using System;
using System.Collections.Generic;
using System.Linq;

namespace test {
    public class Game {
        public readonly int numberOfPlayers;
        public readonly List<string> playerNames;

        private readonly IConsole console;

        public Game(IConsole console) {
            this.console = console;
            this.console.Print("How many players?");
            string consoleInput;
            consoleInput = this.console.Read();
            numberOfPlayers = Convert.ToInt32(consoleInput);
            this.console.Print("What are their names? (comma separated)");
            consoleInput = this.console.Read();
            playerNames = consoleInput.Split(",").ToList<string>();
        }

        public void Start() {

        }
    }
}