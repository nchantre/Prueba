using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace UsuarioWCF.Models
{
    [DataContract]
    public class UsuarioModels
    {
        public UsuarioModels()
        {
        }
        #region Nombre
        [DataMember]
        public string Nombre { get; set; }
        #endregion

        #region FechaNacimiento
        [DataMember]
        public DateTime FechaNacimiento { get; set; }
        #endregion

        #region Sexo
        [DataMember]
        public char Sexo { get; set; }
        #endregion
    }
}