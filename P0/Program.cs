using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace P0
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "cars.json";

            List<Car> carList = LoadCars(filePath);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Car Manager ===");
                Console.WriteLine("1. Add a car");
                Console.WriteLine("2. List all cars");
                Console.WriteLine("3. Show average car name length");
                Console.WriteLine("4. Exit");
                Console.Write("Select an option: ");

                string? option = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(option))
                {
                    Console.WriteLine("Invalid input. Press any key to continue...");
                    Console.ReadKey();
                    continue;
                }

                switch (option.Trim())
                {
                    case "1":
                        AddCar(carList);
                        SaveCars(carList, filePath);
                        break;
                    case "2":
                        ListCars(carList);
                        break;
                    case "3":
                        ShowAverageLength(carList);
                        break;
                    case "4":
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static List<Car> LoadCars(string filePath)
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                if (!string.IsNullOrWhiteSpace(json))
                {
                    try
                    {
                        List<Car>? data = JsonSerializer.Deserialize<List<Car>>(json);
                        return data ?? new List<Car>();
                    }
                    catch
                    {
                        return new List<Car>();
                    }
                }
            }
            return new List<Car>();
        }

        static void SaveCars(List<Car> cars, string filePath)
        {
            string json = JsonSerializer.Serialize(cars, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }

        static void AddCar(List<Car> carList)
        {
            Console.Write("Enter car name (or press Enter to cancel): ");
            string? name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Car name cannot be empty. Press any key to go back to the menu...");
                Console.ReadKey();
                return;
            }

            carList.Add(new Car { Name = name.Trim() });
            Console.WriteLine("Car added successfully! Press any key to continue...");
            Console.ReadKey();
        }

        static void ListCars(List<Car> carList)
        {
            Console.WriteLine("\n=== Current Cars ===");
            if (carList.Count == 0)
            {
                Console.WriteLine("No cars found.");
            }
            else
            {
                foreach (var car in carList)
                {
                    Console.WriteLine($"- {car.Name}");
                }
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static void ShowAverageLength(List<Car> carList)
        {
            if (carList.Count == 0)
            {
                Console.WriteLine("\nNo cars to calculate average length. Press any key to continue...");
                Console.ReadKey();
                return;
            }

            double averageLength = 0;
            foreach (var c in carList)
            {
                averageLength += c.Name.Length;
            }
            averageLength = averageLength / carList.Count;
            Console.WriteLine($"\nAverage car name length: {averageLength:F2} characters");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
