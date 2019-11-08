using System.Collections.Generic;
using System.Linq;

namespace snakes_and_ladders {
    public class Board : IBoard {
        private readonly List<ITunnel> tunnels;

        public Board(params ITunnel[] ladders) {
            tunnels = new List<ITunnel>(ladders);
        }

        public int CalculateNewPosition(int currentPosition, int diceRoll) {
            int landingSquare = currentPosition + diceRoll;
            List<ITunnel> applicableTunnels = tunnels.Where(tunnel => tunnel.From(landingSquare)).ToList();
            return applicableTunnels.Count > 0 ? applicableTunnels[0].Destination() : landingSquare;
        }
    }
}