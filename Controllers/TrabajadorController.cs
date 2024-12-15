using WEBAPLICATION1.Models;
using WEBAPLICATION1.Services;
using Microsoft.AspNetCore.Mvc;

namespace WEBAPLICATION1.Controllers;

[ApiController]
[Route("api")]
public class TrabajadorController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Trabajador>> GetTrabajadores()
    {
        return TrabajadorDataStore.Current.Trabajadores;
    }
        //y aca el controlador, ya mas nada UwU
}