using NUnit.Framework;
using snakes_and_ladders;

namespace test {
    public class MockPlayer : IPlayer {
        private readonly bool won;
        private bool turnWasTaken;

        public MockPlayer() : this(false) {
        }
        
        public MockPlayer(bool won) {
            this.won = won;
        }

        public string Name() {
            return "Mo the Mock";
        }

        public bool TakeTurn(IConsole console) {
            turnWasTaken = true;
            return won;
        }

        public void AssertTurnTaken() {
            Assert.True(turnWasTaken);
        }
    }
}