namespace snakes_and_ladders {
    public interface IPlayer {
        string Name();

        bool TakeTurn(IConsole console);
    }
}