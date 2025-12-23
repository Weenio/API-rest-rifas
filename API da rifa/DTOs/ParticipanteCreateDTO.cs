using System.ComponentModel.DataAnnotations;

namespace API_da_rifa.DTOs
{
    public class ParticipanteCreateDTO
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public DateTime DataNascimento { get; set; }

        [Required]
        [MaxLength(11)]
        public string NumeroTelefone { get; set; }

        [Required]
        public int NumeroComprado { get; set; }
    }
}
