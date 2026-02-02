using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace CapaDatos.SQL
{
    internal class CD_ManagementSQL
    {
        private CD_Connection conn = new CD_Connection();

        //Ejecutar SP de inserción, eliminacion o actualizacion
        internal bool EjecutarSP_NonQuery(string nombre_sp, List<CD_SP_Parametros> lista_parametros)
        {
            var comando = new SqlCommand(); //instanciamos el SqlCommand
            //doy atributos al sqlcommand
            comando.CommandType = CommandType.StoredProcedure; //tipo SP
            comando.CommandText = nombre_sp; //nombre del SP

            //Añadir los parametros
            foreach (var parametro in lista_parametros)
                comando.Parameters.Add(parametro.NombreParametro, parametro.TipoParametro).Value = parametro.ValorParametro;

            comando.Connection = conn.AbrirConexion(); //abriendo la conexion
            var result = comando.ExecuteNonQuery(); //ejecuta el comando SQL
            if (result > 0)
                return true;
            else
                return false;
        }

        internal DataTable EjecutarSP_Query(string nombre_sp, List<CD_SP_Parametros> lista_parametros)
        {
            var comando = new SqlCommand(); //instanciamos el SqlCommand
            //doy atributos al sqlcommand
            comando.CommandType = CommandType.StoredProcedure;//comando tipo PS
            comando.CommandText = nombre_sp; //nombre del SP
            //Añadir los parámetros}
            foreach (var parametro in lista_parametros)
                comando.Parameters.Add(parametro.NombreParametro, parametro.TipoParametro).Value = parametro.ValorParametro;

            comando.Connection = conn.AbrirConexion(); //abriendo la conexion

            SqlDataReader reader = comando.ExecuteReader(); //ejecutar comando SQL

            using (var tabla = new DataTable())
            {
                tabla.Load(reader);
                reader.DisposeAsync();
                conn.CerrarConexion();
                return tabla;
            }

        }
    }
}
