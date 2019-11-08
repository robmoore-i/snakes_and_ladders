using System.Collections.Generic;
using NUnit.Framework;
using snakes_and_ladders;

namespace test {
    public class GameSetupTest {
        [Test]
        public void ItAsksForThePlayerNames() {
            MockPrinter mockPrinter = new MockPrinter(new List<string>(new[] {"Manoj,Ryan"}));
            GameSetup gameSetup = new GameSetup(mockPrinter);
            Game _ = gameSetup.CreateGame();
            mockPrinter.AssertTextWasPrinted("Who is playing? (comma separated names)");
        }

        [Test]
        public void ItReadsThePlayerNamesFromTheConsole() {
            MockPrinter mockPrinter = new MockPrinter(new List<string>(new[] {"Manoj,Ryan"}));
            GameSetup gameSetup = new GameSetup(mockPrinter);
            Game game = gameSetup.CreateGame();
            CollectionAssert.AreEqual(new List<string>(new[] {"Manoj", "Ryan"}), game.PlayerNames());
        }

        [Test]
        public void IfNoPlayersAreListedItAsksYouToTryAgain() {
            MockPrinter mockPrinter = new MockPrinter(new List<string>(new[] {"", "Manoj,Ryan"}));
            GameSetup gameSetup = new GameSetup(mockPrinter);
            Game _ = gameSetup.CreateGame();
            mockPrinter.AssertTextWasPrinted("Who is playing? (comma separated names) [for example \"Emese,Hashim\"]");
        }

        [Test]
        public void IfOnlyOnePlayerIsListedItAsksYouToTryAgain() {
            MockPrinter mockPrinter = new MockPrinter(new List<string>(new[] {"Rob", "Rob, Anna"}));
            GameSetup gameSetup = new GameSetup(mockPrinter);
            Game _ = gameSetup.CreateGame();
            mockPrinter.AssertTextWasPrinted("Who is playing? (comma separated names) [for example \"Emese,Hashim\"]");
        }

        [Test]
        public void ItTrimsSpacesAroundPlayerNames() {
            MockPrinter mockPrinter = new MockPrinter(new List<string>(new[] {"Manoj, Ryan, Seda"}));
            GameSetup gameSetup = new GameSetup(mockPrinter);
            Game game = gameSetup.CreateGame();
            CollectionAssert.AreEqual(new List<string>(new[] {"Manoj", "Ryan", "Seda"}), game.PlayerNames());
        }
    }
}