using System.ComponentModel.DataAnnotations;

namespace API_da_rifa.DTOs
{
    public class ParticipanteReadDTO
    {
        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        public string NumeroTelefone { get; set; }

        public int NumeroComprado { get; set; }
    }
}
