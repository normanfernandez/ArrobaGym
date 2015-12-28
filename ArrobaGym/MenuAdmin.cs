using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Objects;
using System.Data.Objects.DataClasses;

namespace ArrobaGym
{
    public partial class MenuAdmin : Form
    {
      
        
        AtGymEntities AtGymddb = new AtGymEntities();
        public MenuAdmin()
        {
            InitializeComponent();
        }

        private void MenuAdmin_Load(object sender, EventArgs e)
        {

           
        }

       

        private void MenuAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void lblNombre_Click(object sender, EventArgs e)
        {

        }

        private void tabProductos_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = Convert.ToString(DateTime.Now);
            lblTimeCal.Text = Convert.ToString(DateTime.Now);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void lblCalMonto_Click(object sender, EventArgs e)
        {

        }

        private void lblCalReg_Click(object sender, EventArgs e)
        {

        }

        private void tabClientesCalentamiento_Click(object sender, EventArgs e)
        {

        }

       
                
            

    }
}

