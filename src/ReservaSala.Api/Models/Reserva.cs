using System;
using System.Collections.Generic;

namespace ReservaSala.Api.Models
{
    public class Reserva
    {

        public int ReservaId { get; set; }

        public string Nome { get; set; }

        public int SalaId { get; set; }
        public Sala Sala { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataFim { get; set; }

        public int AlunoId { get; set; }
        public virtual Aluno Aluno { get; set; }

        public virtual ICollection<Aluno> Alunos { get; set; }
    }
}
