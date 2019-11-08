using snakes_and_ladders;

namespace test {
    internal class MockDice : IDice {
        private readonly int roll;

        public MockDice(int roll) {
            this.roll = roll;
        }

        public MockDice() : this(1) { }

        public int Roll() {
            return roll;
        }
    }
}