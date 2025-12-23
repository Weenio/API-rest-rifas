using API_da_rifa.Model;

namespace API_da_rifa.Infrastructure
{
    public class ParticipanteRepository : IParticipanteRepository
    {
        //Cria a conexção com o banco de dados
        private readonly ConnectionContext _context = new ConnectionContext();

        //Serve para adiconar participantes
        public void Add(Participante participante)
        {
            _context.Participante.Add(participante);
            _context.SaveChanges();
        }
        
        //Pesquisa e lista os participantes existentes
        public List<Participante> Get()
        {
            return _context.Participante.ToList();
        }
    }
}
