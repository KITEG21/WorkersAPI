using System.ComponentModel.DataAnnotations;
using static WEBAPLICATION1.Models.Habilidad;

namespace WEBAPLICATION1.Models;

public class HabilidadInsert
{   
    [Required]
    [MaxLength(25)]
    public string Name { get; set; } = string.Empty;
    
    [Required]
    public EDestreza Destreza { get; set; }

}