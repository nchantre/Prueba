using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace UsuarioWCF.DAL.Segurity
{
    public class Conexion
    {
        /// <summary>
        /// Clase para la conexion a la bd supcriptionBD
        /// </summary>

        #region CadenaConexion
        private SqlConnection Con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString);

        #endregion

        #region MethodOpen 
        public SqlConnection OpenConexion()
        {
            if (Con.State == ConnectionState.Closed)
                Con.Open();
            return Con;
        }
        #endregion

        #region MethodClose
        public SqlConnection CloseConexion()
        {
            if (Con.State == ConnectionState.Open)
                Con.Close();
            return Con;
        }
        #endregion
    }
}