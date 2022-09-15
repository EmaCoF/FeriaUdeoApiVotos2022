using System;
using System.Collections.Generic;

namespace FeriaUdeoVotos2022.Models
{
    public partial class CategoriaProyecto
    {
        public CategoriaProyecto()
        {
            Proyectos = new HashSet<Proyecto>();
        }

        public int IdCategoria { get; set; }
        public string? Nombre { get; set; }

        public virtual ICollection<Proyecto> Proyectos { get; set; }
    }
}
