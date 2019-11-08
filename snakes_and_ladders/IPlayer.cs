namespace snakes_and_ladders {
    public interface IPlayer {
        string Name();

        void TakeTurn(IConsole console);
    }
}