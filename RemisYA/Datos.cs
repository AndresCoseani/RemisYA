﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;

namespace RemisYA
{
    class Datos
    {
        OleDbConnection conector;
        OleDbCommand comando;
        OleDbDataAdapter adaptador;
        DataTable tabla;

        private int chofer;

        public int Chofer
        {
            get { return chofer; }
            set { chofer = value; }
        }


        public Datos()
        {
            conector = new OleDbConnection("provider = microsoft.jet.oledb.4.0; data source = REMISYA.mdb");
            comando = new OleDbCommand();

            comando.Connection = conector;
            comando.CommandType = CommandType.TableDirect;
            comando.CommandText = "Choferes";

            adaptador = new OleDbDataAdapter(comando);
            tabla = new DataTable();
            adaptador.Fill(tabla);

            DataColumn[] vec = new DataColumn[1];
            vec[0] = tabla.Columns["chofer"];
            tabla.PrimaryKey = vec;
        }

        public void Buscar(TextBox textBox1)
        {

            DataRow Chofer = tabla.Rows.Find(chofer);

            if (Chofer != null)
            {
                string nombreChofer = Chofer["chofer"].ToString();

                
                textBox1.Text = nombreChofer;
            }

        }
        public DataTable Mostrar()
        {
            return tabla;
            
        }
    

    }
}
