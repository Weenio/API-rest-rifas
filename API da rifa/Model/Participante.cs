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
    }
}
