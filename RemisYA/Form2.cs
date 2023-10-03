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
    public partial class Form2 : Form
    {
        DataTable tabla;
        public Form2()
        {
            InitializeComponent();
            tabla = new DataTable();
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            ParteNombreForm2 oNombre = new ParteNombreForm2();
            oNombre.GetData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            foreach (DataRow fila in tabla.Rows)
            {
                string dato1 = fila["nombre"].ToString().ToUpper();
                string dato2 = textBox1.Text.ToUpper();
                int posicion = dato1.IndexOf(dato2);
                if (posicion != -1)
                {
                    dataGridView1.Rows.Add(fila["chofer"], fila["nombre"]);
                }
            }
        }
    }
}
