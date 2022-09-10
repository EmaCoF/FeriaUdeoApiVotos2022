
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoriosVotos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoriosVotos.Repository
{
    public class VotoRepository:IVotoRepository
    {
        private readonly FeriaUdeo2022Context _context;
        public VotoRepository(FeriaUdeo2022Context context)
        {
            _context = context;
        }

        public async Task<int> CrearVotoAsync(string User, int IdUser,int IdProyecto, int Voto)
        {
            try
            {
                
                if (_context.Usuarios.Where(x => x.IdUsuario == IdUser && EF.Functions.Collate(x.Usuario1, "SQL_Latin1_General_CP1_CS_AS") == User).FirstOrDefault() != null)
                {

                    VotoUsuario NewVoto = new VotoUsuario
                    {
                        IdProyecto = IdProyecto,
                        IdUsuario = IdUser,
                        Puntuacion = Voto
                    };
                    _context.VotoUsuarios.Add(NewVoto);
                    var proyecto = _context.Proyectos.FirstOrDefault(x => x.IdProyecto == IdProyecto);
                    proyecto.Votos = proyecto.Votos + Voto;
                    await _context.SaveChangesAsync();
                    return 200;
                }
                else {
                    return 404;
                }
                
            }
            catch (Exception)
            {
                return 500;
            }   
        }


        public async Task<int> CambiarVoto(string User, int IdUser, int IdProyecto, int Voto)
        {
            try
            {

                if (_context.Usuarios.Where(x => x.IdUsuario == IdUser && EF.Functions.Collate(x.Usuario1, "SQL_Latin1_General_CP1_CS_AS") == User).FirstOrDefault() != null)
                {

                    var registro = _context.VotoUsuarios.Where(x=>x.IdProyecto==IdProyecto && x.IdUsuario==IdUser).FirstOrDefault();
                    if (registro==null)
                    {
                        return 404;
                    }
                    int sumador = Voto-Convert.ToInt16(registro.Puntuacion);
                    var proyecto = _context.Proyectos.FirstOrDefault(x => x.IdProyecto == IdProyecto);

                    registro.Puntuacion = Voto;
                    proyecto.Votos = proyecto.Votos + sumador;
                    await _context.SaveChangesAsync();
                    return 200;
                }
                else
                {
                    return 404;
                }

            }
            catch (Exception)
            {
                return 500;
            }
        }


    }
}
