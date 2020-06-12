using System.Collections.Generic;

namespace ReservaSala.Api.Models
{
    public class Bloco
    {
        public int BlocoId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Sala> Salas { get; set; }
    }
}
