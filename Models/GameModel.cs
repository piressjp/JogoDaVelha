// Contém a lógica responsavel por controlar o jogo

namespace src.Models
{
    public class GameModel
    {
        public bool PlayerTurn { get; private set; }
        public int TurnCount { get; private set; }
        public string[,] Board { get; private set; }
        public bool VsMachine { get; }

        public GameModel(bool vsMachine)
        {
            VsMachine = vsMachine;
            InitializeGame();
        }

        public void InitializeGame()
        {
            PlayerTurn = true; // X começa
            TurnCount = 0;
            Board = new string[3, 3]; // Inicializa o tabuleiro vazio
        }

        public bool MakeMove(int row, int column)
        {
            if (Board[row, column] == null)
            {
                Board[row, column] = PlayerTurn ? "X" : "O";
                PlayerTurn = !PlayerTurn;
                TurnCount++;
                return true;
            }
            return false;
        }

        public string CheckForWinner()
        {
            // Verificar linhas, colunas e diagonais para um vencedor
            for (int i = 0; i < 3; i++)
            {
                if (Board[i, 0] == Board[i, 1] && Board[i, 1] == Board[i, 2] && Board[i, 0] != null)
                {
                    return Board[i, 0];
                }
                if (Board[0, i] == Board[1, i] && Board[1, i] == Board[2, i] && Board[0, i] != null)
                {
                    return Board[0, i];
                }
            }
            if (Board[0, 0] == Board[1, 1] && Board[1, 1] == Board[2, 2] && Board[0, 0] != null)
            {
                return Board[0, 0];
            }
            if (Board[0, 2] == Board[1, 1] && Board[1, 1] == Board[2, 0] && Board[0, 2] != null)
            {
                return Board[0, 2];
            }

            return TurnCount == 9 ? "Draw" : string.Empty; // Retorna "Draw" em caso de empate
        }

        public (int row, int column) GetRandomMove()
        {
            List<(int row, int column)> possibles = new List<(int row, int column)>();

            for (int row = 0; row < 3; row++)
            {
                for (int column = 0; column < 3; column++)
                {
                    if (Board[row, column] == null)
                    {
                        possibles.Add((row, column));
                    }
                }
            }

            Random rand = new Random();
            int index = rand.Next(possibles.Count);
            return possibles[index];
        }
    }
}
