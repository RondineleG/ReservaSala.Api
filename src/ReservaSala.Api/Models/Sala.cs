using System.Collections.Generic;

namespace ReservaSala.Api.Models
{
    public class Sala
    {
        public int SalaId { get; set; }

        public string Nome { get; set; }

        public int BlocoId { get; set; }

        public Bloco Bloco { get; set; }

        public bool Disponivel { get; set; }

        public virtual ICollection<Aluno> Alunos { get; set; }
    }
}

