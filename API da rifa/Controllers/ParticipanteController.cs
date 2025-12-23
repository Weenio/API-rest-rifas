using API_da_rifa.Model;
using API_da_rifa.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API_da_rifa.Controllers
{
    [ApiController]
    [Route("api/v1/participante")]
    public class ParticipanteController : ControllerBase
    {
        private readonly IParticipanteRepository _participanteRepository;

        public ParticipanteController(IParticipanteRepository participanteRepository)
        {
            _participanteRepository = participanteRepository;
        }

        //Extrema atenção aqui: Os dados do JSON DEVEM ser formatados como no exemplo:
        /*
         * {
         * "Nome": "Guilherme",
         * "dataNascimento": "1995-12-22",
         * "numeroTelefone": "11999999999",
         * "numeroComprado": 42
         * }
         */
        [HttpPost]
        public IActionResult Add([FromBody] ParticipanteCreateDTO dto)
        {
            var participante = new Participante(
                dto.Nome,
                dto.DataNascimento,
                dto.NumeroTelefone,
                dto.NumeroComprado
                );

            _participanteRepository.Add(participante);
            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var participantes = _participanteRepository.Get();

            return Ok(participantes);
        }
    }
}
