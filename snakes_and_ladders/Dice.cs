using System;

namespace snakes_and_ladders {
    public class Dice : IDice {
        private readonly Random random = new Random();

        public int Roll() {
            return random.Next(1, 6);
        }
    }
}