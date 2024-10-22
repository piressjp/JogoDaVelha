using src.Presenters;
using src.Views.Interfaces;

namespace JogoDaVelha
{
    public partial class StartForm : Form, IStartView
    {
        private readonly StartPresenter _presenter;
        private Button buttonOneVsOne;
        private Button buttonVsMachine;
        private Label labelTitle;
        
        public StartForm()
        {
            InitializeComponent();
            _presenter = new StartPresenter(this);
        }

        public void ShowGame(bool vsMachine)
        {
            this.Hide();
            var gameForm = new GameForm(vsMachine);
            gameForm.Show();
        }

        private void ButtonOneVsOne_Click(object sender, EventArgs e)
        {
            _presenter.StartGame(vsMachine: false);
        }

        private void ButtonVsMachine_Click(object sender, EventArgs e)
        {
            _presenter.StartGame(vsMachine: true);
        }
    }
}
