using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Aplication.Abstratas
{
    public interface IEventosService
    {
        Task<Evento>AddEvento(Evento model);
        Task<Evento>UpdateEvento(int eventoId, Evento model);
        Task<bool>DeleteEvento(int eventoId);

        
        Task<Evento[]>GetAllEventosByTemaAsync(string tema,bool includePalestrante = false);
        
        Task<Evento[]>GetAllEventosAsync(bool includePalestrante=false);
        Task<Evento>GetEventosByIdAsync(int eventoId,bool includePalestrante=false);
    }
}