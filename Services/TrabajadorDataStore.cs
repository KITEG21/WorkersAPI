using WEBAPLICATION1.Models;

namespace WEBAPLICATION1.Services;

//
public class TrabajadorDataStore
{   
    public List<Trabajador> Trabajadores {get; set;} 

    //Singleton, permite una sola instancia de TrabajadorDataStore
    public static TrabajadorDataStore Current { get; } = new TrabajadorDataStore(); 
 
    public TrabajadorDataStore(){
        //Inicio de la lista de trabajadores
        Trabajadores = new List<Trabajador>{
            
            //Trabajador #1                         
            new Trabajador(){
                ID = 1,
                Name = "Luis Alberto",
                Age = 23,
                //Lista de habilidades
                Habilidades = new List<Habilidad>(){        
                    new Habilidad(){
                        ID = 01,
                        Name = "Redraw",
                        Destreza = Habilidad.EDestreza.Agil
                    },
                    new Habilidad(){
                        ID = 02,
                        Name = "Correcion",
                        Destreza = Habilidad.EDestreza.Relajado
                    }
                }

            },
            new Trabajador(){
                ID = 2,
                Name = "Elier Diaz",
                Age = 19,
                Habilidades = new List<Habilidad>(){
                    new Habilidad(){
                        ID = 03,
                        Name = "Atleta",
                        Destreza = Habilidad.EDestreza.Perfecto
                    },
                    new Habilidad(){
                        ID = 04,
                        Name = "Discurso",
                        Destreza = Habilidad.EDestreza.Mediano
                    }
                }
            }

        };
    }
}