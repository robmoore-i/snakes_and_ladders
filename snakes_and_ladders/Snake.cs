namespace snakes_and_ladders {
    public class Snake : ITunnel {
        private readonly int source;
        private readonly int destination;

        public Snake(int source, int destination) {
            this.source = source;
            this.destination = destination;
        }


        public bool From(int square) {
            return source == square;
        }

        public int Destination(IConsole console) {
            console.Print($"You slide down a snake and plummet to square {destination}");
            return destination;
        }
    }
}