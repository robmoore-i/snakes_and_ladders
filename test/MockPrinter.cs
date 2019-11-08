using System.Collections.Generic;
using NUnit.Framework;
using snakes_and_ladders;

namespace test {
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