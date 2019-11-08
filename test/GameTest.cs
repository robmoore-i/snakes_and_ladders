using NUnit.Framework;

namespace test {
    public class GameTest {
        [Test]
        public void ItStartsByAskingHowManyPlayers() {
            MockPrinter mockPrinter = new MockPrinter();
            _ = new Game(mockPrinter);
            mockPrinter.assertLastTextPrintedWas("How many players?");
        }
    }

    internal class MockPrinter : IPrint {
        private string lastTextPrinted;

        public void Print(string text) {
            this.lastTextPrinted = text;
        }

        public void assertLastTextPrintedWas(string expectedText) {
            Assert.AreEqual(expectedText, lastTextPrinted);
        }
    }
}