using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace RemisYA
{
    class Barrios
    {
        OleDbConnection conector;
        OleDbCommand comando;
        OleDbDataAdapter adaptador;
        DataTable tabla;

        public Barrios()
        {
            conector = new OleDbConnection("provider=microsoft.jet.oledb.4.0;data source=REMISYA.mdb");
            comando = new OleDbCommand();

            comando.Connection = conector;
            comando.CommandType = CommandType.TableDirect;
            comando.CommandText = "Barrios";

            adaptador = new OleDbDataAdapter(comando);

            tabla = new DataTable();

            adaptador.Fill(tabla);

            DataColumn[] vec = new DataColumn[1];
            vec[0] = tabla.Columns["Barrio"];
            tabla.PrimaryKey = vec;
        }
        public bool grabar(int barrio, string nombre)//le pasamos al  formulario 2 variables
        {
            bool OK = true;//asignamos a la variable booleana true(bandera)

            DataRow filabuscada = tabla.Rows.Find(barrio);//busca las filas en la columna barrio de la tabla
            if (filabuscada == null)//pregunta si la fila esta nula para que no se repita el numero que se pueda ingresar
            {
                foreach (DataRow fbarrio in tabla.Rows)//recorre las filas de la tabla
                {
                    if (fbarrio["nombre"].ToString() == nombre)//pregunta si el nombre de la fila que encontro es = a la variable nombre
                    {
                        OK = false;//si es igual se baja la bandera
                    }
                    if (OK == true)//si no es igual pregunta de nuevo si la bandera sigue en true
                    {
                        DataRow fila = tabla.NewRow();//crea una variable para agregar filas
                        fila["barrio"] = barrio;//guarda lo que se ingresa en barrio
                        fila["nombre"] = nombre;//guarda lo que se ingresa en nombre
                        tabla.Rows.Add(fila);//agrega filas a la tabla
                        OleDbCommandBuilder cb = new OleDbCommandBuilder();//traduce el comando desde c# a access
                        adaptador.Update(tabla);//actualiza la tabla
                    }
                }



            }
            else
            {
                OK = false;

            }
            return OK;
        }

        public DataTable GetData()
        {
            return tabla;
        }


    }
}

