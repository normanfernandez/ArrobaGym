﻿using System;
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
    public partial class Clientes_Membresias_Consultar : Form
    {
        public Clientes_Membresias_Consultar()
        {
            InitializeComponent();
        }

        private void Consultar_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clientes_Membresias_Cobrar cobro = new Clientes_Membresias_Cobrar();
            cobro.Visible = true;
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Clientes_Membresias_Cobrar_Historial history = new Clientes_Membresias_Cobrar_Historial();
            history.Visible = true; 
        }
    }
}
