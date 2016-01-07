using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace ArrobaGym
{
    public partial class Clientes_Membresias_Inscribir : Form
    {
        public Clientes_Membresias_Inscribir()
        {
            InitializeComponent();
        }



        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Models.Cliente cliente = new Models.Cliente
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Direccion = txtDireccion.Text,
                Codigo = string.Format("%.05d", new Random().Next()),
                Factores_de_riesgos = txtRiesgos.Text,
                Fecha_Inscripcion = DateTime.Now,
                Objetivos = txtObetivos.Text,
                Saldo = decimal.Parse(txtDeposito.Text),
                Status = "Activo",
                Telefono = txtTelefono.Text,
                Ultimo_Pago = DateTime.Now,
                Imagen = Utils.PictureBinary.GetBinary(txtfoto.Text),
                


            };
            DAO.Repository<Models.Cliente> clienteDao = new DAO.Repository<Models.Cliente>();
            clienteDao.Insert(cliente);
            clienteDao.SaveAll();
        }

        private void btnInscribir_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.ShowDialog();
            txtfoto.Text = openfile.FileName;

        }
    }
}
