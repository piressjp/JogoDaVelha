namespace src.Views.Interfaces
{
    public interface IGameView
    {
        void UpdateBoard(int row, int column, string playerSymbol);
        void DisplayWinner(string winner);
        void UpdateStatus(string message);
        void EnableAllButtons(bool enable);
        void ResetBoard();
        void EnableRestartAndMenuButtons(bool enable);
    }
}