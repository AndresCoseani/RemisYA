using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace RemisYA
{
    class ClaseBarrio
    {
        OleDbConnection conector;
        OleDbCommand comando;
        OleDbDataAdapter adaptador;
        DataTable tabla;
        
        public ClaseBarrio()
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
        public bool grabar(int barrio, string nombre)
        {
            bool OK=true;

            DataRow filabuscada = tabla.Rows.Find(barrio);
            if(filabuscada==null)
            {
                foreach(DataRow fbarrio in tabla.Rows)
                {
                    if(fbarrio["nombre"].ToString() == nombre)
                    {
                        OK = false;
                    }
                    if(OK==true)
                    {
                        DataRow fila = tabla.NewRow();
                        fila["barrio"] = barrio;
                        fila["nombre"] = nombre;
                        tabla.Rows.Add(fila);
                        OleDbCommandBuilder cb = new OleDbCommandBuilder();
                        adaptador.Update(tabla);
                    }
                }
                
               
               
            }
            else
            {
                OK= false;

            }
            return OK;
        }
}
}
      
