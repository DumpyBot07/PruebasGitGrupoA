using System;
using System.Collections.Generic;
using System.Linq;

public class Person
{
    private static int counter = 0;
    public string Id {get; }
    public string Name{get; set;}
    public Person(string name){
        counter++;
        Id = $"Person{counter}";
        Name = name;
    }
} 
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
        Console.WriteLine("Mueve la cola");
    }

    public void Gruñir()
    {
        Console.WriteLine("Grrrr");
    }

}



//El metodo principal para ejecutar el codigo
class Program
{
    static List<Person> registeredPersons = new List<Person>();
    static void Main()
    {
        // uso de ejemplos
        Perro miPerro = new Perro("Pugnacio", 5, Temperamento.Amable, "Jose");
        miPerro.HacerRuido(); // Escribe el sonido del animal
        miPerro.MoverCola(); // Llama al metodo para que el perro mueve la cola
        miPerro.CambiarDueño("Armando"); // metodo de la mascota Firulais ha cambiado su dueño a x persona

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

            switch (option){
                case "1":
                    AdminPeople();
                    break;
                case "2":
                    AdminMascotas();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Opción no papu valida");
                    break;
            }
        }
    }
       static void AdminPeople()//administracion de las personas
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
                    foreach (var person in registeredPersons)
                    {
                        Console.WriteLine($"ID: {person.Id}, Name: {person.Name}");
                    }
                    break;
                case "2":
                    Console.WriteLine("Ingresa nombre d la persona:");
                    var name = Console.ReadLine();
                    var newPerson = new Person(name);
                    registeredPersons.Add(newPerson);
                    Console.WriteLine($"{name} ha sido registrada.");
                    break;
                case "3":
                    Console.WriteLine("Buscar nombre:");
                    var searchName = Console.ReadLine();
                    var foundPersons = registeredPersons.Where(p => p.Name.Contains(searchName)).ToList();
                    foreach (var person in foundPersons)
                    {
                        Console.WriteLine($"ID: {person.Id}, Name: {person.Name}");
                    }
                    break;
                case "4":
                    Console.WriteLine("Ingresa el ID de la persona:");
                    var personId = Console.ReadLine();
                    var person = registeredPersons.FirstOrDefault(p => p.Id == personId);
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

    static List<Mascota> registeredPets = new List<Mascota>();

    static void AdminMascotas()
    {
        while (true)
        {
            Console.WriteLine("1 - Mostrar todas las mascotas registradas");
            Console.WriteLine("2 - Registrar nueva mascota");
            Console.WriteLine("3 - Buscar mascotas por nombre");
            Console.WriteLine("4 - Examinar mascota");
            Console.WriteLine("5 - Regresar al menú anterior");

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    foreach (var pet in registeredPets)
                    {
                        Console.WriteLine($"ID: {pet.Id}, Nombre: {pet.Nombre}, Dueño: {pet.Dueño}");
                    }
                    break;
                case "2":
                    Console.WriteLine("Ingrese el nombre de la mascota:");
                    var name = Console.ReadLine();
                    Console.WriteLine("Ingrese la edad de la mascota:");
                    var age = int.Parse(Console.ReadLine());
                    Console.WriteLine("Ingrese el temperamento de la mascota (1 - Amable, 2 - Nervioso, 3 - Agresivo):");
                    var temperamento = (Temperamento)int.Parse(Console.ReadLine());
                    Console.WriteLine("Ingrese el dueño de la mascota:");
                    var owner = Console.ReadLine();
                    var newPet = new Perro(name, age, temperamento, owner); // Aquí se crea un perro, pero puedes pedir al usuario qué tipo de mascota quiere crear
                    registeredPets.Add(newPet);
                    Console.WriteLine($"Mascota {name} ha sido registrada.");
                    break;
                case "3":
                    Console.WriteLine("Ingrese el nombre para buscar:");
                    var searchName = Console.ReadLine();
                    var foundPets = registeredPets.Where(p => p.Nombre.Contains(searchName)).ToList();
                    foreach (var pet in foundPets)
                    {
                        Console.WriteLine($"ID: {pet.Id}, Nombre: {pet.Nombre}, Dueño: {pet.Dueño}");
                    }
                    break;
                case "4":
                    Console.WriteLine("Ingrese el ID de la mascota:");
                    var petId = Console.ReadLine();
                    var pet = registeredPets.FirstOrDefault(p => p.Id == petId);
                    if (pet != null)
                    {
                        Console.WriteLine($"ID: {pet.Id}, Nombre: {pet.Nombre}, Dueño: {pet.Dueño}");
                    }
                    else
                    {
                        Console.WriteLine("No se encontró ninguna mascota con ese ID proporcionado.");
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
                foreach (var adoption in registeredAdoptions)
                {
                    Console.WriteLine($"Persona: {adoption.Persona.Name}, Mascota: {adoption.Mascota.Nombre}");
                }
                break;
            case "2":
            Console.WriteLine("Ingrese el nombre de la persona:");
            string personName = Console.ReadLine();
            Person person = registeredPersons.FirstOrDefault(p => p.Name == personName);
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
                    foreach (var pet in registeredPets)
                    {
                        Console.WriteLine($"ID: {pet.Id}, Nombre: {pet.Nombre}, Dueño: {pet.Dueño}, Temperamento: {pet.Temperamento}");
                    }
                    break;
                case "2":
                    Console.WriteLine("Ingrese el ID de la mascota:");
                    var petId = Console.ReadLine();
                    var pet = registeredPets.FirstOrDefault(p => p.Id == petId);
                    if (pet != null)
                    {
                        pet.Temperamento = Temperamento.Amable; // Mejora el bienestar de la mascota cambiando su temperamento a Amable
                        Console.WriteLine($"El bienestar de {pet.Nombre} ha sido mejorado.");
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
}

