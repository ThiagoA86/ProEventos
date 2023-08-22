using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Abstratas;
using ProEventos.Persistence.Contexto;

namespace ProEventos.Persistence
{
    public class EventoPersistence : IEventoPersistence
    {
        private readonly ProEventosContext _context;
        public EventoPersistence(ProEventosContext context)
        {
            _context = context;
            //_context.ChangeTracker.QueryTrackingBehavior=QueryTrackingBehavior.NoTracking;
            
        }
           

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrante=false)
        {
           IQueryable<Evento> query =_context.Eventos.AsNoTracking()
                .Include(e=>e.Lotes)
                .Include(e=>e.RedesSociais);
            query = query.OrderBy(e=>e.ID);

            if (includePalestrante)
            {
                query = query
                .Include(e=>e.PalestrantesEventos)
                .ThenInclude(pe=>pe.Palestrante);
            }

            return await query.ToArrayAsync();
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrante=false)
        {
            IQueryable<Evento> query =_context.Eventos.AsNoTracking()
                .Include(e=>e.Lotes)
                .Include(e=>e.RedesSociais);
            

            if (includePalestrante)
            {
                query = query
                .Include(e=>e.PalestrantesEventos)
                .ThenInclude(pe=>pe.Palestrante);
            }
            query = query.OrderBy(e=>e.ID)
            .Where(e=>e.Tema.ToLower().Contains(tema.ToLower()));

            return await query.ToArrayAsync();
        }
        public async Task<Evento> GetEventosByIdAsync(int EventoId, bool includePalestrante=false)
        {
          IQueryable<Evento> query =_context.Eventos.AsNoTracking()
                .Include(e=>e.Lotes)
                .Include(e=>e.RedesSociais);
            

            if (includePalestrante)
            {
                query = query
                .Include(e=>e.PalestrantesEventos)
                .ThenInclude(pe=>pe.Palestrante);
            }
            query = query.OrderBy(e=>e.ID)
            .Where(e=>e.ID==EventoId);

            return await query.FirstOrDefaultAsync();
        }  

        

        

        
    }
}