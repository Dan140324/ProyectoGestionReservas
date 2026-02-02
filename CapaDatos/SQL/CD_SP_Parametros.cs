using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CapaDatos.SQL
{
    internal class CD_SP_Parametros
    {
        private string nombre_parametro;
        private SqlDbType tipo_parametro;
        private object valor_parametro;

        public CD_SP_Parametros()
        {
            nombre_parametro = string.Empty;
            tipo_parametro = SqlDbType.VarChar;
            valor_parametro = string.Empty;
        }

        public CD_SP_Parametros(string nombre_parametro, SqlDbType tipo_parametro, object valor_parametro)
        {
            this.nombre_parametro = nombre_parametro;
            this.tipo_parametro = tipo_parametro;
            this.valor_parametro = valor_parametro;
        }

        public string NombreParametro
        {
            get { return nombre_parametro; }
            set { nombre_parametro = value; }
        }

        public SqlDbType TipoParametro
        {
            get { return tipo_parametro; }
            set { tipo_parametro = value; }
        }

        public object ValorParametro
        {
            get { return valor_parametro; }
            set { valor_parametro = value; }
        }
    }
}

