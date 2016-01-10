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
        DAO.Repository<Models.Programas> ProgramaDAO = new DAO.Repository<Models.Programas>();
        DAO.Repository<Models.Cliente_Programa> ClienteProgramaDao = new DAO.Repository<Models.Cliente_Programa>();
        DAO.Repository<Models.Seguimiento> SeguimientoDao = new DAO.Repository<Models.Seguimiento>();
        DAO.Repository<Models.Cliente> ClienteDAO = new DAO.Repository<Models.Cliente>();
        private Models.Programas programa; 
        public Clientes_Membresias_Inscribir( )
        {
            InitializeComponent();
            cbPrograma.DataSource = ProgramaDAO.SelectAll().Select(
                p => new { p.Id, p.Descripcion }
                ).ToList();
            cbPrograma.DisplayMember = "Descripcion";
            cbPrograma.ValueMember = "Id";
            cbPrograma.DropDownStyle = ComboBoxStyle.DropDownList;
            programa = ProgramaDAO.SelectAll().First();
              label19.Text = "RD$:" + Convert.ToString(programa.Precio_Inscripcion);
            label20.Text = "RD$:" + Convert.ToString(programa.Precio_periodo);
            
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

            //falta generar el codigo 
            programa = ProgramaDAO.SelectSingle(p => p.Descripcion == cbPrograma.Text); 
            string codigoCliente = string.Format("%.05d", new Random().Next()); 
            Models.Cliente cliente = new Models.Cliente
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Direccion = txtDireccion.Text,
                Codigo = codigoCliente,
                Factores_de_riesgos = txtRiesgos.Text,
                Fecha_Inscripcion = DateTime.Now,
                Objetivos = txtObetivos.Text,
                Status = "Activo",
                Telefono = txtTelefono.Text,
                Ultimo_Pago = DateTime.Now,
                Imagen = Utils.PictureBinary.GetBinary(txtfoto.Text),
                Saldo = programa.Precio_Inscripcion - decimal.Parse(txtDeposito.Text)
                
            };
            Models.Seguimiento seguimiento = new Models.Seguimiento
            {
                Abdomen=decimal.Parse(txtAbdomen.Text), 
                Biceps = decimal.Parse(txtBiceps.Text),
                Cadera = decimal.Parse(txtCadera.Text), 
                Caja_Toraxica=decimal.Parse(txtCajaToracica.Text),
                Cintura=decimal.Parse(txtCintura.Text),
                Fecha = DateTime.Now,
                Flexibilidad=decimal.Parse(txtFlexibilidad.Text),
                Gastronmio = decimal.Parse(TxtGastronomio.Text),
                Muslo = decimal.Parse(txtMuslo.Text),
                Peso = decimal.Parse(txtPeso.Text),
                Saldo_Mes =  decimal.Parse(txtDeposito.Text)
                
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

        private void cbPrograma_SelectionChangeCommitted(object sender, EventArgs e)
        {
            programa = ProgramaDAO.SelectSingle(p => p.Descripcion == cbPrograma.Text); 
            label19.Text = "RD$:" + Convert.ToString(programa.Precio_Inscripcion);
            label20.Text = "RD$:" + Convert.ToString(programa.Precio_periodo);
             
        }
        private string generateCode(Models.Cliente cliente) 
        {
            
            Random rgn = new Random(); 
            string code;
            int value = rgn.Next(1000);
            string numeric = value.ToString("000");
            code = cliente.Nombre[0] + cliente.Apellido[0] + Convert.ToString(cliente.IdPrograma)[0] + numeric;
            if (ClienteDAO.SelectSingle(c => c.Codigo == cliente.Codigo) == null) return code;
            else return generateCode(cliente);
        }
    }
}
