using API_da_rifa.DTOs;
using API_da_rifa.Model;
using API_da_rifa.Model.Repositories;

namespace API_da_rifa.Services
{
    public class ParticipanteService
    {

        /*
        Antes de realizarmos a leitura do código para implementação no front-end, seria bom
        explicar as regras de criação dos participantes no Banco brevemente:
        
        REGRA 1: O nome é uma variável OBRIGATÓRIA
        REGRA 2: O número comprado DEVE ser maior que (ou igual, em alguns casos) 0
        REGRA 3: O mesmo número NÃO PODE ser comprado duas vezes

        Mais regras serão escritas tanto na documentação quanto no código, assim que houverem
        novos updates.
         */

        private readonly IParticipanteRepository _repo;

        public ParticipanteService(IParticipanteRepository repo)
        {
            _repo = repo;
        }

        public Participante Create(ParticipanteCreateDTO dto)
        {
            //Regra 1: Nome é obrigatório
            if (string.IsNullOrWhiteSpace(dto.Nome))
                throw new Exception("O Nome é obrigatório!");

            //Regra 2: Número deve ser >= 0
            if (dto.NumeroComprado <= 0)
                throw new Exception("O Número deve ser maior ou igual à zero!");

            //Regra 3: O Número não deve ser comprado duas vezes
            if (_repo.NumeroPossuido(dto.NumeroComprado))
                throw new Exception("O número já foi comprado...");

            var participante = new Participante(
            dto.Nome,
            dto.DataNascimento,
            dto.NumeroTelefone,
            dto.NumeroComprado
            );

            _repo.Add(participante);
            return participante;
        }

        public IEnumerable<ParticipanteReadDTO> GetAll()
        {
            var participantes = _repo.Get();

            return participantes.Select(p => new ParticipanteReadDTO
            {
                Nome = p.Nome,
                DataNascimento = p.DataNascimento,
                NumeroTelefone = p.NumeroTelefone,
                NumeroComprado = p.NumeroComprado
            });
        }
    }
}
