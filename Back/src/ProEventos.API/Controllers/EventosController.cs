﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.Aplication.Abstratas;
using ProEventos.Domain;
using ProEventos.Persistence;
using ProEventos.Persistence.Contexto;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        
        private readonly IEventosService _eventosService;
        
        public EventosController(IEventosService eventosService)
        {
            _eventosService = eventosService;
          

        }
        

        [HttpGet]
        public async Task<IActionResult> Get()
        {
           try
           {
            var eventos =await _eventosService.GetAllEventosAsync(true);
            if (eventos==null) return NotFound("Nenhum evento encontrado");
            return Ok(eventos);
                
           }
           catch (Exception ex) 
           {
            
            return this.StatusCode(StatusCodes.Status500InternalServerError
            ,$"Error ao recuperar eventos. Erro: {ex.Message}");
           }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
           {
            var evento =await _eventosService.GetEventosByIdAsync(id,true);
            if (evento==null) return NotFound("Nenhum evento por ID encontrado");
            return Ok(evento);
                
           }
           catch (Exception ex) 
           {
            
            return this.StatusCode(StatusCodes.Status500InternalServerError
            ,$"Error ao recuperar eventos. Erro: {ex.Message}");
           }
        }
        [HttpGet("{tema}/tema")]
        public async Task<IActionResult> GetByTema(string tema)
        {
            try
           {
            var evento =await _eventosService.GetAllEventosByTemaAsync(tema,true);
            if (evento==null) return NotFound("Tema não encontrado");
            return Ok(evento);
                
           }
           catch (Exception ex) 
           {
            
            return this.StatusCode(StatusCodes.Status500InternalServerError
            ,$"Error ao recuperar eventos. Erro: {ex.Message}");
           }
        }
        [HttpPost]
        public async Task<IActionResult> Post(Evento model)
        {
           try
           {
            var evento =await _eventosService.AddEvento(model);
            if (evento==null) return BadRequest("Erro ao adicinar novo evento");
            return Ok(evento);
                
           }
           catch (Exception ex) 
           {
            
            return this.StatusCode(StatusCodes.Status500InternalServerError
            ,$"Error ao recuperar eventos. Erro: {ex.Message}");
           }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Evento model)
        {
           try
           {
            var evento =await _eventosService.UpdateEvento(id, model);
            if (evento==null) return BadRequest("Erro ao atualizar evento");
            return Ok(evento);
                
           }
           catch (Exception ex) 
           {
            
            return this.StatusCode(StatusCodes.Status500InternalServerError
            ,$"Error ao recuperar eventos. Erro: {ex.Message}");
           }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
           try
           {
            if(await _eventosService.DeleteEvento(id))
            {
                return Ok("Deletado");
            }
            else
            {
                return BadRequest("Evento Deletado");
            }
                
           }
           catch (Exception ex) 
           {
            
            return this.StatusCode(StatusCodes.Status500InternalServerError
            ,$"Error ao recuperar eventos. Erro: {ex.Message}");
           }
        }
    }
}
