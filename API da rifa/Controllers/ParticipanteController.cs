using API_da_rifa.Model;
using API_da_rifa.DTOs;
using Microsoft.AspNetCore.Mvc;
using API_da_rifa.Model.Repositories;
using API_da_rifa.Services;

namespace API_da_rifa.Controllers
{
    [ApiController]
    [Route("api/v1/participante")]
    public class ParticipanteController : ControllerBase
    {
        private readonly ParticipanteService _service;

        public ParticipanteController(ParticipanteService pService)
        {
            _service = pService;
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
                var participante = _service.Create(dto);
                return Ok(participante);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var participantes = _service.GetAll();

            return Ok(participantes);
        }
    }
}
