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


        [HttpPut]
        public async Task<ActionResult<string>> PutVoto(VotosModel mensaje)
        {

            if (mensaje.voto > 5 || mensaje.voto < 0)
            {
                return BadRequest();
            }
            if (!await _votosRepository.GetEventoVotoAsync())
            {
                return Unauthorized();
            }
            var respuesta = await _votosRepository.CambiarVoto(mensaje.usuario, mensaje.idUsuario, mensaje.idProyecto, mensaje.voto);

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
                    return Created("Voto añadido","");
                    break;

                default: return Problem("Error");
            }
        }


    }
}
