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
    public partial class Form10 : Form
    {
        Choferes oChofer;
        Viajes oViaje;
        DataTable tViaje;
        public Form10()
        {
            InitializeComponent();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            oViaje = new Viajes();
            oChofer = new Choferes();
            tViaje = oViaje.GetData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime fecha = Convert.ToDateTime(dateTimePicker1.Text);
            int[] choferes = oChofer.Chofer();
            int[] chofer = new int[choferes.Length];
             

            int numeroChofer = 0;
            int i = 0;

            while (i < choferes.Length)
            {
                foreach (DataRow fila in tViaje.Rows)
                {
                    if (fecha == Convert.ToDateTime(fila["fecha"]))
                    {
                        if (choferes[i] == int.Parse(fila["chofer"].ToString()))
                        {
                            numeroChofer = -1;
                            break;
                        }
                        else
                        {
                            numeroChofer = choferes[i];
                        }

                    }
                    else
                    {
                        numeroChofer = choferes[i];

                    }
                }
                chofer[i] = numeroChofer;
                i++;
            }
            listBox1.Items.Clear();
            for (int f = 0; f < chofer.Length; f++)
            {
                if (chofer[f] != -1 && chofer[f] != 0)
                {
                    string nombre = oChofer.getNombre(chofer[f]);
                    listBox1.Items.Add(nombre);
                }
            }

        }
    }
    
}
