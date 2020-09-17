using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Need_for_Speed_III
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Automobile> cars = new Dictionary<string, Automobile>();

            int n = int.Parse(Console.ReadLine());

            string car = string.Empty;

            for (int i = 0; i < n; i++)
            {
                //{car}|{mileage}|{fuel}
                car = Console.ReadLine();

                string[] tokens = car.Split('|');
                int mileage = int.Parse(tokens[1]);
                int fuel = int.Parse(tokens[2]);

                cars.Add(tokens[0], new Automobile(mileage, fuel));
            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Stop")
            {
                //•	Drive : {car} : {distance} : {fuel}
                string[] splittedCommand = command.Split(" : ");
                string typeOfCar = splittedCommand[1];

                if (command.Contains("Drive"))
                {
                    int distance = int.Parse(splittedCommand[2]);
                    int fuelNeed = int.Parse(splittedCommand[3]);

                    if (fuelNeed <= cars[typeOfCar].Fuel)
                    {
                        cars[typeOfCar].Mileage += distance;
                        cars[typeOfCar].Fuel -= fuelNeed;
                        Console.WriteLine($"{typeOfCar} driven for {distance} kilometers. {fuelNeed} liters of fuel consumed.");
                    }
                    else
                    {
                        Console.WriteLine($"Not enough fuel to make that ride");
                    }
                    if (cars[typeOfCar].Mileage > 100000)
                    {
                        cars.Remove(typeOfCar);
                        Console.WriteLine($"Time to sell the {typeOfCar}!");
                    }
                }
                else if (command.Contains("Refuel"))
                {
                    int fuel = int.Parse(splittedCommand[2]);

                    if (fuel + cars[typeOfCar].Fuel > 75)
                    {
                        fuel = 75 - cars[typeOfCar].Fuel;
                    }
                    cars[typeOfCar].Fuel += fuel;
                    Console.WriteLine($"{typeOfCar} refueled with {fuel} liters");
                }
                else if (command.Contains("Revert"))
                {
                    int km = int.Parse(splittedCommand[2]);

                    if (cars[typeOfCar].Mileage - km < 10000)
                    {
                        cars[typeOfCar].Mileage = 10000;
                    }
                    else
                    {
                        cars[typeOfCar].Mileage -= km;
                        Console.WriteLine($"{typeOfCar} mileage decreased by {km} kilometers");
                    }
                }
            }

            foreach (var auto in cars
                .OrderByDescending(km => km.Value.Mileage)
                .ThenBy(type => type.Key))
            {
                Console
                    .WriteLine($"{auto.Key} -> Mileage: {auto.Value.Mileage} kms, Fuel in the tank: {auto.Value.Fuel} lt.");
            }
        }
    }

    class Automobile
    {
        public int Mileage { get; set; }

        public int Fuel { get; set; }

        public Automobile(int mileage, int fuel)
        {
            this.Mileage = mileage;
            this.Fuel = fuel;
        }
    }
}
