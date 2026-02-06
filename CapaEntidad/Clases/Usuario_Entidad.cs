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
        //Constructor para Binding
        public Usuario_Entidad()
        {
        }

        public Usuario_Entidad(string usuario, string contrasena, string nombreUsuario, int idRol, int idEstado)
        {
            this.Usuario = usuario;
            this.Contrasena = contrasena;
            this.NombreUsuario = nombreUsuario;
            this.IdRol = idRol;
            this.IdEstado = idEstado;
        }

        public Usuario_Entidad(int idUsuario, string usuario, string nombreUsuario, string contrasena,
                               int idRol, string nombreRol, int idEstado, string nombreEstado)
        {
            this.IdUsuario = idUsuario;
            this.Usuario = usuario;
            this.NombreUsuario = nombreUsuario;
            this.Contrasena = contrasena;
            this.IdRol = idRol;
            this.NombreRol = nombreRol;
            this.IdEstado = idEstado;
            this.NombreEstado = nombreEstado;
        }

        [DisplayName("ID")]
        public int IdUsuario { get; set; }

        [DisplayName("Usuario")]
        [Required(ErrorMessage = "El usuario es obligatorio.")]
        [StringLength(50, ErrorMessage = "El usuario no puede exceder 50 caracteres.")]
        public string Usuario { get; set; }


        [DisplayName("Nombre Completo")]
        [Required(ErrorMessage = "El nombre completo es obligatorio.")]
        [StringLength(50, ErrorMessage = "El nombre no puede exceder 50 caracteres.")]
        public string NombreUsuario { get; set; }


        [DisplayName("Contraseña")]
        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [StringLength(255, ErrorMessage = "La contraseña no puede exceder 255 caracteres.")]
        public string Contrasena { get; set; }


        [DisplayName("ID Rol")]
        [Required(ErrorMessage = "El rol es obligatorio.")]
        public int IdRol { get; set; }


        [DisplayName("Rol")]
        public string NombreRol { get; set; }


        [DisplayName("ID Estado")]
        [Required(ErrorMessage = "El estado es obligatorio.")]
        public int IdEstado { get; set; }


        [DisplayName("Estado")]
        public string NombreEstado { get; set; }


        //Propiedades auxiliares
        //Saber si es nuevo usuario
        public bool EsNuevo => IdUsuario == 0;

        //Validar si admin
        public bool EsAdministrador => IdRol == 1 || NombreRol?.ToLower() == "administrador";

        //Validar activo
        public bool EstaActivo => IdEstado == 1 || NombreEstado?.ToLower() == "activo";
    }
}