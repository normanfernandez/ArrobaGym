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
        private DAO.Repository<Models.Seguimiento> SeguimientoDAO = new DAO.Repository<Models.Seguimiento>();
        private DAO.Repository<Models.Cliente> ClienteDAO = new DAO.Repository<Models.Cliente>();
        private Models.Cliente cliente;
        private Models.Seguimiento seguimiento;

        public Clientes_Membresias_Cobrar()
        {
            InitializeComponent();

        }

        public Clientes_Membresias_Cobrar(Models.Cliente cliente)
        {
            this.cliente = ClienteDAO.SelectSingle(c => c.Id == cliente.Id);
            InitializeComponent();
            tbxCodigo.Text = cliente.Codigo; 
            tbxNombre.Text = cliente.Nombre;
            tbxApellido.Text = cliente.Apellido;
            tbxTelefono.Text = cliente.Telefono;
            TbxDireccion.Text = cliente.Direccion;
            tbxObjetivos.Text = cliente.Objetivos;
            tbxFactores.Text = cliente.Factores_de_riesgos; 
             
        }

        private void bntCobrar_Click(object sender, EventArgs e)
        {
            try
            {
                this.seguimiento = new Models.Seguimiento
                {
                    Abdomen = decimal.Parse(this.tbxAbdomen.Text),
                    Biceps = decimal.Parse(this.tbxAbdomen.Text),
                    Cadera = decimal.Parse(this.tbxCadera.Text),
                    Caja_Toraxica = decimal.Parse(this.tbxCaja.Text),
                    Cintura = decimal.Parse(this.tbxCintura.Text),
                    Fecha = DateTime.Now,
                    Flexibilidad = decimal.Parse(this.tbxFlexibilidad.Text),
                    Muslo = decimal.Parse(this.tbxMuslo.Text),
                    Peso = decimal.Parse(this.tbxPeso.Text),
                    Personal_ID = MenuAdmin.EmpleadodeTurno.Id,
                    Saldo_Mes = decimal.Parse(this.tbxDeposito.Text)
                };
                SeguimientoDAO.Insert(seguimiento);
                cliente.Saldo += seguimiento.Saldo_Mes;
                SeguimientoDAO.SaveAll();
                ClienteDAO.SaveAll();
            }
            catch (Exception ee)
            {
                MessageBox.Show("Error con al insertar los datos en la base de datos! Revise Campos");
            }
        }
    }
}
