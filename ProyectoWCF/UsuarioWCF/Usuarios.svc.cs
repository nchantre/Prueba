using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using UsuarioWCF.BLL;
using UsuarioWCF.Models;

namespace UsuarioWCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IUsuarios
    {
        private DataSet tb = new DataSet();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Nombre"></param>
        /// <returns></returns>
        public UsuarioModels GetAllUsuarioNombre(string Nombre)
        {
            UsuarioModels items = new UsuarioModels();
            UsuariosBLL usuarioBLL = new UsuariosBLL();
            items = usuarioBLL.GetAllUsuarioNombre(Nombre);
            return items;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>

        public string AddUsuario(UsuarioModels ms)
        {
            string mensaje = "";
            UsuariosBLL usuarioBLL = new UsuariosBLL();
            usuarioBLL.AddUsuario(ms);
            return mensaje;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ms"></param>
        /// <returns></returns>
        public void UpUsuario(UsuarioModels ms)
        {
            UsuariosBLL usuarioBLL = new UsuariosBLL();
            usuarioBLL.UpUsuario(ms);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="ms"></param>

        public void DeleteUsuario(UsuarioModels ms)
        {
            UsuariosBLL usuarioBLL = new UsuariosBLL();
            usuarioBLL.DeleteUsuario(ms);
        }

        /// <summary>
        /// 
        /// </summary>
        /// 
        public List<UsuarioModels> GetAllUsuario()
        {
            List<UsuarioModels> items = new List<UsuarioModels>();
            UsuariosBLL usuarioBLL = new UsuariosBLL();
            items = usuarioBLL.GetAllUsuario();
            return items;
        }

    }
}
