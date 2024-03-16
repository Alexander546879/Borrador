using System;

using System;
using System.Collections.Generic;

// Definición de la clase Car para representar un auto
public class Car
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public string PlateNumber { get; set; }
    public bool IsAvailable { get; set; }

    public Car(string brand, string model, string plateNumber)
    {
        Brand = brand;
        Model = model;
        PlateNumber = plateNumber;
        IsAvailable = true; // Por defecto, el auto está disponible al crearlo
    }
}

// Clase principal que gestiona la renta de autos
public class CarRental
{
    private List<Car> cars;

    public CarRental()
    {
        // Inicializar la lista de autos disponibles
        cars = new List<Car>();
    }

    // Agregar un nuevo auto al inventario
    public void AddCar(string brand, string model, string plateNumber)
    {
        Car newCar = new Car(brand, model, plateNumber);
        cars.Add(newCar);
    }

    // Mostrar la lista de autos disponibles
    public void ShowAvailableCars()
    {
        Console.WriteLine("Autos disponibles para renta:");
        foreach (var car in cars)
        {
            if (car.IsAvailable)
            {
                Console.WriteLine($"Marca: {car.Brand}, Modelo: {car.Model}, Placa: {car.PlateNumber}");
            }
        }
    }

    // Rentar un auto
    public void RentCar(string plateNumber)
    {
        foreach (var car in cars)
        {
            if (car.PlateNumber == plateNumber && car.IsAvailable)
            {
                car.IsAvailable = false;
                Console.WriteLine($"Has rentado el auto {car.Brand} {car.Model} (Placa: {car.PlateNumber})");
                return;
            }
        }
        Console.WriteLine("El auto solicitado no está disponible.");
    }

    // Devolver un auto rentado
    public void ReturnCar(string plateNumber)
    {
        foreach (var car in cars)
        {
            if (car.PlateNumber == plateNumber && !car.IsAvailable)
            {
                car.IsAvailable = true;
                Console.WriteLine($"Has devuelto el auto {car.Brand} {car.Model} (Placa: {car.PlateNumber})");
                return;
            }
        }
        Console.WriteLine("No se encontró ningún auto rentado con esa placa.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        CarRental rentalSystem = new CarRental();

        // Agregar algunos autos al inventario
        rentalSystem.AddCar("Toyota", "Corolla", "ABC123");
        rentalSystem.AddCar("Honda", "Civic", "XYZ456");
        rentalSystem.AddCar("Ford", "Fiesta", "DEF789");

        // Mostrar autos disponibles
        rentalSystem.ShowAvailableCars();

        // Rentar un auto
        rentalSystem.RentCar("ABC123");

        // Mostrar autos disponibles después de rentar uno
        rentalSystem.ShowAvailableCars();

        // Devolver el auto rentado
        rentalSystem.ReturnCar("ABC123");

        // Mostrar autos disponibles después de devolver el auto rentado
        rentalSystem.ShowAvailableCars();
    }
}
