using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.Domain
{
    public class Lote
    {
       public int ID { get; set; }
       public string Nome { get; set; }
       public decimal Preco { get; set; } 
       public DateTime? DateInicio { get; set; }
       public DateTime? DateFim { get; set; }
       public int Quantidade { get; set; }
       public int EventoId { get; set; }
       public Evento Evento { get; set; }
    }
}