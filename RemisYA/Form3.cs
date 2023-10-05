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
    public partial class Form3 : Form
    {
        DataTable TabViajes;
        DataTable TabChoferes;


        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Viajes oTotalRec = new Viajes();//creo la objeto
            TabViajes = oTotalRec.GetData(); //traigo la tabla con el metodo
             Choferes oChofer = new Choferes();
            TabChoferes = oChofer.GetData();
            dataGridView1.Rows.Clear();
            foreach (DataRow fchoferes in TabChoferes.Rows)//hago que recorra todas la FILAS de chofer en la TABLA DE CHOFER (TaCchoferes)
            {
                decimal total = 0;//variable para acumular el total
                foreach (DataRow fViaje in TabViajes.Rows)//hago que recorra todas la FILAS de Viaje en la TABLA DE VIAJES (Tabviajes)
                {
                    if (fchoferes["chofer"].ToString() == fViaje["chofer"].ToString())//pregunta  si la fchofer de la TabCcoferes es = a la fViajes de la TabViajes
                    {
                        total += Convert.ToDecimal(fViaje["importe"]);//le sumo al total el importe
                    }
                    dataGridView1.Rows.Add(fchoferes["nombre"], total);//agrego las filas para mostrarlo

                }
                  
                
            }
        }
    }
}
