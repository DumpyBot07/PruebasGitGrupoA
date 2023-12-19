using System;

// Interface for a pet
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

// Enumerations for species and temperament
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
                throw new ArgumentException("Age cannot be negative.");
            }
            _edad = value;
        }
    }
    public Temperamento Temperamento { get; set; }
    public string Dueño { get; set; }
