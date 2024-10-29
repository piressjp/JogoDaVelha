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
            if (_model.MakeMove(row, column))  // Verifica se o movimento é valido ou não
            {
                _view.UpdateBoard(row, column, _model.PlayerTurn ? "O" : "X"); // Atualiza o tabuleiro com o valor O ou X, dependendo de quem é a jogada

                string result = _model.CheckForWinner();
                if (!string.IsNullOrEmpty(result)) // Verifica se houve vencedor
                {
                    _view.EnableRestartAndMenuButtons(false); // Habilita os botões
                    _view.DisplayWinner(result == "Draw" ? "Empate!" : $"Jogador {result} venceu!");
                }
                else if (_model.VsMachine && !_model.PlayerTurn) // Verifica se é vez da máquina
                {
                    MachineMove().GetAwaiter(); // Jogada da maquina
                }
            }
        }

        private async Task MachineMove()
        {
            await Task.Delay(1000);
            var (row, column) = _model.GetRandomMove(); // Gera um movimento aleatório
            PlayerMove(row, column); // Executa a jogada da máquina
        }

        public void RestartGame()
        {
            _model.InitializeGame(); // Reinicializa tudo do jogo
            _view.ResetBoard(); // Reseta o tabuleiro
        }
    }
}
