using System;
using System.Collections.Generic;

namespace RepositoriosVotos.Models
{
    public partial class Evento
    {
        public int IdEvento { get; set; }
        public string Nombre { get; set; } = null!;
        public bool Activo { get; set; }
    }
}
