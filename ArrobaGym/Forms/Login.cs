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
        private Models.Personal personal;
        public Login()
        {

            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            DAO.Repository<Models.Personal> PersonalDao = new DAO.Repository<Models.Personal>();
            try
            {
                personal = PersonalDao.SelectSingle(p => p.Usuario == tbxUsuario.Text );
                if (personal != null && personal.Contraseña == tbxContraseña.Text)
                {

                    MenuAdmin mn = new MenuAdmin(personal);
                    mn.Show();
                    this.Hide();

                }
                else
                    MessageBox.Show("Error de Autenticacion");
            }
            catch (Exception conException)
            {
                MessageBox.Show("Error de Conexión");
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        
    }
}
