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
        private string nombre;
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
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

        public DataRow Buscar(int chofer)//preguntar porque se le pasa int chofer
        {

            DataRow fila = tabla.Rows.Find(chofer);//busca por filas en la columna chofer
            return fila;//devuelve la fila en donde esta el chofer buscado

        }
        public void Modificar()//Graba pero no modifica
        {
            DataRow fila = tabla.NewRow();//crea la fila
            fila["chofer"] = chofer;
            fila["nombre"] = nombre;// se le asigna a la variable nombre y chofer lo que se ponga en nombre y chofer
            tabla.Rows.Add(fila);//agrega una fila llamada fila a la tabla

            OleDbCommandBuilder cb = new OleDbCommandBuilder(adaptador);//traduce
            adaptador.Update(tabla);//actualiza la tabla

        }
        
       
    

    }
}
