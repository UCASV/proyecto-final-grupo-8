using System;
using System.Windows.Forms;

namespace IP
{
    public partial class FrmSeguiCitas : Form
    {
        public FrmSeguiCitas()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmCitas window = new FrmCitas();
            window.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}