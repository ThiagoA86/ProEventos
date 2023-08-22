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
    public class PalestrantePersistence : IPalestrantePersistence
    {
        private readonly ProEventosContext _context;
        public PalestrantePersistence(ProEventosContext _context)
        {
            this._context = _context;
            
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

        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos=false)
        {
           IQueryable<Palestrante> query =_context.Palestrantes.AsNoTracking()
                .Include(p=>p.RedesSociais);
           

            if (includeEventos)
            {
                query = query
                .Include(p=>p.PalestrantesEventos)
                .ThenInclude(pe=>pe.Evento);
            }
            query = query.OrderBy(p=>p.ID);
            return await query.ToArrayAsync();
        }

        public async Task<Palestrante> GetAllPalestrantesByIdAsync(int PalestranteId, bool includeEventos)
        {
           IQueryable<Palestrante> query =_context.Palestrantes.AsNoTracking()
                .Include(p=>p.RedesSociais);
           

            if (includeEventos)
            {
                query = query
                .Include(p=>p.PalestrantesEventos)
                .ThenInclude(pe=>pe.Evento);
            }
            query = query.OrderBy(p=>p.ID)
            .Where(p=>p.ID==PalestranteId);;
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string Nome, bool includeEventos)
        {
            IQueryable<Palestrante> query =_context.Palestrantes.AsNoTracking()
                .Include(p=>p.RedesSociais);
           

            if (includeEventos)
            {
                query = query
                .Include(p=>p.PalestrantesEventos)
                .ThenInclude(pe=>pe.Evento);
            }
            query = query.OrderBy(p=>p.ID)
                .Where(p=>p.Nome.ToLower().Contains(Nome.ToLower()));
            return await query.ToArrayAsync();
        }

        

        

        
    }
}