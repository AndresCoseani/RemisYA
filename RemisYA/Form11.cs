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
    public partial class Form11 : Form
    {   
        public Form11()
        {
            InitializeComponent();
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            //carga choferes al combobox
            Choferes oChoferes = new Choferes();
            DataTable TabChoferes = oChoferes.GetData(); 
            
            CboChofer.DisplayMember = "nombre";
            CboChofer.ValueMember = "chofer";
            CboChofer.DataSource = TabChoferes;

            //fecha
            DateTime fechahoy = DateTime.Now;// hace una variable para guardar la fecha de hoy
            cboMes.SelectedIndex = fechahoy.Month -2;// pone la fecha en el combobox y le resta para que aparezca el mes actual porque el selected index empieza de 0
            textBox1.Text = fechahoy.Year.ToString();//pone el año actual en el textbox


        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();//limpia la grilla
            //crea los objetos y las tablas
            Barrios oBarrios = new Barrios();
            DataTable TabBarrios = oBarrios.GetData();
            Viajes oViajes = new Viajes();
            DataTable TabViajes = oViajes.GetData();

            //crea la variable para acumular
            Decimal Importetotal = 0;
            foreach (DataRow filaViaje in TabViajes.Rows)//recorre la tabla viajes
            {
                DateTime fecha = Convert.ToDateTime(filaViaje["fecha"]);//hace una variable para guardar las fechas
                string fechaViaje = fecha.ToString("dd/MM/yyyy");// pasa las fechas a string para ponerlas en formato dd/MM/yyyy

                //if que interpola y pregunta si la variable fechaviaje que guarda las fechas tiene el combobox elegido y el textbox lleno. y pregunta si el nombre
                //de la tabla de chofer y la elegida en el cbo son iguales
                if (fechaViaje.Contains($"{(cboMes.SelectedIndex + 2)}/{textBox1.Text}") && filaViaje["chofer"].ToString()== CboChofer.SelectedValue.ToString() )
                {
                    DataRow filaOrigen = TabBarrios.Rows.Find(filaViaje["desdebarrio"]);//busca en la tabla el origen de donde sale
                    DataRow filaDestino = TabBarrios.Rows.Find(filaViaje["hastabarrio"]);//busca en la tabla el destino 

                    decimal km =Convert.ToDecimal (filaViaje["km"]);//variable que guarda los kilometros
                    decimal importe = Convert.ToDecimal(filaViaje["importe"]);//variable que guarda el importe

                    Importetotal += importe;//acumulador de importe

                    dataGridView1.Rows.Add(fechaViaje, filaOrigen["nombre"], filaDestino["nombre"], km.ToString("N2"), importe.ToString("N2"));//muestra en la grilla
                }

            }
            if (Importetotal==0)
            {
                label5.Text = "_________";//limpia la etiqueta

            }
            else
            {
                label5.Text = Importetotal.ToString("N2");//muestra el importe total en la etiqueta
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
