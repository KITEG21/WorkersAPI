using Microsoft.AspNetCore.Mvc;
using WEBAPLICATION1.Helpers;
using WEBAPLICATION1.Models;
using WEBAPLICATION1.Services;

namespace WEBAPLICATION1.Controllers;

[ApiController]
[Route("api/Trabajador/{trabajadorId}/[controller]")]
public class HabilidadController : ControllerBase 
{
    [HttpGet]
    public ActionResult<IEnumerable<Habilidad>> GetHabilidades(int trabajadorId)
    {
        var trabajador = TrabajadorDataStore.Current.Trabajadores.FirstOrDefault(x=> x.ID == trabajadorId);

        if(trabajador == null)
        {
            return NotFound(Mensajes.Trabajador.trabajadorNotFound);
        }

        return Ok(trabajador.Habilidades);
    }

    [HttpGet("{habilidadId}")]
    public ActionResult<Habilidad> GetHabilidad(int trabajadorId,int habilidadId)
    {
        var trabajador = TrabajadorDataStore.Current.Trabajadores.FirstOrDefault(x=> x.ID == trabajadorId);
  
        if(trabajador == null){
            return NotFound(Mensajes.Trabajador.trabajadorNotFound);
        }
            
        var habilidad = trabajador.Habilidades?.FirstOrDefault(h=> h.ID == habilidadId);

        if(habilidad == null){
            return NotFound(Mensajes.Habilidad.habilidadNotFound);            
        }

        return Ok(habilidad);

    }

    [HttpPost] 
    public ActionResult<Habilidad> PostHabilidad(int trabajadorId, HabilidadInsert habilidadInsert)
    {
        var trabajador = TrabajadorDataStore.Current.Trabajadores.FirstOrDefault(x=> x.ID == trabajadorId);
  
        if(trabajador == null){
            return NotFound(Mensajes.Trabajador.trabajadorNotFound);
        }

        var habilidadExistente = trabajador.Habilidades.FirstOrDefault(h => h.Name == habilidadInsert.Name);
        
        if(habilidadExistente != null)
        {
            return BadRequest(Mensajes.Habilidad.habilidadExistente);
        }

        var maxHabilidadId = trabajador.Habilidades.Max(h=> h.ID);


        var nuevaHabilidad = new Habilidad()
        {
            ID = maxHabilidadId + 1,
            Name = habilidadInsert.Name,
            Destreza = habilidadInsert.Destreza
        };

        trabajador.Habilidades.Add(nuevaHabilidad);

        return CreatedAtAction(nameof(GetHabilidad),
        new {trabajadorId = trabajadorId, habilidadId = nuevaHabilidad.ID},
        nuevaHabilidad
        );

    }

    [HttpPut("{habilidadId}")]
    public ActionResult<Habilidad> PutHabilidad(int trabajadorId, int habilidadId, HabilidadInsert habilidadInsert)
    {
        var trabajador = TrabajadorDataStore.Current.Trabajadores.FirstOrDefault(x=> x.ID == trabajadorId);

        if(trabajador == null)
        {
            return NotFound(Mensajes.Trabajador.trabajadorNotFound);
        }
    
        var habilidad = trabajador.Habilidades.FirstOrDefault(h=> h.ID == habilidadId);

        if(habilidad == null)
        {
            return NotFound(Mensajes.Habilidad.habilidadNotFound);
        }

        habilidad.Name = habilidadInsert.Name;
        habilidad.Destreza = habilidadInsert.Destreza;

        return NoContent();
    
    }

    [HttpDelete("{habilidadId}")]
    public ActionResult<Habilidad> DeleteHabilidad(int trabajadorId,int habilidadId)
    {
        var trabajador = TrabajadorDataStore.Current.Trabajadores.FirstOrDefault(x=> x.ID == trabajadorId);

        if(trabajador == null)
        {
            return NotFound(Mensajes.Trabajador.trabajadorNotFound);
        }

        var habilidad = trabajador.Habilidades.FirstOrDefault(h => h.ID == habilidadId);
        
        if(habilidad == null)
        {
            return NotFound(Mensajes.Habilidad.habilidadNotFound);
        }

        trabajador.Habilidades?.Remove(habilidad);
        return Ok();

    }











}