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
    public partial class Modificar_Personal : Form
    {
        private Models.Personal personal;
        public Modificar_Personal()
        {
            InitializeComponent();
        }
        public Modificar_Personal(Models.Personal p)
        {
            this.personal = p;
            InitializeComponent();

            tbxBuscarCedula.Text = tbxCedula.Text = personal.Cedula;
            tbxNombre.Text = personal.Nombre;
            tbxApellido.Text = personal.Apellido;
            tbxTelefono.Text = personal.Correo;
            tbxDireccion.Text = personal.Direccion;
            tbxCorreo.Text = personal.Correo;
            pictureBox1.Image = Utils.PictureBinary.GetImage(personal.Foto);
            cbHorario.SelectedItem = personal.Horario;
            tbxSalario.Text = Convert.ToString(personal.Salario);
            // dtPago = DateTime.Parse(personal.Fecha_Contratacion);


        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (validatorPersonal())
            {
                if (dtPago == null) dtPago.Value = DateTime.Now;
                DAO.Repository<Models.Personal> personalDAO = new DAO.Repository<Models.Personal>();
                
                Models.Personal Personal = new Models.Personal
                {
                    Nombre = tbxNombre.Text,
                    Apellido = tbxApellido.Text,
                    Cedula = tbxCedula.Text,
                    Correo = tbxCorreo.Text,
                    Direccion = tbxDireccion.Text,
                    Fecha_Contratacion = dtPago.Value,
                    Horario = cbHorario.SelectedText,
                    Salario = decimal.Parse(tbxSalario.Text),
                    Telefono = tbxTelefono.Text,
                    Foto = Utils.PictureBinary.GetBinary(tbxFoto.Text),
                    Usuario = tbxUsuario.Text,
                    Contraseña = tbxContr.Text,
                    Tipo = cbTipo.SelectedText,                   
                };
                try
                {
                    
            //        personalDAO.Insert(Personal); 
                    personalDAO.SaveAll();
                    MessageBox.Show("Empleado modificado con Exito");
                    this.Close();
                }
                catch (Exception exe)
                {
                    MessageBox.Show("Error al agregar empleado!");
                }
                //finally { this.Close(); }
            }
            else MessageBox.Show("Campos No Válidos");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.ShowDialog();
            tbxFoto.Text = openfile.FileName;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DAO.Repository<Models.Personal> PersonalDao = new DAO.Repository<Models.Personal>();
            personal = PersonalDao.SelectSingle(p => p.Cedula == tbxBuscarCedula.Text);
            if (personal != null)
            {
                tbxCedula.Text = personal.Cedula;
                tbxNombre.Text = personal.Nombre;
                tbxApellido.Text = personal.Apellido;
                tbxTelefono.Text = personal.Telefono;
                tbxDireccion.Text = personal.Direccion;
                tbxCorreo.Text = personal.Correo;
                tbxSalario.Text =  Convert.ToString( personal.Salario);
                tbxUsuario.Text = personal.Usuario;
                tbxContr.Text = personal.Contraseña;
                pictureBox1.Image = Utils.PictureBinary.GetImage(personal.Foto);


            }
            else
            {
                MessageBox.Show("Personal no encontrado");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.ShowDialog();
            tbxFoto.Text = openfile.FileName;
            pictureBox1.Image = Utils.PictureBinary.GetImage(Utils.PictureBinary.GetBinary(tbxFoto.Text));
        }
        private bool validatorPersonal()
        {
            Decimal d;
            if (tbxCedula.Text.Length != 11 && !Decimal.TryParse(tbxCedula.Text, out d)) return false;
            if (!tbxCorreo.Text.Contains('@')) return false;
            if (!Decimal.TryParse(tbxSalario.Text, out d)) return false;
            if (tbxTelefono.Text.Length != 10 && !Decimal.TryParse(tbxTelefono.Text, out d)) return false;
            if (tbxUsuario.Text == string.Empty || tbxContr.Text == string.Empty) return false;
            if (cbHorario.SelectedItem == null || cbTipo.SelectedItem == null) return false;
            return true;
        }

        private void label12_Click(object sender, EventArgs e)
        {
            
        }
    }
}