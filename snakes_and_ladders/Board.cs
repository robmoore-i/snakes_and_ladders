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
            List<ITunnel> applicableLadders = tunnels.Where(tunnel => tunnel.From(landingSquare)).ToList();
            return applicableLadders.Count > 0 ? applicableLadders[0].Destination() : landingSquare;
        }
    }
}