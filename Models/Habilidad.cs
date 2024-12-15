namespace WEBAPLICATION1.Models;

//Aca es la clase de la habilidad, lo mismo q la anterior, mucha muela sobre propiedades y un enum para los valores
public class Habilidad
{
    public int ID { get; set; }
    public string Name { get; set; } = string.Empty;

    public EDestreza Destreza { get; set; }

    public enum EDestreza
    {
        Defectuoso,
        Lento,
        Relajado,
        Mediano,
        Agil,
        Veloz,
        Perfecto

    }


}    
