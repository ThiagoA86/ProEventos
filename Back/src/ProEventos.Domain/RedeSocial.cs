using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.Domain
{
    public class RedeSocial
    {
        public int Id { get; set; }
        public int? EventoId { get; set; }
        public string Nome { get; set; }
        public string URL { get; set; }
        public Evento Evento {get;set;}
        public int? PaletranteId { get; set; }
        public Palestrante Palestrante { get; set; }

    }
}