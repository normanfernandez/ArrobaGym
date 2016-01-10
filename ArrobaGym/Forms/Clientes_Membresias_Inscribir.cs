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
        private Models.Personal PersonalDeTurno;
        public Clientes_Membresias_Inscribir(Models.Personal personalDeTurno )
        {
            InitializeComponent();
            this.PersonalDeTurno = personalDeTurno; 
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

         
            programa = ProgramaDAO.SelectSingle(p => p.Descripcion == cbPrograma.Text);
            if (validatorCliente())
            {
                try
                {
                    Models.Cliente cliente = new Models.Cliente
                    {
                        Nombre = txtNombre.Text,
                        Apellido = txtApellido.Text,
                        Direccion = txtDireccion.Text,
                        Codigo = generateCode(txtNombre.Text, txtApellido.Text, cbPrograma.Text),
                        Factores_de_riesgos = txtRiesgos.Text,
                        Fecha_Inscripcion = DateTime.Now,
                        Objetivos = txtObetivos.Text,
                        Status = "Activo",
                        Telefono = txtTelefono.Text,
                        Ultimo_Pago = DateTime.Now,
                        Imagen = Utils.PictureBinary.GetBinary(txtfoto.Text),
                        Saldo = programa.Precio_Inscripcion - decimal.Parse(txtDeposito.Text),
                        IdPrograma = (int)programa.Id

                    };
                    ClienteDAO.Insert(cliente);
                    ClienteDAO.SaveAll();
                    Models.Seguimiento seguimiento = new Models.Seguimiento
                    {
                        Abdomen = decimal.Parse(txtAbdomen.Text),
                        Biceps = decimal.Parse(txtBiceps.Text),
                        Cadera = decimal.Parse(txtCadera.Text),
                        Caja_Toraxica = decimal.Parse(txtCajaToracica.Text),
                        Cintura = decimal.Parse(txtCintura.Text),
                        Fecha = DateTime.Now,
                        Flexibilidad = decimal.Parse(txtFlexibilidad.Text),
                        Gastronmio = decimal.Parse(TxtGastronomio.Text),
                        Muslo = decimal.Parse(txtMuslo.Text),
                        Peso = decimal.Parse(txtPeso.Text),
                        Saldo_Mes = decimal.Parse(txtDeposito.Text),
                        Personal_ID = PersonalDeTurno.Id,
                        Cliente_ID = cliente.Id

                    };
                    SeguimientoDao.Insert(seguimiento);
                    SeguimientoDao.SaveAll();
                    MessageBox.Show("Cliente Insertado con Exito");
                }
                catch (Exception ee) 
                {
                    MessageBox.Show("Error al introducir los datos");
                }
            }
            else MessageBox.Show("Error al introducir los datos");

            
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
        private bool validatorCliente() 
        {
            Decimal d; 
            if(
                txtNombre.Text == string.Empty ||  
                txtApellido.Text == string.Empty ||
                txtTelefono.Text == string.Empty ||
                txtDireccion.Text == string.Empty ||
                txtPeso.Text == string.Empty ||
                txtCajaToracica.Text == string.Empty ||
                txtCintura.Text == string.Empty ||
                txtAbdomen.Text == string.Empty ||
                txtCadera.Text == string.Empty ||
                txtMuslo.Text == string.Empty ||
                TxtGastronomio.Text == string.Empty ||
                txtBiceps.Text == string.Empty ||
                txtFlexibilidad.Text == string.Empty 
              )
            {
                MessageBox.Show("Hay campos en blanco"); return false;
            }
            return true;
        }
        private string generateCode(string nom, string ape, string prog) 
        {
            string n, a, p;
            Random rgn = new Random(); 
            string code;
            int value = rgn.Next(1000);
            string numeric = value.ToString("000");
            n = nom[0].ToString();
            a = ape[0].ToString();
            p = prog[0].ToString();
            code = n+a+p+numeric;
            if (ClienteDAO.SelectSingle(c => c.Codigo == code) == null) return code;
            else return generateCode(nom, ape, prog);
        }

    }
}
