using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoriosVotos.Repository
{
    public interface IVotoRepository
    {
        Task<int> CrearVotoAsync(string User, int IdUser, int IdProyecto, int Voto);
        Task<int> CambiarVoto(string User, int IdUser, int IdProyecto, int Voto);
    }
}
