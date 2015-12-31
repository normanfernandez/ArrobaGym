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
    public partial class Clientes_Pendientes : Form
    {
        public Clientes_Pendientes()
        {
            InitializeComponent();
        }

        private void Clientes_Pendientes_Load(object sender, EventArgs e)
        {

        }

        private void bntCobrar_Click(object sender, EventArgs e)
        {
            Clientes_Membresias_Cobrar cobro = new Clientes_Membresias_Cobrar();
            cobro.Visible = true;
            this.Close();
        }
    }
}
