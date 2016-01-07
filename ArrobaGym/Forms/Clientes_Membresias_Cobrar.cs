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
        private Models.Cliente cliente = new Models.Cliente();
        public Clientes_Membresias_Cobrar()
        {
            InitializeComponent();

        }
        public Clientes_Membresias_Cobrar(Models.Cliente c)
        {
            this.cliente = c;
            InitializeComponent();
            tbxCodigo.Text = cliente.Codigo; 
            tbxNombre.Text = cliente.Nombre;
            tbxApellido.Text = cliente.Apellido;
            tbxTelefono.Text = cliente.Telefono;
            TbxDireccion.Text = cliente.Direccion;
            tbxObjetivos.Text = cliente.Objetivos;
            tbxFactores.Text = cliente.Factores_de_riesgos; 
             
        }
        private void label20_Click(object sender, EventArgs e)
        {
            Clientes_Pendientes pendientes = new Clientes_Pendientes();
            pendientes.Visible = true;
            
        }
    }
}
