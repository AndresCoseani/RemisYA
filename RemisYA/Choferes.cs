using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;

namespace RemisYA
{
    class Choferes
    {
        private int choferID;
        private string nombre;
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public int ChoferID
        {
            get { return choferID; }
            set { choferID = value; }
        }

        OleDbConnection conector;
        OleDbCommand comando;
        OleDbDataAdapter adaptador;
        DataTable tabla;

        public Choferes()
        {
            conector = new OleDbConnection("provider=microsoft.jet.oledb.4.0;data source=REMISYA.mdb");

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

        public DataTable GetData()
        {
            return tabla;
        }
        public string getNombre(int chofer)//se usa para buscar el nombre referente al numero de cada chofer
        {
            DataRow filanombre = tabla.Rows.Find(chofer);//busca el nombre del chofer en la tabla
            return filanombre["nombre"].ToString();//devuelve el numero de ID del chofer en string
        }
    }
}
