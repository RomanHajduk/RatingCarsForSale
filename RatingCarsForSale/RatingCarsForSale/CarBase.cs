
namespace RatingCarsForSale
{

  
    public abstract class CarBase : ICar
    {
        
        public delegate void GradeAddedToCarDelegate(object sender, EventArgs args);
        public abstract event GradeAddedToCarDelegate GradeAddedToCar;
         
        
        public string NameCar { get; private set; }
        public string ModelCar { get; private set; }
        public Body BodyType { get; private set; }
        public int EngineCapacity { get; private set; }
        public Fuel FuelType { get; private set; }
        public int YearProduction { get; private set; }
        public int HP {  get; private set; }
        public string Color {  get; private set; }
        public float AverageFuelComsumptionPer100KM {  get; private set; }
       
        
        public CarBase(string namecar, string modelcar, Body bodytype, int engsize,
                       Fuel fueltype, string color, int hp, float fuelorenergcoms, int yearproduction)
        {
            this.NameCar = namecar;
            this.ModelCar = modelcar;
            this.BodyType = bodytype;
            this.EngineCapacity = engsize;
            this.FuelType = fueltype;
            this.Color = color;
            this.HP = hp;
            this.AverageFuelComsumptionPer100KM = fuelorenergcoms;
            this.YearProduction = yearproduction;
        }
        
        public abstract void AddGrade(int grade);
        public abstract void AddGrade(char grade);
        public abstract void AddGrade(string grade);
        public abstract Statistics GetStatistics();
        public abstract CharacteristicCar GetCharacteristicCar();
        
    }
}
