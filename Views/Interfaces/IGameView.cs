namespace src.Views.Interfaces
{
    public interface IGameView
    {
        void UpdateBoard(int row, int column, string playerSymbol);  // Atualiza o tabuleiro
        void DisplayWinner(string winner); // Mostra o vencedor
        void UpdateStatus(string message);  // Atualiza a messagem de status do jogo (vencendor ou empate)
        void EnableAllButtons(bool enable); // Desabilita (true) ou habilita (false) todos os botões do tabuleiro
        void ResetBoard(); // Reseta o tabuleiro
        void EnableRestartAndMenuButtons(bool enable); // Desabilita (true) ou habilita (false) os botões de voltar para o menu e de reiniciar o jogo
    }
}