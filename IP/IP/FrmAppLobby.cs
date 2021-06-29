using System;
using System.Windows.Forms;

namespace IP
{
    public partial class FrmAppLobby : Form
    {
        public FrmAppLobby()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmCitas ventana = new FrmCitas();
            ventana.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmProVac ventana = new FrmProVac();
            ventana.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmSeguiCitas ventana = new FrmSeguiCitas();
            ventana.ShowDialog();
        }

    }
}