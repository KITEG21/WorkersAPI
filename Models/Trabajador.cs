namespace WEBAPLICATION1.Models;

public class Trabajador{
    public string Name { get; set; } = string.Empty;
    public int ID { get; set; }
    public int Age { get; set; }
    public List<Habilidad>? Habilidades { get; set; } 
    
}

