
namespace RatingCarsForSale
{

    // klasa abstrakcyjna Auto zaimplementowany interfejs ICars 
    public abstract class CarBase : ICars
    {
        
        public delegate void GradeAddedToCarDelegate(object sender, EventArgs args);
        public delegate void DescriptionAddedToCarDelegate(object sender, EventArgs args);
        
        public abstract event GradeAddedToCarDelegate GradeAddedToCar;
        public abstract event DescriptionAddedToCarDelegate DescriptionAddedToCar;
       
        public string NameCar { get; private set; }
        public string ModelCar { get; private set; }
        public Body BodyType { get; private set; }
        public int EngineSize { get; private set; }
        public float BatteryCapacity {  get; private set; }
        public Fuel FuelType { get; private set; }
        public int MaximumSpeed { get; private set; }
        public int YearProduction { get; private set; }
        public int HP {  get; private set; }
        public string Color {  get; private set; }
        public float AverageFuelComsumptionPer100KM {  get; private set; }
        public float AverageEnergyComsumptionPer100KM { get; private set; }
        public float Price {  get; private set; }

        
        public CarBase(string namecar, string modelcar, Body bodytype, int enginesize,
                       float batterysize, Fuel fueltype, string color, int hp,
                       float fuelcoms, float enercoms, int maxspeed, int yearproduction, float price)
        {
            this.NameCar = namecar;
            this.ModelCar = modelcar;
            this.BodyType = bodytype;
            this.EngineSize = enginesize;
            this.BatteryCapacity = batterysize;
            this.FuelType = fueltype;
            this.Color = color;
            this.HP = hp;
            this.AverageFuelComsumptionPer100KM = fuelcoms;
            this.AverageEnergyComsumptionPer100KM = enercoms;
            this.MaximumSpeed = maxspeed;
            this.YearProduction = yearproduction;
            this.Price = price;
        }
        
        public abstract void AddGrade(int grade);
        public abstract void AddGrade(char grade);
        public abstract void AddGrade(string grade);
        public abstract void AddDescription(string description, int grade);

        public abstract Statistics GetStatistics();
        public abstract CharacteristicCar GetCharacteristicCar();
        
    }
}
