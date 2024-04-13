namespace RatingCarsForSale
{
    public class CarForSaleInMemory : CarBase
    {
        public override event GradeAddedToCarDelegate GradeAddedToCar;
        new List<int> grades = new List<int>();
       
        public float Price { get; private set; }
        public CarForSaleInMemory(string namecar, string modelcar, Body bodytype, int enginecap,
                          Fuel fueltype, string color, int hp, float fuelcoms,
                          int yearproduction, float price) : 
                           base(namecar, modelcar, bodytype, enginecap ,fueltype, color, hp,fuelcoms, yearproduction)
        {
            this.Price = price;
        }
        public List<int> GetGrades()
        {
            return grades;
        }
      
        public override void AddGrade(int grade)
        {
            if (grade >=0 && grade <=10)
            {
                grades.Add(grade);
                if (GradeAddedToCar != null)
                    GradeAddedToCar(this, EventArgs.Empty);
            }
            else
            {
                throw new Exception("Invalid data. Grade out of range: range 0-10!!!");
            }
        }

        public override void AddGrade(char grade)
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
        
        public override void AddGrade(string grade) 
        {
            if (int.TryParse(grade, out int result))
            {
                this.AddGrade(result);
            }
            else
            {
                if (grade.Length == 1 && grade.ToLower() != "q")
                {
                    this.AddGrade(char.Parse(grade));
                }
                else
                {
                    if (grade.ToLower() == "q")
                    {

                    }
                    else
                    {
                        throw new Exception("This string is not number");
                    }
                }
            }
        }

        public override CharacteristicCar GetCharacteristicCar()
        {
            CharacteristicCar characteristicCar = new CharacteristicCar();
            characteristicCar.AddInfoCar(this);
            return characteristicCar;

        }

        public override Statistics GetStatistics()
        {
            Statistics statistics = new Statistics();
            foreach (var grade in grades)
            {
                statistics.AddGrade(grade);
            }
            return statistics;
        }
    }
}
