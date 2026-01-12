using API_da_rifa.Infrastructure;
using API_da_rifa.Model;

namespace API_da_rifa.Model.Repositories
{
    public class ParticipanteRepository : IParticipanteRepository
    {
        //Cria a conexção com o banco de dados
        private readonly ConnectionContext _context = new ConnectionContext();

        //A seguir, itens excenciais do CRUD:

        //Serve para adiconar participantes, Create
        public void Add(Participante participante)
        {
            _context.Participante.Add(participante);
            _context.SaveChanges();
        }

        //Pesquisa e lista os participantes existentes, Read
        public List<Participante> Get()
        {
            return _context.Participante.Where(p => p.Participando).ToList();
        }

        //Pesquisa e lista os participantes com ID específicado, Read (específico)
        public Participante GetById(int id)
        {
            return _context.Participante.FirstOrDefault(p => p.ID_participante == id);
        }

        //Pede para atualizar um cadastro em específico, Update e Delete
        public void Update(Participante participante)
        {
            _context.Participante.Update(participante);
            _context.SaveChanges();
        }

        public bool NumeroPossuido(int numero)
        {
            return _context.Participante.Any(p => p.NumeroComprado == numero);
        }
    }
}
