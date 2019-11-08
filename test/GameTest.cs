using System.Collections.Generic;
using NUnit.Framework;
using snakes_and_ladders;

namespace test {
    public class GameTest {
        [Test]
        public void ItAsksForThePlayersNames() {
            MockPrinter mockPrinter = new MockPrinter(new List<string>(new[] {"Manoj,Ryan"}));
            Game _ = new Game(mockPrinter);
            mockPrinter.AssertTextWasPrinted("Who is playing? (comma separated names)");
        }

        [Test]
        public void ItReadsThePlayerNamesFromTheConsole() {
            MockPrinter mockPrinter = new MockPrinter(new List<string>(new[] {"Manoj,Ryan"}));
            Game game = new Game(mockPrinter);
            CollectionAssert.AreEqual(new List<string>(new[] {"Manoj", "Ryan"}), game.playerNames);
        }

        [Test]
        public void IfNoPlayersAreListedItAsksYouToTryAgain() {
            MockPrinter mockPrinter = new MockPrinter(new List<string>(new[] {"", "Manoj,Ryan"}));
            Game _ = new Game(mockPrinter);
            mockPrinter.AssertTextWasPrinted("Who is playing? (comma separated names) [for example \"Emese,Hashim\"]");
        }

        [Test]
        public void IfOnlyOnePlayerIsListedItAsksYouToTryAgain() {
            MockPrinter mockPrinter = new MockPrinter(new List<string>(new[] {"Rob", "Rob, Anna"}));
            Game _ = new Game(mockPrinter);
            mockPrinter.AssertTextWasPrinted("Who is playing? (comma separated names) [for example \"Emese,Hashim\"]");
        }

        [Test]
        public void ItTrimsSpacesAroundPlayerNames() {
            MockPrinter mockPrinter = new MockPrinter(new List<string>(new[] {"Manoj, Ryan, Seda"}));
            Game game = new Game(mockPrinter);
            CollectionAssert.AreEqual(new List<string>(new[] {"Manoj", "Ryan", "Seda"}), game.playerNames);
        }

        [Test]
        public void ItGetsTheNumberOfPlayers() {
            MockPrinter mockPrinter = new MockPrinter(new List<string>(new[] {"Manoj,Ryan"}));
            Game game = new Game(mockPrinter);
            Assert.AreEqual(2, game.numberOfPlayers);
        }

        [Test]
        public void CanInitialiseTheGameWithPlayerNamesDirectly() {
            List<string> playerNames = new List<string>(new[] {"Manoj", "Ryan"});
            MockPrinter mockPrinter = new MockPrinter(new List<string>(new string[] { }));
            Game game = new Game(mockPrinter, playerNames);
            CollectionAssert.AreEqual(playerNames, game.playerNames);
            Assert.AreEqual(2, game.numberOfPlayers);
        }

        [Test]
        public void ItAsksTheFirstPlayerToRollTheDice() {
            List<string> playerNames = new List<string>(new[] {"Manoj", "Ryan"});
            MockPrinter mockPrinter = new MockPrinter(new List<string>(new string[] { }));
            Game game = new Game(mockPrinter, playerNames);
            game.Start();
            mockPrinter.AssertTextWasPrinted("Manoj, press enter to roll the dice.");
        }
    }

    internal class MockPrinter : IConsole {
        private readonly List<string> textPrinted = new List<string>(new string[] { });
        private readonly List<string> reads;
        private int readsMade;

        internal MockPrinter(List<string> reads) {
            this.reads = reads;
        }

        public void Print(string text) {
            textPrinted.Add(text);
        }

        public void AssertTextWasPrinted(string expectedText) {
            Assert.Contains(expectedText, textPrinted);
        }

        public string Read() {
            string read = reads[readsMade];
            readsMade += 1;
            return read;
        }
    }
}