using System.Collections.Generic;
using NUnit.Framework;
using snakes_and_ladders;

namespace test {
    public class PlayerTest {
        [Test]
        public void AsksThePlayerToRollTheDice() {
            Player player = new Player("Manoj");
            MockConsole mockConsole = new MockConsole(new List<string>(new string[] { }));
            player.TakeTurn(mockConsole);
            mockConsole.AssertTextWasPrinted("Manoj, press enter to roll the dice.");
        }
    }
}