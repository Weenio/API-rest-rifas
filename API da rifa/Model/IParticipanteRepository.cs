namespace API_da_rifa.Model
{
    public interface IParticipanteRepository
    {
        void Add(Participante participante);

        List<Participante> Get();
    }
}
