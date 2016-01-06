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
using ArrobaGym.DAO;

namespace ArrobaGym
{
    public partial class MenuAdmin : Form
    {

        Repository<Models.Cliente> ClienteDAO = new Repository<Models.Cliente>();
        Repository<Models.Programas> ProgramaDAO = new Repository<Models.Programas>();
        Repository<Models.Personal> PersonalDAO = new Repository<Models.Personal>();
        public MenuAdmin()
        {
            InitializeComponent();
            DataTable dt = new DataTable();
            
       

        }

        private void MenuAdmin_Load(object sender, EventArgs e)
        {


            dataGridView1.DataSource = ClienteDAO.SelectAll();
            dataGridView3.DataSource = ProgramaDAO.SelectAll();
            dataGridView2.DataSource = PersonalDAO.SelectAll();

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

        private void tabEmpleado_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Personal_Agregar pa = new Personal_Agregar();
            pa.Visible = true;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void btnInscribir_Click(object sender, EventArgs e)
        {
            Clientes_Membresias_Inscribir inscribir = new Clientes_Membresias_Inscribir();
            inscribir.Visible = true; 
        }

        private void bntCobrar_Click(object sender, EventArgs e)
        {
            Clientes_Membresias_Cobrar cobro = new Clientes_Membresias_Cobrar();
            cobro.Visible = true;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Clientes_Membresias_Consultar consulta = new Clientes_Membresias_Consultar();
            consulta.Visible = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Clientes_Pendientes pendientes = new Clientes_Pendientes();
            pendientes.Visible = true;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Clientes_Membresias_Administrar admin = new Clientes_Membresias_Administrar();
            admin.Visible = true; 
        }

        private void label22_Click(object sender, EventArgs e)
        {
            Cliente_calentamientos_administrar calentamientos = new Cliente_calentamientos_administrar();
            calentamientos.Visible = true;
          

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Modificar_Personal ModPer = new Modificar_Personal();
            ModPer.Visible = true;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Programa_Agregar PrAg = new Programa_Agregar();
            PrAg.Visible = true;
        }

        private void tabProgramas_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Programas_Administrar PrgAdmin = new Programas_Administrar();
            PrgAdmin.Visible = true; 
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (validatorProducto())
            {
                try
                {
                    Models.Productos producto = new Models.Productos
                    {

                        Nombre = textBoxNombreProducto.Text,
                        Precio = int.Parse(textBoxprecioProducto.Text),

                    };
                    DAO.Repository<Models.Productos> productoDAO = new Repository<Models.Productos>();
                    productoDAO.Insert(producto);
                    productoDAO.SaveAll();
                    MessageBox.Show("Producto Registrado con éxito");
                }
                catch (Exception exep) 
                { 
                    MessageBox.Show("Error al insertar Producto"); 
                }
            }
            else 
                MessageBox.Show("Error de validación");

        }
        public bool validatorProducto() 
        {
            DAO.Repository<Models.Productos> productosDAO = new Repository<Models.Productos>();
            Decimal d;
            if (!Decimal.TryParse(textBoxprecioProducto.Text, out d)) 
                return false;
            if (productosDAO.SelectSingle(p => p.Nombre == textBoxNombreProducto.Text) != null)
                return false;
            return true;
        }
    }
}

