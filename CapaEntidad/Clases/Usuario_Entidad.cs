using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CapaEntidad.Clases
{
    public class Usuario_Entidad
    {
        private int IdUsuario;
        private string NombreUsuario;
        private string Contrasena;

        private int IdRol;
        private string Rol;// Opcional (para mostrar)

        private int IdEstado;
        private string Estado; //para mostrar

        public Usuario_Entidad(int idUsuario, string nombreUsuario, string contrasena, int idRol, string rol, int idEstado, string estado)
        {
            this.IdUsuario = idUsuario;
            this.NombreUsuario = nombreUsuario;
            this.Contrasena = claveHash;
            this.IdRol = idRol;
            this.Rol = rol;
            this.IdEstado = idEstado;
            this.Estado = estado;
        }

        public int idUsuario
        {
            get { return IdUsuario; }
            set { IdUsuario = value; }
        }

        [Required(ErrorMessage = "El nombre de usuario es obligatorio.")]
        public string nombreUsuario
        {
            get { return NombreUsuario; }
            set { NombreUsuario = value; }
        }

        [Required(ErrorMessage = "La clave es obligatoria.")]
        public string claveHash
        {
            get { return Contrasena; }
            set { Contrasena = value; }
        }

        [Required(ErrorMessage = "El rol es obligatorio.")]
        public int idRol
        {
            get { return IdRol; }
            set { IdRol = value; }
        }

        public string rol
        {
            get { return Rol; }
            set { Rol = value; }
        }

        public int idEstado
        {
            get { return IdEstado; }
            set { IdEstado = value; }
        }

        public string estado
        {
            get { return Estado; }
            set { Estado = value; }
        }

    }
}
