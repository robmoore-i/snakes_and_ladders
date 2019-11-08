using System.Collections.Generic;
using NUnit.Framework;

namespace test {
    public class GameTest {
        [Test]
        public void ItStartsByAskingHowManyPlayers() {
            MockPrinter mockPrinter = new MockPrinter(new List<string>(new string[] { "2", "Manoj,Ryan" }));
            _ = new Game(mockPrinter);
            mockPrinter.assertTextWasPrinted("How many players?");
        }

        [Test]
        public void ItReadsTheNumberOfPlayersFromTheConsole() {
            MockPrinter mockPrinter = new MockPrinter(new List<string>(new string[] { "2", "Manoj,Ryan" }));
            Game game = new Game(mockPrinter);
            Assert.AreEqual(2, game.numberOfPlayers);
        }

        [Test]
        public void ItAsksForThePlayersNames() {
            MockPrinter mockPrinter = new MockPrinter(new List<string>(new string[] { "2", "Manoj,Ryan" }));
            _ = new Game(mockPrinter);
            mockPrinter.assertTextWasPrinted("What are their names? (comma separated)");
        }

        [Test]
        public void ItReadsThePlayerNamesFromTheConsole() {
            MockPrinter mockPrinter = new MockPrinter(new List<string>(new string[] { "2", "Manoj,Ryan" }));
            Game game = new Game(mockPrinter);
            CollectionAssert.AreEqual(new List<string>(new string[]{"Manoj", "Ryan"}), game.playerNames);
        }

        [Test]
        public void IfNoPlayersAreListedItAsksYouToTryAgain() {
            MockPrinter mockPrinter = new MockPrinter(new List<string>(new string[] { "2", "", "Manoj,Ryan" }));
            Game game = new Game(mockPrinter);
            mockPrinter.assertTextWasPrinted("What are their names? (comma separated) [for example \"Emese,Hashim\"]");
        }

        [Test]
        public void ItTrimsSpacesAroundPlayerNames() {
            MockPrinter mockPrinter = new MockPrinter(new List<string>(new string[] { "2", "Manoj, Ryan, Seda" }));
            Game game = new Game(mockPrinter);
            CollectionAssert.AreEqual(new List<string>(new string[] { "Manoj", "Ryan", "Seda" }), game.playerNames);
        }

        [Test]
        public void ItAsksTheFirstPlayerToRollTheDice() {
            MockPrinter mockPrinter = new MockPrinter(new List<string>(new string[] { "2", "Manoj,Ryan" }));
            Game game = new Game(mockPrinter);
            game.Start();
            mockPrinter.assertTextWasPrinted("Manoj, press enter to roll the dice.");
        }
    }

    internal class MockPrinter : IConsole {
        private readonly List<string> textPrinted = new List<string>(new string[] {});
        private readonly List<string> reads;
        private int readsMade;

        internal MockPrinter(List<string> reads) {
            this.reads = reads;
        }

        public void Print(string text) {
            textPrinted.Add(text);
        }

        public void assertTextWasPrinted(string expectedText) {
            Assert.Contains(expectedText, textPrinted);
        }

        public string Read() {
            string read = this.reads[this.readsMade];
            this.readsMade += 1;
            return read;
        }
    }
}