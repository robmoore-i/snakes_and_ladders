using NUnit.Framework;
using snakes_and_ladders;

namespace test {
    public class MockPlayer : IPlayer {
        private readonly bool won;
        private readonly string name;
        private bool turnWasTaken;
        
        public MockPlayer() : this(false) {
        }

        public MockPlayer(bool won, string name = "Mo the Mock") {
            this.won = won;
            this.name = name;
        }

        public string Name() {
            return name;
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