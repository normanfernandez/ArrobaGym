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
        DAO.Repository<Models.Programas> ProgramaDAO = new DAO.Repository<Models.Programas>();
        public Programas_Administrar()
        {
            InitializeComponent();
            comboBox1.DataSource = ProgramaDAO.SelectAll().Select(
             p => new { p.Id, p.Descripcion }
             ).ToList();
            comboBox1.DisplayMember = "Descripcion";
            comboBox1.ValueMember = "Id";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            
        }
    }
}
