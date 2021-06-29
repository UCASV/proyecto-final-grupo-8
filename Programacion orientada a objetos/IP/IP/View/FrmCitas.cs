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
            var db = new BDDPContext();
            cmbtra.DataSource = db.WorkSectors.ToList();
            cmbtra.DisplayMember = "Sector";
            cmbtra.ValueMember = "IdWorkSector";
        }

       private void button1_Click(object sender, EventArgs e)
       {
           WorkSector WSref = new WorkSector();
           WSref.Id = ((WorkSector) cmbtra.SelectedItem).Id;
           
           var db = new BDDPContext();
           
           WorkSector mbdd = db.Set<WorkSector>()
               .SingleOrDefault(w => w.Id == WSref.Id);
           
           Citizen nuevo = new Citizen()
           {
                Dui = Convert.ToInt32(textBox2.Text),
                Name = textBox3.Text,
                Age = Convert.ToInt32(textBox1.Text),
                Phone = Convert.ToInt32(textBox5.Text),
                Email = textBox6.Text,
                Sector = mbdd
           };

           
           db.Add(nuevo);
           db.SaveChanges();
       }
    }
}