using System;
using System.Collections.Generic;

namespace FeriaUdeoVotos2022.Models
{
    public partial class SupervisorProyecto
    {
        public int IdSupervisorProyecto { get; set; }
        public int? IdProyecto { get; set; }
        public int? IdUsuario { get; set; }

        public virtual Proyecto? IdProyectoNavigation { get; set; }
        public virtual Usuario? IdUsuarioNavigation { get; set; }
    }
}
