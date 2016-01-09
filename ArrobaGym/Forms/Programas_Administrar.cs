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
    public partial class Programas_Administrar : Form
    {
        private Models.Programas programa; 
        DAO.Repository<Models.Programas> ProgramaDAO = new DAO.Repository<Models.Programas>();
        public Programas_Administrar()
        {
            InitializeComponent();
            comboBox1.DataSource = ProgramaDAO.SelectAll().Select(
             p => new { p.Id, p.Descripcion }
             ).ToList();
            comboBox1.DisplayMember = "Descripcion";
            comboBox1.ValueMember = "Id";
            rellenar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DAO.Repository<Models.Programas> programaDAO = new DAO.Repository<Models.Programas>();
            programa = ProgramaDAO.SelectSingle(p => p.Id == comboBox1.SelectedIndex);
            programa.Precio_Inscripcion = decimal.Parse(tbxInscripcion.Text);
            programa.Precio_periodo = decimal.Parse(tbxMensualidad.Text);
            programaDAO.SaveAll();
           
            MessageBox.Show("Modificado con exito");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            rellenar();
            
        }
        private void rellenar() 
        {
            programa = ProgramaDAO.SelectSingle(p => p.Descripcion == comboBox1.SelectedText);
            //programa.Precio_Inscripcion = decimal.Parse(tbxInscripcion.Text);
            if (programa != null)
            {
                tbxInscripcion.Text = Convert.ToString(programa.Precio_Inscripcion);
                tbxMensualidad.Text = Convert.ToString(programa.Precio_periodo);
            }
        }
    }
}
