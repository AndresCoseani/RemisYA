using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace RemisYA
{
    class Viajes
    {
        OleDbConnection conector;
        OleDbCommand comando;
        OleDbDataAdapter adaptador;
        DataTable tabla;

        public Viajes()
        {
            conector = new OleDbConnection("provider=microsoft.jet.oledb.4.0;data source=REMISYA.mdb");

            comando = new OleDbCommand();

            comando.Connection = conector;
            comando.CommandType = CommandType.TableDirect;
            comando.CommandText = "Viajes";

            adaptador = new OleDbDataAdapter(comando);
            tabla = new DataTable();
            adaptador.Fill(tabla);

            DataColumn[] vec = new DataColumn[1];
            vec[0] = tabla.Columns["viaje"];
            tabla.PrimaryKey = vec;


        }

            public DataTable GetData()
            {
                return tabla;
            }
    }
}
