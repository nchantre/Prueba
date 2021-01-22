using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using UsuarioWCF.Models;

namespace UsuarioWCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IUsuarios
    {
        [OperationContract]
        UsuarioModels GetAllUsuarioNombre(string Nombre);

        [OperationContract]
        string AddUsuario(UsuarioModels company);

        [OperationContract]
        void UpUsuario(UsuarioModels company);

        [OperationContract]
        void DeleteUsuario(UsuarioModels company);


        [OperationContract]
        List<UsuarioModels> GetAllUsuario();



    }
 
    
}
