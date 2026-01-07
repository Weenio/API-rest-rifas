using System.ComponentModel.DataAnnotations;

namespace API_da_rifa.DTOs
{
    public class ParticipanteUpdateDTO
    {
        public string? Nome { get; set; }

        [MaxLength(11)]
        public string? NumeroTelefone { get; set; }

        public int? NumeroComprado { get; set; }
    }
}
