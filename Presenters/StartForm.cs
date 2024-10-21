using System;
using System.Windows.Forms;

namespace JogoDaVelha
{
    public partial class StartForm : Form
    {
        private Button buttonOneVsOne;
        private Button buttonVsMachine;
        private Label labelTitle;
        private bool vsMachine;

        public StartForm()
        {
            InitializeComponent();
        }

        private void ButtonOneVsOne_Click(object sender, EventArgs e)
        {
            this.Hide();
            GameForm gameForm = new GameForm(vsMachine = false);
            gameForm.Show();
        }

        private void ButtonVsMachine_Click(object sender, EventArgs e)
        {
            this.Hide();
            GameForm gameForm = new GameForm(vsMachine = true);
            gameForm.Show();
        }

        private void labelTitle_Click(object sender, EventArgs e)
        {

        }
    }
}
