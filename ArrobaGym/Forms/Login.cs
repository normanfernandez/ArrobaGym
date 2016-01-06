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
    public partial class Login : Form
    {
        public Login()
        {
            
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            MenuAdmin mn = new MenuAdmin();
            mn.Show();
            this.Hide();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
