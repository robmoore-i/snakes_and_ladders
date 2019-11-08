using NUnit.Framework;
using snakes_and_ladders;

namespace test {
    public class MockPlayer : IPlayer {
        private bool turnWasTaken;

        public string Name() {
            return "Mo the Mock";
        }

        public bool TakeTurn(IConsole console) {
            turnWasTaken = true;
            return false;
        }

        public void AssertTurnTaken() {
            Assert.True(turnWasTaken);
        }
    }
}