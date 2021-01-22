using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.ServiceModel;
using System.Web;
using UsuarioWCF.DAL.Segurity;
using UsuarioWCF.Models;

namespace UsuarioWCF.DAL.usuarioDAL
{
    public class UsuarioDAL
    {
        ///<summary >
        ///  Data Access Layer (DAL)
        /// </summary>

        #region InstaObj
        private Conexion conexion = new Conexion();
        private DataTable tb = new DataTable();
        #endregion

        #region Variable 
        // private SqlDataReader read;
        #endregion

        #region GetAllusuarioNombre
        public UsuarioModels GetAllUsuarioNombre(string Nombre)
        {
            using (SqlCommand comando = new SqlCommand())
            {
                UsuarioModels entity = new UsuarioModels();
                comando.Connection = conexion.OpenConexion();
                comando.CommandText = "spUsuarioAllId";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@PrmNombre", SqlDbType.VarChar, 100).Value = Nombre;

                using (SqlDataReader read = comando.ExecuteReader())
                {
                    if (read.HasRows)
                    {

                        while (read.Read())
                        {
                            entity.Nombre = read["Nombre"].ToString();
                            entity.FechaNacimiento = Convert.ToDateTime(read["FechaNacimiento"]);
                            entity.Sexo = Convert.ToChar(read["Sexo"].ToString());

                        }
                    }
                }
                conexion.CloseConexion();
                return entity;
            }
        }
        #endregion

        #region InsertUsuario
        public string AddUsuario(UsuarioModels emp)
        {
            string mensaje = "";
            try
            {
                using (SqlCommand comando = new SqlCommand())
                {
                    comando.Connection = conexion.OpenConexion();
                    comando.CommandText = "spUsuarioInsert";
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@Nombre", SqlDbType.VarChar, 50).Value = Convert.ToString(emp.Nombre);
                    comando.Parameters.Add("@FechaNacimiento", SqlDbType.Date).Value = emp.FechaNacimiento;
                    comando.Parameters.Add("@Sexo", SqlDbType.Char, 1).Value = Convert.ToString(emp.Sexo);
                    comando.ExecuteNonQuery();
                    comando.Parameters.Clear();
                    conexion.CloseConexion();

                }

            }
            catch (FaultException fex)
            {
                mensaje = "Error" + fex;
            }

            return mensaje;
        }

        #endregion

        #region EditUsuario
        public void UpUsuario(UsuarioModels emp)
        {

            using (SqlCommand comando = new SqlCommand())
            {

                comando.Connection = conexion.OpenConexion();
                comando.CommandText = "spUsuarioUpdate";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@PrmNombre", SqlDbType.VarChar, 100).Value = (emp.Nombre);
                comando.Parameters.Add("@PrmFechaNacimiento", SqlDbType.Date).Value = emp.FechaNacimiento;
                comando.Parameters.Add("@PrmSexo", SqlDbType.Char, 70).Value = Convert.ToString(emp.Sexo);
                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
                conexion.CloseConexion();


            }

        }

        #endregion

        #region DeleteUsuario
        public void DeleteUsuario(UsuarioModels emp)
        {
            using (SqlCommand comando = new SqlCommand())
            {
                comando.Connection = conexion.OpenConexion();
                comando.CommandText = "spUsuarioDelete";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@PrmNombre", SqlDbType.NVarChar, 100).Value = (emp.Nombre);
                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
                conexion.CloseConexion();

            }


        }

        #endregion

        #region GetAllusuario
        public List<UsuarioModels> GetAllUsuario()
        {


            using (SqlCommand comando = new SqlCommand())
            {
                List<UsuarioModels> items = new List<UsuarioModels>();

                comando.Connection = conexion.OpenConexion();
                comando.CommandText = "spUsuariosAll";
                comando.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader read = comando.ExecuteReader())
                {
                    if (read.HasRows)
                    {

                        while (read.Read())
                        {
                            UsuarioModels entity = new UsuarioModels();
                            entity.Nombre = read["Nombre"].ToString();
                            entity.FechaNacimiento = Convert.ToDateTime(read["FechaNacimiento"]);
                            entity.Sexo = Convert.ToChar(read["Sexo"].ToString());
                            items.Add(entity);
                        }

                    }
                }
                // tb.Load(read);
                conexion.CloseConexion();
                return items;
            }

        }
        #endregion
    }
}