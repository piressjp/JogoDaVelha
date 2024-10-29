using src.Presenters; 
using src.Views.Interfaces;  

namespace JogoDaVelha
{
    public partial class StartForm : Form, IStartView
    {
        private readonly StartPresenter _presenter; 
        private Button buttonOneVsOne;  // Botão para o modo jogador contra jogador
        private Button buttonVsMachine;  // Botão para o modo jogador contra a máquina
        private Label labelTitle; 

        public StartForm()
        {
            InitializeComponent();
            _presenter = new StartPresenter(this);
        }

        // Exibe a janela do jogo com o modo selecionado
        public void ShowGame(bool vsMachine)
        {
            this.Hide();  // Esconde a tela inicial
            var gameForm = new GameForm(vsMachine);
            gameForm.Show();  // Mostra a tela do jogo
        }

        private void ButtonOneVsOne_Click(object sender, EventArgs e)
        {
            _presenter.StartGame(vsMachine: false);  // Inicia o jogo no modo jogador contra jogador
        }

        private void ButtonVsMachine_Click(object sender, EventArgs e)
        {
            _presenter.StartGame(vsMachine: true);  // Inicia o jogo no modo jogador contra a máquina
        }
    }
}
