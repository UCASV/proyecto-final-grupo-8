using System;
using System.Windows.Forms;

namespace IP
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 ventana = new Form1();
            ventana.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmAdministrador ventana = new FrmAdministrador();
            ventana.ShowDialog();
        }

    }
}