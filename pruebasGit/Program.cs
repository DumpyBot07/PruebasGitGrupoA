using System;
using System.Collections.Generic;
using System.Linq;

using System;
using System.Collections.Generic;
using System.Linq;

// Clase Person
public class Persona
{
    private static int counter = 0;
    public string Id { get; }
    public string Name { get; set; }

    public Persona(string name)
    {
        counter++;
        Id = $"Person{counter}";
        Name = name;
    }
}

// Interfaz IMascota
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

// Enumeración Temperamento
public enum Temperamento
{
    Amable,
    Nervioso,
    Agresivo
}

// Clase abstracta Mascota
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

// Clase Perro que hereda de Mascota
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
}

// clase Adopcion
public class Adopcion
{
    public Persona Persona { get; set; }
    public Mascota Mascota { get; set; }

    public Adopcion(Persona persona, Mascota mascota)
    {
        Persona = persona;
        Mascota = mascota;
    }
}



class Program
{
    static List<Persona> personasRegistradas = new List<Persona>();
    static List<Mascota> registeredPets = new List<Mascota>();
    static List<Adopcion> registeredAdoptions = new List<Adopcion>();

    static void Main()
    {
       

        while (true)
        {
            Console.WriteLine("1 - Administración del centro");
            Console.WriteLine("2 - Administración de adopciones");
            Console.WriteLine("3 - Administración de bienestar animal");
            Console.WriteLine("4 - Simulación de interacciones");
            Console.WriteLine("5 - Finalizar programa");

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    AdminCenter();
                    break;
                case "2":
                    AdminAdopciones();
                    break;
                case "3":
                    AdminBienestarAnimal();
                    break;
                case "4":
                    SimularInteracciones();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Opción no válida");
                    break;
            }
        }
    }


    static void AdminCenter()
    {
        while (true)
        {
            Console.WriteLine("1 - Administración de personas");
            Console.WriteLine("2 - Administración de mascotas");
            Console.WriteLine("3 - Regresar a menú anterior");

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    AdminPeople();
                    break;
                case "2":
                    AdminMascotas();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Opción no válida");
                    break;
            }
        }
    }

    static void AdminPeople()
    {
        while (true)
        {
            Console.WriteLine("1 - Mostrar todas la personas registradas");
            Console.WriteLine("2 - Registrar persona nueva");
            Console.WriteLine("3 - Buscar personas por nombre");
            Console.WriteLine("4 - Examinar persona");
            Console.WriteLine("5 - Regresar al menú anterior");

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    foreach (var Persona in personasRegistradas)
                    {
                        Console.WriteLine($"ID: {Persona.Id}, Name: {Persona.Name}");
                    }
                    break;
                case "2":
                    Console.WriteLine("Ingresa nombre de la persona:");
                    var name = Console.ReadLine();
                    var newPerson = new Persona(name);
                    personasRegistradas.Add(newPerson);
                    Console.WriteLine($"{name} ha sido registrada.");
                    break;
                case "3":
                    Console.WriteLine("Buscar nombre:");
                    var buscarNombre = Console.ReadLine();
                    var encontrarPersonas = personasRegistradas.Where(p => p.Name.Contains(buscarNombre)).ToList();
                    foreach (var persona in encontrarPersonas)
                    {
                        Console.WriteLine($"ID: {persona.Id}, Name: {persona.Name}");
                    }
                    break;
                case "4":
                    Console.WriteLine("Ingresa el ID de la persona:");
                    var personId = Console.ReadLine();
                    var person = personasRegistradas.FirstOrDefault(p => p.Id == personId);
                    if (person != null)
                    {
                        Console.WriteLine($"ID: {person.Id}, Name: {person.Name}");
                    }
                    else
                    {
                        Console.WriteLine("No se encontró ninguna persona con el ID proporcionado.");
                    }
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Opción no válida");
                    break;
            }
        }
    }


    static void AdminMascotas()
    {
        while (true)
        {
            Console.WriteLine("1 - Mostrar todas las adopciones");
            Console.WriteLine("2 - Registrar nueva adopción");
            Console.WriteLine("3 - Buscar adopciones por persona");
            Console.WriteLine("4 - Buscar adopciones por mascota");
            Console.WriteLine("5 - Regresar al menú anterior");

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    foreach (var adoption in registeredAdoptions)
                    {
                        Console.WriteLine($"Persona: {adoption.Persona.Name}, Mascota: {adoption.Mascota.Nombre}");
                    }
                    break;
                case "2":
                    Console.WriteLine("Ingrese el nombre de la persona:");
                    string personName = Console.ReadLine();
                    Persona person = personasRegistradas.FirstOrDefault(p => p.Name == personName);
                    if (person == null)
                    {
                        Console.WriteLine("Persona no encontrada.");
                        break;
                    }

                    Console.WriteLine("Ingrese el nombre de la mascota:");
                    string petName = Console.ReadLine();
                    Mascota pet = registeredPets.FirstOrDefault(p => p.Nombre == petName);
                    if (pet == null)
                    {
                        Console.WriteLine("Mascota no encontrada.");
                        break;
                    }

                    registeredAdoptions.Add(new Adopcion(person, pet));
                    Console.WriteLine("Adopción registrada exitosamente.");
                    break;
                case "3":
                    Console.WriteLine("Ingrese el nombre de la persona:");
                    string searchPersonName = Console.ReadLine();
                    var adoptionsByPerson = registeredAdoptions.Where(a => a.Persona.Name == searchPersonName);
                    foreach (var adoption in adoptionsByPerson)
                    {
                        Console.WriteLine($"Persona: {adoption.Persona.Name}, Mascota: {adoption.Mascota.Nombre}");
                    }
                    break;
                case "4":
                    Console.WriteLine("Ingrese el nombre de la mascota:");
                    string searchPetName = Console.ReadLine();
                    var adoptionsByPet = registeredAdoptions.Where(a => a.Mascota.Nombre == searchPetName);
                    foreach (var adoption in adoptionsByPet)
                    {
                        Console.WriteLine($"Persona: {adoption.Persona.Name}, Mascota: {adoption.Mascota.Nombre}");
                    }
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Opción no válida");
                    break;
            }
        }
    }

    

    static void AdminAdopciones()
    {
        while (true)
        {
            Console.WriteLine("1 - Mostrar todas las adopciones");
            Console.WriteLine("2 - Registrar nueva adopción");
            Console.WriteLine("3 - Buscar adopciones por persona");
            Console.WriteLine("4 - Buscar adopciones por mascota");
            Console.WriteLine("5 - Regresar al menú anterior");

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    MostrarAdopciones();
                    break;
                case "2":
                    RegistrarAdopcion();
                    break;
                case "3":
                    BuscarAdopcionesPorPersona();
                    break;
                case "4":
                    BuscarAdopcionesPorMascota();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Opción no válida");
                    break;
            }
        }
    }





     static void AdminBienestarAnimal()
            {
                while (true)
                {
                    Console.WriteLine("1 - Mostrar todas las mascotas y su bienestar");
                    Console.WriteLine("2 - Mejorar bienestar de mascota");
                    Console.WriteLine("3 - Regresar al menú anterior");

                    var option = Console.ReadLine();

                    switch (option)
                    {
                        case "1":
                            foreach (var Mascota in registeredPets)
                            {
                                Console.WriteLine($"ID: {Mascota.Id}, Nombre: {Mascota.Nombre}, Dueño: {Mascota.Dueño}, Temperamento: {Mascota.Temperamento}");
                            }
                            break;
                        case "2":
                            Console.WriteLine("Ingrese el ID de la mascota:");
                            var MascotaId = Console.ReadLine();
                            var mascota = registeredPets.FirstOrDefault(p => p.Id == MascotaId);
                            if (mascota != null)
                            {
                                mascota.Temperamento = Temperamento.Amable; // Mejora el bienestar de la mascota cambiando su temperamento a Amable
                                Console.WriteLine($"El bienestar de {mascota.Nombre} ha sido mejorado.");
                            }
                            else
                            {
                                Console.WriteLine("No se encontró ninguna mascota con ese ID proporcionado.");
                            }
                            break;
                        case "3":
                            return;
                        default:
                            Console.WriteLine("Opción no válida");
                            break;
                    }
                }
            }


    
    static void SimularInteracciones()
    {
        while (true)
        {
            Console.WriteLine("1 - Hacer que una mascota haga ruido");
            Console.WriteLine("2 - Cambiar dueño de una mascota");
            Console.WriteLine("3 - Regresar al menú anterior");

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.WriteLine("Ingrese el ID de la mascota:");
                    var petId = Console.ReadLine();
                    var pet = registeredPets.FirstOrDefault(p => p.Id == petId);
                    if (pet != null)
                    {
                        pet.HacerRuido();
                    }
                    else
                    {
                        Console.WriteLine("No se encontró ninguna mascota con ese ID proporcionado.");
                    }
                    break;
                case "2":
                    Console.WriteLine("Ingrese el ID de la mascota:");
                    petId = Console.ReadLine();
                    pet = registeredPets.FirstOrDefault(p => p.Id == petId);
                    if (pet != null)
                    {
                        Console.WriteLine("Ingrese el nuevo dueño:");
                        var newOwner = Console.ReadLine();
                        pet.CambiarDueño(newOwner);
                    }
                    else
                    {
                        Console.WriteLine("No se encontró ninguna mascota con ese ID proporcionado.");
                    }
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Opción no válida");
                    break;
            }
        }
    }


    static void MostrarAdopciones()
    {
        foreach (var adoption in registeredAdoptions)
        {
            Console.WriteLine($"Persona: {adoption.Persona.Name}, Mascota: {adoption.Mascota.Nombre}");
        }
    }

    static void RegistrarAdopcion()
    {
        Console.WriteLine("Ingrese el nombre de la persona:");
        string personName = Console.ReadLine();
        Persona person = personasRegistradas.FirstOrDefault(p => p.Name == personName);
        if (person == null)
        {
            Console.WriteLine("Persona no encontrada.");
            return;
        }

        Console.WriteLine("Ingrese el nombre de la mascota:");
        string petName = Console.ReadLine();
        Mascota pet = registeredPets.FirstOrDefault(p => p.Nombre == petName);
        if (pet == null)
        {
            Console.WriteLine("Mascota no encontrada.");
            return;
        }

        if (pet.Dueño != null)
        {
            Console.WriteLine("La mascota ya tiene un dueño.");
            return;
        }

        registeredAdoptions.Add(new Adopcion(person, pet));
        pet.CambiarDueño(person.Name);
        Console.WriteLine("Adopción registrada exitosamente.");
    }

    static void BuscarAdopcionesPorPersona()
    {
        Console.WriteLine("Ingrese el nombre de la persona:");
        string searchPersonName = Console.ReadLine();
        var adoptionsByPerson = registeredAdoptions.Where(a => a.Persona.Name == searchPersonName);
        foreach (var adoption in adoptionsByPerson)
        {
            Console.WriteLine($"Persona: {adoption.Persona.Name}, Mascota: {adoption.Mascota.Nombre}");
        }
    }

    static void BuscarAdopcionesPorMascota()
    {
        Console.WriteLine("Ingrese el nombre de la mascota:");
        string searchPetName = Console.ReadLine();
        var adoptionsByPet = registeredAdoptions.Where(a => a.Mascota.Nombre == searchPetName);
        foreach (var adoption in adoptionsByPet)
        {
            Console.WriteLine($"Persona: {adoption.Persona.Name}, Mascota: {adoption.Mascota.Nombre}");
        }
    }

    // Método MoverCola agregado a la clase Perro
    public void MoverCola()
    {
        Console.WriteLine("El perro mueve la cola.");
    }
}