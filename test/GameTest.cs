using System.Collections.Generic;
using NUnit.Framework;
using snakes_and_ladders;

namespace test {
    public class GameTest {
        [Test]
        public void ItGetsTheNumberOfPlayers() {
            List<IPlayer> players = new List<IPlayer>(new[] {NamedPlayer("Manoj"), NamedPlayer("Ryan")});

            Game game = new Game(MockConsole.Empty(), players);

            Assert.AreEqual(2, game.numberOfPlayers);
        }

        [Test]
        public void ItGetsThePlayerNames() {
            List<IPlayer> players = new List<IPlayer>(new[] {NamedPlayer("Manoj"), NamedPlayer("Ryan")});

            Game game = new Game(MockConsole.Empty(), players);

            CollectionAssert.AreEqual(new List<string>(new[] {"Manoj", "Ryan"}), game.PlayerNames());
        }

        [Test]
        public void TheFirstPlayerTakesTheirTurn() {
            MockPlayer mockPlayer = new MockPlayer();
            List<IPlayer> players = new List<IPlayer>(new[] {mockPlayer, new MockPlayer(1)});
            Game game = new Game(MockConsole.Empty(), players);

            game.Start();

            mockPlayer.AssertTurnTaken();
        }

        [Test]
        public void IfPlayerHasWonThenTheWinnerIsPrinted() {
            List<IPlayer> players = new List<IPlayer>(new[] {new MockPlayer(1), NamedPlayer("Ryan")});
            MockConsole mockConsole = MockConsole.Empty();
            Game game = new Game(mockConsole, players);

            game.Start();

            mockConsole.AssertTextWasPrinted("We have a winner! Congratulations, Mo the Mock!");
        }

        [Test]
        public void IfPlayerDoesntWinThenTheNextPlayerGoes() {
            MockPlayer mockPlayer = new MockPlayer(1);
            List<IPlayer> players = new List<IPlayer>(new IPlayer[] {new MockPlayer(), mockPlayer});
            Game game = new Game(MockConsole.Empty(), players);

            game.Start();

            mockPlayer.AssertTurnTaken();
        }

        [Test]
        public void IfLastPlayerDoesntWinItGoesBackToTheFirstPlayer() {
            MockPlayer mockPlayer = new MockPlayer(2);
            List<IPlayer> players = new List<IPlayer>(new IPlayer[] {mockPlayer, new MockPlayer() });
            Game game = new Game(MockConsole.Empty(), players);

            game.Start();

            mockPlayer.AssertTurnTakenTwice();
        }

        private static IPlayer NamedPlayer(string name) {
            return new MockPlayer(1, name);
        }
    }
}