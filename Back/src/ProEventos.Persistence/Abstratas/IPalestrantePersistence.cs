using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence.Abstratas
{
    public interface IPalestrantePersistence
    {
        
        //PALESTRANTES
        Task<Palestrante[]>GetAllPalestrantesByNomeAsync(string Nome,bool includeEventos);
        Task<Palestrante[]>GetAllPalestrantesAsync(bool includeEventos);
        Task<Palestrante>GetAllPalestrantesByIdAsync(int PalestranteId,bool includeEventos);
    }
}