using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API_da_rifa.Model
{
    public class Participante
    {
        //Dados que vão vir da DataBase
        [Key]
        public int ID_participante { get; private set; }
        public string Nome { get; private set; }
        public DateTime DataNascimento {  get; private set; }
        public string NumeroTelefone { get; private set; }
        public int NumeroComprado { get; private set; }
        public bool Participando { get; private set; } = true;

        //Construtor vazio para o EFCore
        public Participante() { }

        //Construtor para criar novos participantes
        public Participante( string Nome, DateTime DataNasc, string NumeroTel, int NumeroComprado)
        {
            this.Nome = Nome ?? throw new ArgumentNullException(nameof(Nome));
            this.DataNascimento = DataNasc;
            this.NumeroTelefone = NumeroTel;
            this.NumeroComprado = NumeroComprado;
        }

        public void AtualizarDados( string Nome, string NumeroTel, int NumeroComprado)
        {
            //Regra 1: Nome é obrigatório
            if (string.IsNullOrWhiteSpace(Nome))
                throw new Exception("O Nome é obrigatório!");

            //Regra 2: Número deve ser >= 0
            if (NumeroComprado <= 0)
                throw new Exception("O Número deve ser maior ou igual à zero!");

            this.Nome = Nome;
            this.NumeroTelefone = NumeroTel;            
            this.NumeroComprado = NumeroComprado;

        }

        public void AtualizarDadosParcial(string? Nome, string? NumeroTel, int? NumeroComprado)
        {
            //Regra 1: Nome é obrigatório
            if (Nome != null)
                this.Nome = Nome;

            //Regra 2: Número deve ser >= 0
            if (NumeroTel != null)
                this.NumeroTelefone = NumeroTel;

            if(NumeroComprado.HasValue)
                this.NumeroComprado = NumeroComprado.Value;

        }

        public void CancelarParticipacao()
        {
            if (!Participando)
                throw new Exception("Participante já inativo...");

            Participando = false;
        }
    }
}
