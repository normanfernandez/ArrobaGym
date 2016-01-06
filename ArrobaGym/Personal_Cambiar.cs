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
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
