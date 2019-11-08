﻿using System.Collections.Generic;
using System.Linq;

namespace snakes_and_ladders {
    public class Game {
        public readonly int numberOfPlayers;
        public readonly List<string> playerNames;

        private readonly IConsole console;

        public Game(IConsole console) {
            this.console = console;
            this.console.Print("Who is playing? (comma separated names)");
            string consoleInput = this.console.Read();
            while (consoleInput == "" || !consoleInput.Contains(",")) {
                this.console.Print("Who is playing? (comma separated names) [for example \"Emese,Hashim\"]");
                consoleInput = this.console.Read();
            }
            playerNames = consoleInput.Split(",").Select(name => name.Trim()).ToList();
            numberOfPlayers = playerNames.Count;
        }

        public Game(IConsole console, List<Player> players) {
            this.console = console;
            playerNames = players.Select(player => player.name).ToList();
            numberOfPlayers = playerNames.Count;
        }

        public void Start() {
            string firstPlayer = playerNames[0];
            console.Print(firstPlayer + ", press enter to roll the dice.");
        }
    }
}