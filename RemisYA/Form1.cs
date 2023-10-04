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
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Datos oChofer = new Datos();

            DataRow fila = oChofer.Buscar(Convert.ToInt32(textBox2.Text));
            if (fila != null)
            {
                textBox1.Text = fila["nombre"].ToString();

            }
            else
            {
                MessageBox.Show("EL NUMERO INGRESADO NO CORRESPONDE A NINGUN CHOFER");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Datos oNombre = new Datos();
           
            oNombre.Chofer = Convert.ToInt32(textBox2.Text);
            oNombre.Nombre = textBox1.Text;

            oNombre.Modificar();

            textBox1.Text = " ";
            textBox2.Text = " ";
        }
    }
}
