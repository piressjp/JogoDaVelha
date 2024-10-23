using JogoDaVelha.Presenters;
using src.Views.Interfaces;

namespace JogoDaVelha
{
    public partial class GameForm : Form, IGameView
    {
        private readonly GamePresenter _presenter;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private Button buttonRestart;
        private Label labelStatus;
        private Button[,] board;
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
                button.Text = "";
                button.Click += new EventHandler(Button_Click);
            }


            EnableRestartAndMenuButtons(true);
        }

        public void UpdateBoard(int row, int column, string playerSymbol)
        {
            board[row, column].Text = playerSymbol;
        }

        public void DisplayWinner(string winner)
        {
            labelStatus.Text = winner;
            EnableAllButtons(false);
            buttonRestart.Show();
        }

        public void UpdateStatus(string message)
        {
            labelStatus.Text = message;
        }

        public void EnableAllButtons(bool enable)
        {
            foreach (Button button in board)
            {
                button.Enabled = enable;
            }
        }

        public void ResetBoard()
        {
            foreach (Button button in board)
            {
                button.Text = "";
                button.Enabled = true;
            }
            buttonRestart.Hide();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            var position = (row: clickedButton.TabIndex / 3, column: clickedButton.TabIndex % 3);
            _presenter.PlayerMove(position.row, position.column);
        }

        private void buttonRestart_Click(object sender, EventArgs e)
        {
            labelStatus.Text = "";
            _presenter.RestartGame();
        }

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

        private void buttonMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            StartForm startForm = new StartForm();
            startForm.Show();
        }
    }
}
