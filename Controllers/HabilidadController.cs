using Microsoft.AspNetCore.Mvc;
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
            return NotFound("El trabajador solicitado no existe");
        }

        return Ok(trabajador.Habilidades);
    }

    [HttpGet("{habilidadId}")]
    public ActionResult<Habilidad> GetHabilidad(int trabajadorId,int habilidadId)
    {
        var trabajador = TrabajadorDataStore.Current.Trabajadores.FirstOrDefault(x=> x.ID == trabajadorId);
  
        if(trabajador == null){
            return NotFound("El trabajador solicitado no existe");
        }
            
        var habilidad = trabajador.Habilidades?.FirstOrDefault(h=> h.ID == habilidadId);

        if(habilidad == null){
            return NotFound("La habilidad solicitada no existe");            
        }

        return Ok(habilidad);

    }

    [HttpPost] 
    public ActionResult<Habilidad> PostHabilidad(int trabajadorId, HabilidadInsert habilidadInsert)
    {
        var trabajador = TrabajadorDataStore.Current.Trabajadores.FirstOrDefault(x=> x.ID == trabajadorId);
  
        if(trabajador == null){
            return NotFound("El trabajador solicitado no existe");
        }

        var habilidadExistente = trabajador.Habilidades.FirstOrDefault(h => h.Name == habilidadInsert.Name);
        
        if(habilidadExistente != null)
        {
            return BadRequest("Ya existe una habilidad con el mismo nombre");
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
            return NotFound("El trabajador solicitado no existe");
        }
    
        var habilidad = trabajador.Habilidades.FirstOrDefault(h=> h.ID == habilidadId);

        if(habilidad == null)
        {
            return NotFound("La habilidad solicitada no existe");
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
            return NotFound("El trabajador solicitado no existe");
        }

        var habilidad = trabajador.Habilidades.FirstOrDefault(h => h.ID == habilidadId);
        
        if(habilidad == null)
        {
            return NotFound("La habilidad solicitada no existe");
        }

        trabajador.Habilidades.Remove(habilidad);
        return Ok();

    }











}