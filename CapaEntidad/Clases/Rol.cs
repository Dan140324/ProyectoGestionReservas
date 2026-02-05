using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.Clases
{

    //Entidad utilizada para cargar combos u otros usos donde solo se necesite el Id y Nombre del rol
    public class Rol
    {
        public int IdRol { get; set; }
        public string NombreRol { get; set; }
    }
}
