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
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            programa = ProgramaDAO.SelectAll().First();
            rellenar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (validateprogram()) 
            { 
                programa = ProgramaDAO.SelectSingle(p => p.Id == (int)comboBox1.SelectedValue);
                programa.Precio_Inscripcion = decimal.Parse(tbxInscripcion.Text);
                programa.Precio_periodo = decimal.Parse(tbxMensualidad.Text);
                ProgramaDAO.SaveAll();
           
               MessageBox.Show("Modificado con exito");
               this.Close();
               
            }
            else {
                MessageBox.Show("error al introducir datos");
            }


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
            if (programa != null)
            {
                tbxInscripcion.Text = Convert.ToString(programa.Precio_Inscripcion);
                tbxMensualidad.Text = Convert.ToString(programa.Precio_periodo);
            }
        }
        private bool validateprogram() 
        {
            Decimal d;
            if (!Decimal.TryParse(tbxInscripcion.Text, out d)) return false;
            if (!Decimal.TryParse(tbxMensualidad.Text, out d)) return false;
            return true; 
        }
    }
}
