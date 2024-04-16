﻿public enum Fuel
{
    Petrol = 0,
    Diesel = 1,
}
public enum Body
{
    Hatchback = 0, 
    Sedan = 1,
    Liftback = 2, 
    Combi = 3,
    SUV = 4, 
    Crossover = 5,
    Cabriolet = 6, 
    Coupe = 7,
    Roadster = 8
}

namespace RatingCarsForSale
{
    public interface ICar 
    { 
        string NameCar { get; }
        string ModelCar { get; }
        int EngineCapacity { get; }
        Fuel FuelType { get; }
        Body BodyType { get; }
        int YearProduction { get; }
        int HP { get; }
        string Color { get; }
        float Price { get; }
        
        void AddGrade(int grade);
        void AddGrade(char grade);
        void AddGrade(string grade);
        Statistics GetStatistics();
        CharacteristicCar GetCharacteristicCar();
    }
}
