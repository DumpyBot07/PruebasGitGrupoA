using System;

// Interfaz para mascota
public interface IMascota
{
    string Id { get; } 
    string Nombre { get; set; } 
    int Edad { get; set; } 
    Temperamento Temperamento { get; set; } 
    string Dueño { get; set; } 

    void HacerRuido(); 
    void CambiarDueño(string nuevoDueño); 
}

//enumeracion de mascota
public enum Especie
{
    Perro,
    Gato,
    Capibara
}

public enum Temperamento
{
    Amable,
    Nervioso,
    Agresivo
}

// tipo de papumascota
public abstract class Mascota : IMascota
{
    private static int contadorGlobal = 0;

    public string Id { get; }
    public string Nombre { get; set; }
    private int _edad;
    public int Edad
    {
        get { return _edad; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("La edad no puede ser negativa.");
            }
            _edad = value;
        }
    }
    public Temperamento Temperamento { get; set; }
    public string Dueño { get; set; }



 public Mascota(string nombre, int edad, Temperamento temperamento, string dueño)
    {
        contadorGlobal++;
        Id = $"Mascota-{contadorGlobal}";
        Nombre = nombre;
        Edad = edad;
        Temperamento = temperamento;
        Dueño = dueño;
    }
public abstract void HacerRuido();

    public void CambiarDueño(string nuevoDueño)
    {
        Console.WriteLine($"La mascota {Nombre} ha cambiado su dueño a {nuevoDueño}{Environment.NewLine}");
        Dueño = nuevoDueño;
    }
}

// clase de guauguau q hereda por mascota
public class Perro : Mascota
{
    public Perro(string nombre, int edad, Temperamento temperamento, string dueño) 
        : base(nombre, edad, temperamento, dueño)
    {
    }

    public override void HacerRuido()
    {
        Console.WriteLine("Guau guau");
    }

    public void MoverCola()
    {
        Console.WriteLine("El perro mueve la cola");
    }

    public void Gruñir()
    {
        Console.WriteLine("Grrrr");
    }
}

//El metodo principal para ejecutar el codigo
class Program
{
    static void Main()
    {
        // uso de ejemplos
        Perro miPerro = new Perro("Firulais", 5, Temperamento.Amable, "Juan");
        miPerro.HacerRuido(); // escribe el sonido del animal
        miPerro.MoverCola(); // Llama al metodo para que el perro mueve la cola
        miPerro.CambiarDueño("Armando"); // metodo de la mascota Firulais ha cambiado su dueño a x persona
    }
}
