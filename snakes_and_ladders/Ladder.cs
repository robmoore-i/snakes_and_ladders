namespace snakes_and_ladders {
    public class Ladder : ITunnel {
        private readonly int source;
        private readonly int destination;

        public Ladder(int source, int destination) {
            this.source = source;
            this.destination = destination;
        }

        public bool From(int square) {
            return source == square;
        }

        public int Destination(IConsole console) {
            console.Print($"You climb up a ladder and ascend to square {destination}");
            return destination;
        }
    }
}