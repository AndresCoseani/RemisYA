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
           
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            ParteNombreForm2 oNombre = new ParteNombreForm2();// crea el  objeto
            tabla= oNombre.GetData();//trae la tabla de la clase
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();//limpia la  grilla
            foreach (DataRow fila in tabla.Rows)// lee  cada  fila  de la  tabla
            {
                string dato1 = fila["nombre"].ToString().ToUpper();//crea una variable que guarda los nombres en las  filas y  TOUPPER  es  para pasarlo a Mayusculas
                string dato2 = textBox1.Text.ToUpper();//crea una  variable que guarda lo que se ingresa en el  textbox
                int posicion = dato1.IndexOf(dato2);// crea una variable entera que busca en el Dato1(osea los nombres)  lo que se escribe en el dato2(osea en el textbox)
                if (posicion != -1)//pregunta si encuentra un nombre que tenga lo que se escribio
                {
                    dataGridView1.Rows.Add(fila["chofer"], fila["nombre"]);//muestra en la fila chofer el numero y en la fila nombre el nombre del chofer
                }
            }
        }
    }
}
