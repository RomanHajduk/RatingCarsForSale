
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
        public float Price { get; private set; }


        public CarBase(string namecar, string modelcar, Body bodytype, int engsize,
                       Fuel fueltype, string color, int hp, float fuelorenergcoms, int yearproduction, float price)
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
            this.Price = price;
        }

        public abstract void AddGrade(int grade);

        public virtual void AddGrade(char grade)
        {
            switch (char.ToUpper(grade))
            {

                case 'A':
                    this.AddGrade(10);
                    break;
                case 'B':
                    this.AddGrade(8);
                    break;
                case 'C':
                    this.AddGrade(6);
                    break;
                case 'D':
                    this.AddGrade(4);
                    break;
                case 'E':
                    this.AddGrade(2);
                    break;
                default:
                    throw new Exception("Wrong letter");

            }
        }
        public virtual void AddGrade(string grade) 
        {
            if (int.TryParse(grade, out int result))
            {
                this.AddGrade(result);
            }
            else
            {
                if (grade.Length == 1)
                {
                    this.AddGrade(char.Parse(grade));
                }
                else
                {
                    throw new Exception("This string is not int number");
                }
            }
        }
        public abstract Statistics GetStatistics();
        public virtual CharacteristicCar GetCharacteristicCar()
        {
            CharacteristicCar characteristicCar = new CharacteristicCar();
            characteristicCar.AddInfoCar(this);
            return characteristicCar;
        }
        
    }
}
