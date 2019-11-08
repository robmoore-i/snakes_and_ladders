using System.Collections.Generic;
using NUnit.Framework;
using snakes_and_ladders;

namespace test {
    public class GameSetupTest {
        [Test]
        public void ItAsksForThePlayerNames() {
            MockConsole mockConsole = new MockConsole(new List<string>(new[] {"Manoj,Ryan"}));
            GameSetup gameSetup = new GameSetup(mockConsole);
            Game _ = gameSetup.CreateGame();
            mockConsole.AssertTextWasPrinted("Who is playing? (comma separated names)");
        }

        [Test]
        public void ItReadsThePlayerNamesFromTheConsole() {
            MockConsole mockConsole = new MockConsole(new List<string>(new[] {"Manoj,Ryan"}));
            GameSetup gameSetup = new GameSetup(mockConsole);
            Game game = gameSetup.CreateGame();
            CollectionAssert.AreEqual(new List<string>(new[] {"Manoj", "Ryan"}), game.PlayerNames());
        }

        [Test]
        public void IfNoPlayersAreListedItAsksYouToTryAgain() {
            MockConsole mockConsole = new MockConsole(new List<string>(new[] {"", "Manoj,Ryan"}));
            GameSetup gameSetup = new GameSetup(mockConsole);
            Game _ = gameSetup.CreateGame();
            mockConsole.AssertTextWasPrinted("Who is playing? (comma separated names) [for example \"Emese,Hashim\"]");
        }

        [Test]
        public void IfOnlyOnePlayerIsListedItAsksYouToTryAgain() {
            MockConsole mockConsole = new MockConsole(new List<string>(new[] {"Rob", "Rob, Anna"}));
            GameSetup gameSetup = new GameSetup(mockConsole);
            Game _ = gameSetup.CreateGame();
            mockConsole.AssertTextWasPrinted("Who is playing? (comma separated names) [for example \"Emese,Hashim\"]");
        }

        [Test]
        public void ItTrimsSpacesAroundPlayerNames() {
            MockConsole mockConsole = new MockConsole(new List<string>(new[] {"Manoj, Ryan, Seda"}));
            GameSetup gameSetup = new GameSetup(mockConsole);
            Game game = gameSetup.CreateGame();
            CollectionAssert.AreEqual(new List<string>(new[] {"Manoj", "Ryan", "Seda"}), game.PlayerNames());
        }
    }
}