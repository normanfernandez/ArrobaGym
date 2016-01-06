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

            };
            personalDAO.Insert(Personal);
            personalDAO.SaveAll();
            MessageBox.Show("Empleado Insertado con Exito");
        }
    }
}
