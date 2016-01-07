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
    public partial class Personal_Agregar : Form
    {
        public Personal_Agregar()
        {
            InitializeComponent();
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (validatorPersonal())
            {
                if (dtPago == null) dtPago.Value = DateTime.Now;
                DAO.Repository<Models.Personal> personalDAO = new DAO.Repository<Models.Personal>();
                Models.Personal Personal = new Models.Personal
                {
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Cedula = txtCedula.Text,
                    Correo = txtCorreo.Text,
                    Direccion = txtDireccion.Text,
                    Fecha_Contratacion = dtPago.Value,
                    Horario = cbHorario.SelectedText,
                    Salario = decimal.Parse(tbxSalario.Text),
                    Telefono = txtTelefono.Text,
                    Foto = Utils.PictureBinary.GetBinary(txtFoto.Text),
                    Usuario = tbxUser.Text,
                    Contraseña = tbxCont.Text,
                    Tipo = cbTipo.SelectedText,


                };
                try
                {
                    personalDAO.Insert(Personal);
                    personalDAO.SaveAll();
                    MessageBox.Show("Empleado Insertado con Exito");
                    this.Close();
                }
                catch (Exception exe) 
                {
                    MessageBox.Show("Error al agregar Programa!");
                }
                //finally { this.Close(); }
            }
            else MessageBox.Show("Campos No Válidos");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.ShowDialog();
            txtFoto.Text = openfile.FileName;
            pbFotoPersonal.Image = Utils.PictureBinary.GetImage(Utils.PictureBinary.GetBinary(txtFoto.Text));
               

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool validatorPersonal() 
        {
            Decimal d;
            if (txtCedula.Text.Length != 11 && !Decimal.TryParse(txtCedula.Text, out d)) return false;
            if (!txtCorreo.Text.Contains('@')) return false;
            if (!Decimal.TryParse(tbxSalario.Text, out d)) return false;
            if (txtTelefono.Text.Length != 10 && !Decimal.TryParse(txtTelefono.Text, out d)) return false;
            if (tbxUser.Text == string.Empty || tbxCont.Text == string.Empty) return false;
            return true;
        }
    }
}
