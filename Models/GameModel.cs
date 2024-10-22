namespace src.Models
{
    public class GameModel
    {
        public bool PlayerTurn { get; private set; } // Determina se é a vez do jogador (true para X, false para O)
        public int TurnCount { get; private set; } // Contador de turnos
        public string[,] Board { get; private set; } // Tabuleiro do jogo
        public bool VsMachine { get; } // Indica se o jogo é contra a máquina

        public GameModel(bool vsMachine)
        {
            VsMachine = vsMachine; 
            InitializeGame();
        }

        public void InitializeGame()
        {
            PlayerTurn = true; // X começa
            TurnCount = 0; // Reseta o contador de turnos
            Board = new string[3, 3]; // Inicializa o tabuleiro vazio
        }

        public bool MakeMove(int row, int column)
        {
            if (Board[row, column] == null) 
            {
                Board[row, column] = PlayerTurn ? "X" : "O";
                PlayerTurn = !PlayerTurn; 
                TurnCount++; 
                return true; // Movimento válido
            }
            return false; // Movimento inválido
        }

        public string CheckForWinner()
        {
            // Verificar linhas
            for (int i = 0; i < 3; i++)
            {
                if (Board[i, 0] == Board[i, 1] && Board[i, 1] == Board[i, 2] && Board[i, 0] != null)
                {
                    return Board[i, 0]; 
                }
                // Verificar colunas
                if (Board[0, i] == Board[1, i] && Board[1, i] == Board[2, i] && Board[0, i] != null)
                {
                    return Board[0, i]; 
                }
            }
            // Verificar diagonais
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
            List<(int row, int column)> possibles = new List<(int row, int column)>(); // Lista de movimentos possíveis
            for (int row = 0; row < 3; row++)
            {
                for (int column = 0; column < 3; column++)
                {
                    if (Board[row, column] == null)
                    {
                        possibles.Add((row, column)); // Adiciona posições vazias à lista
                    }
                }
            }
            Random rand = new Random();
            int index = rand.Next(possibles.Count); // Seleciona um movimento aleatório
            return possibles[index];
        }
    }
}
