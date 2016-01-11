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
        DAO.Repository<Models.Cliente> ClienteDAO = new DAO.Repository<Models.Cliente>();
        Models.Cliente ClienteSeleccionado = null;

        public Clientes_Pendientes()
        {
            InitializeComponent();
            this.dataGridView1.ReadOnly = true;
            bntCobrar.Enabled = false;
        }

        private void Clientes_Pendientes_Load(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = ClienteDAO.FindAll(c => c.Status == "Pendiente")
                .Select(c => new { c.Id, c.Nombre, c.Apellido, c.Status, c.Saldo }).ToArray();
            this.dataGridView1.Columns["Id"].Visible = false;
        }

        private void bntCobrar_Click(object sender, EventArgs e)
        {
            Clientes_Membresias_Cobrar cobro = new Clientes_Membresias_Cobrar(
                this.ClienteSeleccionado
                );
            cobro.ShowDialog(this);
            this.Close();
        }

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.StateChanged != DataGridViewElementStates.Selected)
            {
                bntCobrar.Enabled = false;
                return;
            }
            bntCobrar.Enabled = true;
            int id = (int)e.Row.Cells["Id"].Value;
            this.ClienteSeleccionado =
                ClienteDAO.SelectSingle(c => c.Id == id);
        }
    }
}
