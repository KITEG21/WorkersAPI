using WEBAPLICATION1.Models;
using WEBAPLICATION1.Services;
using Microsoft.AspNetCore.Mvc;
using WEBAPLICATION1.Helpers;

namespace WEBAPLICATION1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TrabajadorController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Trabajador>> GetTrabajadores()
    {
        return Ok(TrabajadorDataStore.Current.Trabajadores);
    }

    [HttpGet("{trabajadorId}")]
    public ActionResult<Trabajador> GetTrabajador(int trabajadorId)
    {
        var trabajador = TrabajadorDataStore.Current.Trabajadores.FirstOrDefault(x=> x.ID == trabajadorId);

        if(trabajador == null)
            return NotFound(Mensajes.Trabajador.trabajadorNotFound);
    
        return Ok(trabajador);
    }

    [HttpPost]
    public ActionResult<Trabajador> PostTrabajador(TrabadorInsert trabadorInsert)
    {
        var maxTrabajadorId = TrabajadorDataStore.Current.Trabajadores.Max(x => x.ID);

        var TrabajadorNuevo = new Trabajador()
        {
            Name = trabadorInsert.Name,
            ID = maxTrabajadorId+1,
            Age = trabadorInsert.Age  
        };

        TrabajadorDataStore.Current.Trabajadores.Add(TrabajadorNuevo);

        return CreatedAtAction(nameof(GetTrabajador),
            new {trabajadorId = TrabajadorNuevo.ID},
            TrabajadorNuevo
        );
    }

    [HttpPut("{trabajadorId}")]
    public ActionResult<Trabajador> PutTrabajador(int trabajadorId, TrabadorInsert trabadorInsert)
    {
        var trabajador = TrabajadorDataStore.Current.Trabajadores.FirstOrDefault(x=> x.ID == trabajadorId);

        if(trabajador == null)
        {
            return NotFound(Mensajes.Trabajador.trabajadorNotFound);
        }

        trabajador.Name = trabadorInsert.Name;
        trabajador.Age = trabadorInsert.Age;

        return NoContent();

    }

    [HttpDelete("{trabajadorId}")]
    public ActionResult<Trabajador> DeleteTrabajador(int trabajadorId)
    {
        var trabajador = TrabajadorDataStore.Current.Trabajadores.FirstOrDefault(x=> x.ID == trabajadorId);

        if(trabajador == null)
        {
            return NotFound(Mensajes.Trabajador.trabajadorNotFound);
        }

        TrabajadorDataStore.Current.Trabajadores.Remove(trabajador);
        return Ok();

    }





}