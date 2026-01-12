namespace API_da_rifa.Model.Repositories
{
    public interface IParticipanteRepository
    {
        void Add(Participante participante);
        List<Participante> Get();
        bool NumeroPossuido(int numero);
        Participante GetById(int id);
        void Update(Participante participante);
    }
}
