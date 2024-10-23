using src.Models;
using src.Views.Interfaces;

namespace JogoDaVelha.Presenters
{
    public class GamePresenter
    {
        private readonly IGameView _view;
        private readonly GameModel _model;

        public GamePresenter(IGameView view, bool vsMachine)
        {
            _view = view;
            _model = new GameModel(vsMachine);
        }

        public void PlayerMove(int row, int column)
        {
            if (_model.MakeMove(row, column))
            {
                _view.UpdateBoard(row, column, _model.PlayerTurn ? "O" : "X");

                string result = _model.CheckForWinner();
                if (!string.IsNullOrEmpty(result))
                {
                    _view.EnableRestartAndMenuButtons(false);
                    _view.DisplayWinner(result == "Draw" ? "Empate!" : $"Jogador {result} venceu!");
                }
                else if (_model.VsMachine && !_model.PlayerTurn)
                {
                    MachineMove().GetAwaiter();
                }
            }
        }

        private async Task MachineMove()
        {
            await Task.Delay(1000);
            var (row, column) = _model.GetRandomMove();
            PlayerMove(row, column); // Executa a jogada da máquina
        }

        public void RestartGame()
        {
            _model.InitializeGame();
            _view.ResetBoard();
        }
    }
}
