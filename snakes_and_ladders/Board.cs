using System.Collections.Generic;
using System.Linq;

namespace snakes_and_ladders {
    public class Board : IBoard {
        private readonly IConsole console;
        private readonly int endSquare;
        private readonly List<ITunnel> tunnels;

        public Board(IConsole console, int endSquare, params ITunnel[] tunnels) {
            this.console = console;
            this.endSquare = endSquare;
            this.tunnels = new List<ITunnel>(tunnels);
        }

        public int CalculateNewPosition(int currentPosition, int diceRoll) {
            int landingSquare = currentPosition + diceRoll;
            List<ITunnel> applicableTunnels = tunnels.Where(tunnel => tunnel.From(landingSquare)).ToList();
            
            if (applicableTunnels.Count > 0)
                return applicableTunnels[0].Destination(console);
            
            console.Print($"You hop along to square {landingSquare}");
            return landingSquare;
        }

        public bool HasWon(int square) {
            return square >= endSquare;
        }
    }
}