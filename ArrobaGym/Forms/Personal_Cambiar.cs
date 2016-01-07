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

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.ShowDialog();
            tbxFoto.Text = openfile.FileName;
        }
    }
}