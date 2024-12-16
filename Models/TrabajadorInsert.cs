using System.ComponentModel.DataAnnotations;

namespace WEBAPLICATION1.Models;

public class TrabadorInsert
{   
    [Required]
    [MaxLength(25)]
    public string Name { get; set; } = string.Empty;
    
    [Required]
    public int Age { get; set; }

}