using System;

namespace snakes_and_ladders {
    public class CommandLineConsole : IConsole {
        public void Print(string text) {
            Console.WriteLine(text);
        }

        public string Read() {
            return Console.ReadLine();
        }
    }
}