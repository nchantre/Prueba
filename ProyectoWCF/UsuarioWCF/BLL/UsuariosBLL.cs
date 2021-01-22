using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using UsuarioWCF.DAL.usuarioDAL;
using UsuarioWCF.Models;

namespace UsuarioWCF.BLL
{
    public class UsuariosBLL
    {
        #region insObj
        private DataTable tb = new DataTable();
        #endregion

        #region MethodGetAllUsuarioNombre
        public UsuarioModels GetAllUsuarioNombre(string Nombre)
        {
            UsuarioModels companyModels = new UsuarioModels();
            UsuarioDAL usuarioDAL = new UsuarioDAL();
            companyModels = usuarioDAL.GetAllUsuarioNombre(Nombre);
            return companyModels;
        }
        #endregion

        #region MethodAddUsuario
        public string AddUsuario(UsuarioModels ms)
        {
            string mensaje = "hola";
            UsuarioDAL usuarioDAL = new UsuarioDAL();
            usuarioDAL.AddUsuario(ms);
            return mensaje;
        }
        #endregion

        #region MethodUpUsuario
        public void UpUsuario(UsuarioModels ms)
        {
            UsuarioDAL usuarioDAL = new UsuarioDAL();
            usuarioDAL.UpUsuario(ms);
        }
        #endregion

        #region MethodDeleteUsuario
        public void DeleteUsuario(UsuarioModels ms)
        {
            UsuarioDAL usuarioDAL = new UsuarioDAL();
            usuarioDAL.DeleteUsuario(ms);
        }
        #endregion

        #region MethodGetAllUsuario
        public List<UsuarioModels> GetAllUsuario()
        {
            List<UsuarioModels> items = new List<UsuarioModels>();
            UsuarioDAL usuarioDAL = new UsuarioDAL();
            items = usuarioDAL.GetAllUsuario();
            return items;
        }
        #endregion
    }
}