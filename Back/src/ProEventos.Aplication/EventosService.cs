using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Aplication.Abstratas;
using ProEventos.Domain;
using ProEventos.Persistence.Abstratas;

namespace ProEventos.Aplication
{
    public class EventosService : IEventosService
    {
        private readonly IGeralPersistence _geralPersistence;
        private readonly IEventoPersistence _eventoPersistence;
        
        public EventosService(IGeralPersistence geralPersistence,IEventoPersistence eventoPersistence)
        {
            _eventoPersistence = eventoPersistence;
            _geralPersistence = geralPersistence;
           
            
        }
        public async Task<Evento> AddEvento(Evento model)
        {
           try
           {
                _geralPersistence.Add<Evento>(model);
                if(await _geralPersistence.SaveChangesAsync())
                {
                    return await _eventoPersistence.GetEventosByIdAsync(model.ID,false);
                }
                return null;
           }
           catch(Exception ex)
           {
                throw new Exception(ex.Message);
           }
        }
         public async Task<Evento> UpdateEvento(int eventoId, Evento model)
        {
           try
           {
             var evento=await _eventoPersistence.GetEventosByIdAsync(eventoId,false);
             if(evento==null) return null;
             model.ID =evento.ID;
             _geralPersistence.Update(model);
             if(await _geralPersistence.SaveChangesAsync())
                {
                    return await _eventoPersistence.GetEventosByIdAsync(model.ID,false);
                }
                return null;
           }
           catch(Exception ex)
           {
                throw new Exception(ex.Message);
           }
        }

        public async Task<bool> DeleteEvento(int eventoId)
        {
           try
           {
             var evento=await _eventoPersistence.GetEventosByIdAsync(eventoId,false);
             if(evento==null) throw new Exception ("O Evento para excluir não foi encontrado.");
             
             _geralPersistence.Delete<Evento>(evento);
             return await _geralPersistence.SaveChangesAsync();
                
           }
           catch(Exception ex)
           {
                throw new Exception(ex.Message);
           }
        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrante = false)
        {
           try
           {
            var eventos=await _eventoPersistence.GetAllEventosAsync(includePalestrante);
             if(eventos==null) return null;
            return eventos;
           }
           catch (Exception ex)
           {
            
            throw new Exception(ex.Message);
           }
        }

        public  async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrante = false)
        {
            try
           {
            var eventos=await _eventoPersistence.GetAllEventosByTemaAsync(tema, includePalestrante);
             if(eventos==null) return null;
            return eventos;
           }
           catch (Exception ex)
           {
            
            throw new Exception(ex.Message);
           }
        }

        public async Task<Evento> GetEventosByIdAsync(int eventoId, bool includePalestrante = false)
        {
            try
           {
            var eventos=await _eventoPersistence.GetEventosByIdAsync(eventoId, includePalestrante);
             if(eventos==null) return null;
            return eventos;
           }
           catch (Exception ex)
           {
            
            throw new Exception(ex.Message);
           }
        }

       
    }
}