using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ArrobaGym.DAO;

namespace ArrobaGym
{
    public partial class Programa_Agregar : Form
    {
        Repository<Models.Programa> ProgramaDAO = new Repository<Models.Programa>();

        public Programa_Agregar()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.Validate())
            {
                Models.Programa programa = new Models.Programa
                {
                    Descripcion = textBox6.Text,
                    Precio_Inscripcion = Decimal.Parse(textBox1.Text),
                    Precio_periodo = Decimal.Parse(textBox2.Text)
                };
                try
                {
                    ProgramaDAO.Insert(programa);
                    ProgramaDAO.SaveAll();
                    MessageBox.Show("Programa agregado con éxito!");
                    this.Dispose();
                }
                catch (Exception ee)
                {
                    MessageBox.Show("Error al agregar Programa!");
                }
            }
            else
            {
                MessageBox.Show("Campos no válidos!");
            }
        }

        public new bool Validate()
        {
            Decimal d;
            if (textBox6.Text == string.Empty)
                return false;
            if (!Decimal.TryParse(textBox1.Text, out d))
                return false;
            if (!Decimal.TryParse(textBox2.Text, out d))
                return false;
            return true;
        }
    }
}
