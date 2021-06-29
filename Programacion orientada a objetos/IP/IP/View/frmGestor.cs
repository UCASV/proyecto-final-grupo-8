using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

namespace IP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            var db = new BDDPContext();
            List<Employee> employee = db.Employees
                .Include(u => u.IdTypeEmployeeNavigation)
                .ToList();

            int usuario = Convert.ToInt32(textBox1.Text);
            string contrasena = textBox2.Text;

            List<Employee> resultado = employee
                .Where(u => u.Id == usuario &&
                            u.Password == contrasena)
                .ToList();
            
            
            //Validando resultado
            if (resultado.Count() > 0)
            {
                MessageBox.Show("Bienvenido","MINSAL",MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                FrmAppLobby ventana = new FrmAppLobby();
                ventana.ShowDialog();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrecto", "MINSAL",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



                
        }
    }
}