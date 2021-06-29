using System;
using System.Linq;
using System.Windows.Forms;

namespace IP
{
    public partial class FrmCitas : Form
    {
        public FrmCitas()
        {
            InitializeComponent();
        }

        private void FrmCitas_Load(object sender, EventArgs e)
        {
            var db = new Rcontext();
            cmbtra.DataSource = db.WorkSectors.ToList();
            cmbtra.DisplayMember = "Sector";
            cmbtra.ValueMember = "IdWorkSector";
        }
    }
}