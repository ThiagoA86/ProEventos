using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence.Abstratas
{
    public interface IEventoPersistence
    {
        
        
        //Eventos
        Task<Evento[]>GetAllEventosByTemaAsync(string tema,bool includePalestrante);
        
        Task<Evento[]>GetAllEventosAsync(bool includePalestrante);
        Task<Evento>GetEventosByIdAsync(int EventoId,bool includePalestrante);

    }
}