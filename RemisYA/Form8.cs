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
        Barrios oBarrio;
        public Form8()
        {
            InitializeComponent();
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show("COMPLETE LOS DATOS", "ERROR");
                }
                else
                {
                    bool ok = oBarrio.grabar(Convert.ToInt32(textBox1.Text), textBox2.Text.ToUpper());
                    if (ok == false)
                    {
                        MessageBox.Show("EL NUMERO O EL NOMBRE DEL BARRIO ESTA REPETIDO", "ERROR");
                    }
                    else
                    {
                        textBox1.Text = "";
                        textBox2.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("BARRIO DEBE SER NUMERICO", "ERROR");
            }

        }

        private void Form8_Load(object sender, EventArgs e)
        {
            Barrios oBarrio = new Barrios();
        }
    }
}
