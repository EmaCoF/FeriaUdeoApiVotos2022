using FeriaUdeoVotos2022.ModelsApi;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoriosVotos.Repository;

namespace FeriaUdeoVotos2022.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VotosController : ControllerBase
    {
        
        private readonly IVotoRepository _votosRepository;
        public VotosController(IVotoRepository dataRepository)
        {
            _votosRepository = dataRepository;
        }

        [HttpPost]
        public async Task<ActionResult<string>> PostVoto(VotosModel mensaje)
        {

            if (mensaje.voto > 5 || mensaje.voto < 0)
            {
                return BadRequest();
            }

            var respuesta = await _votosRepository.CrearVotoAsync(mensaje.usuario, mensaje.idUsuaio, mensaje.idProyecto, mensaje.voto);
            
            switch (respuesta)
            {
                case 500:
                case 0:
                    return Problem("Error");
                    break;

                case 404:
                    return NotFound("Usuario no valido");
                    break;
                case 200:
                    return Ok("Voto añadido");
                    break;
                
                default: return Problem("Error");
            }
        }

        [HttpPut]
        public async Task<ActionResult<string>> PutVoto(VotosModel mensaje)
        {

            if (mensaje.voto > 5 || mensaje.voto < 0)
            {
                return BadRequest();
            }

            var respuesta = await _votosRepository.CambiarVoto(mensaje.usuario, mensaje.idUsuaio, mensaje.idProyecto, mensaje.voto);

            switch (respuesta)
            {
                case 500:
                case 0:
                    return Problem("Error");
                    break;

                case 404:
                    return NotFound("Usuario no valido");
                    break;
                case 200:
                    return Ok("Voto añadido");
                    break;

                default: return Problem("Error");
            }
        }


    }
}
