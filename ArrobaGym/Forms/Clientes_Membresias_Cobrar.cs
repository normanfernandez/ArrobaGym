using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArrobaGym
{
    public partial class Clientes_Membresias_Cobrar : Form
    {
        public Clientes_Membresias_Cobrar()
        {
            InitializeComponent();

        }

        private void label20_Click(object sender, EventArgs e)
        {
            Clientes_Pendientes pendientes = new Clientes_Pendientes();
            pendientes.Visible = true;
            
        }
    }
}
