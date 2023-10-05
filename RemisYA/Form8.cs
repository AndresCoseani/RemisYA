using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemisYA
{
    public partial class Form8 : Form
    {
        ClaseBarrio oBarrios;
        public Form8()
        {
            InitializeComponent();
            ClaseBarrio oBarrios = new ClaseBarrio();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                bool OK = oBarrios.grabar(Convert.ToInt32(textBox1.Text), textBox2.Text.ToUpper());
                if (OK == false)
                {
                    MessageBox.Show("Numero ingresado ya existente");

                }
                else
                {
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Barrio debe ser numerico");
            }
            
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            ClaseBarrio oBarrio = new ClaseBarrio();
        }
    }
}
