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
    public partial class Form4 : Form
    {
    
        DataTable tabViajes;
        Choferes oChoferes;
        Viajes oViajes;
       
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            oChoferes = new Choferes();
           
            oViajes = new Viajes();
            tabViajes = oViajes.GetData();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            DateTime desde = Convert.ToDateTime(dateTimePicker1.Text);//se le asigna a desde y hasta los dtp
            DateTime hasta = Convert.ToDateTime(dateTimePicker2.Text);

            
                foreach (DataRow fViajes in tabViajes.Rows)//recorre las filas de la tabla viajes
                {
                    if (Convert.ToDateTime(fViajes["fecha"]) >= desde && Convert.ToDateTime(fViajes["fecha"])<= hasta)//si fecha es > o = a desde y <= a hasta entra 
                    {
                        string chofer = oChoferes.getNombre(Convert.ToInt32(fViajes["chofer"].ToString()));//guarda en la variable chofer el nombre convertido de int a  string
                        DateTime fecha = Convert.ToDateTime(fViajes["fecha"]);//crea la  variable fecha que guarda las fechas de la tabla
                        dataGridView1.Rows.Add(fViajes["viaje"], fecha.ToString("dd/MM/yy"), chofer, fViajes["importe"]);//muestra
                    }
                    else
                    {
                         MessageBox.Show("No se  realizaron viajes  en  esa  fecha");//si se pone  una  fecha que no  hay viajes muestra el mensaje
                    }
                }
            
        }
    }
}
