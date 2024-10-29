using JogoDaVelha.Presenters;  
using src.Views.Interfaces;  

namespace JogoDaVelha
{
    public partial class GameForm : Form, IGameView
    {
        private readonly GamePresenter _presenter;
        private Button button1, button2, button3, button4, button5, button6, button7, button8, button9, buttonRestart;  // Botões do tabuleiro e botão de reinício
        private Label labelStatus;
        private Button[,] board;  // Matriz de botões para o tabuleiro

        public GameForm(bool vsMachine)
        {
            InitializeComponent();
            _presenter = new GamePresenter(this, vsMachine);
            board = new Button[3, 3]
            {
                { button1, button2, button3 },
                { button4, button5, button6 },
                { button7, button8, button9 }
            };

            foreach (Button button in board)
            {
                button.Text = "";  // Inicializa o texto do botão
                button.Click += new EventHandler(Button_Click);  // Adiciona o evento de clique
            }
            EnableRestartAndMenuButtons(true);  // Desabilita os botões de reinício e voltar para o menu
        }

        // Atualiza o tabuleiro com o símbolo do jogador
        public void UpdateBoard(int row, int column, string playerSymbol)
        {
            board[row, column].Text = playerSymbol;
        }

        // Mostra o vencedor e desabilita os botões
        public void DisplayWinner(string winner)
        {
            labelStatus.Text = winner;
            EnableAllButtons(false);
            buttonRestart.Show();
        }

        // Atualiza a mensagem de status
        public void UpdateStatus(string message)
        {
            labelStatus.Text = message;
        }

        // Habilita ou desabilita todos os botões do tabuleiro
        public void EnableAllButtons(bool enable)
        {
            foreach (Button button in board)
            {
                button.Enabled = enable;
            }
        }

        // Reseta o tabuleiro para um novo jogo
        public void ResetBoard()
        {
            foreach (Button button in board)
            {
                button.Text = "";  // Limpa o texto dos botões
                button.Enabled = true;  // Habilita os botões
            }
            buttonRestart.Hide();  // Esconde o botão de reinício
        }

        // Evento de clique dos botões do tabuleiro
        private void Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            var position = (row: clickedButton.TabIndex / 3, column: clickedButton.TabIndex % 3);
            _presenter.PlayerMove(position.row, position.column);
        }

        // Evento de clique do botão de reinício
        private void buttonRestart_Click(object sender, EventArgs e)
        {
            labelStatus.Text = "";
            _presenter.RestartGame();
        }

        // Habilita ou desabilita os botões de reinício e menu
        public void EnableRestartAndMenuButtons(bool enable)
        {
            if (enable)
            {
                buttonRestart.Hide();
                button10.Hide();
            }
            else
            {
                buttonRestart.Show();
                button10.Show();
            }
        }

        // Evento de clique do botão de menu
        private void buttonMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            StartForm startForm = new StartForm();
            startForm.Show();
        }
    }
}
