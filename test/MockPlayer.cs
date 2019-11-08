using NUnit.Framework;
using snakes_and_ladders;

namespace test {
    public class MockPlayer : IPlayer {
        private readonly string name;
        private int turnsUntilWin;
        private int turnTakenCallCount;
        
        public MockPlayer() : this(100) {
        }

        public MockPlayer(int turnsUntilWin, string name = "Mo the Mock") {
            this.turnsUntilWin = turnsUntilWin;
            this.name = name;
        }

        public string Name() {
            return name;
        }

        public bool TakeTurn(IConsole console) {
            turnTakenCallCount += 1;
            turnsUntilWin -= 1;
            return turnsUntilWin == 0;
        }

        public void AssertTurnTaken() {
            Assert.Greater(turnTakenCallCount, 0);
        }

        public void AssertTurnTakenTwice() {
            Assert.AreEqual(2, turnTakenCallCount);
        }
    }
}