
namespace RatingCarsForSale
{


    //--------klasa CarForSale operuje na pamięci operacyjnej komputera
    //--------nie robiłem dla niej w pliku program.cs żadnej sekcji
    //--------zrobiłem tylko testy jednostkowe dla tej klasy.
    public class CarForSale : CarBase
    {
        public override event GradeAddedToCarDelegate GradeAddedToCar;
        public override event DescriptionAddedToCarDelegate DescriptionAddedToCar;
        
        
        new List<int> grades = new List<int>();
        new List<string> descriptionUser = new List<string>();

 
        public CarForSale(string namecar, string modelcar, Body bodytype,int enginesize,
                           float batterysize, Fuel fueltype, string color, int hp,
                           float fuelcoms, float enercoms, int maxspeed, int yearproduction, float price) : 
                           base(namecar, modelcar, bodytype, enginesize, batterysize,fueltype, color, hp,fuelcoms, enercoms,maxspeed, yearproduction, price)
        {
           
        }
        public List<int> GetGrades()
        { 
            return grades;
        }
        public List<string> GetDescription()
        { 
            return descriptionUser;
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
                throw new Exception("Nieprawidłowa ocena (przedział 0-10)!");
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
        public override void AddDescription(string desc, int grade)
        { 
            descriptionUser.Add(grade.ToString() + "::"+ desc);
            if (DescriptionAddedToCar != null)
            { 
                DescriptionAddedToCar(this, EventArgs.Empty);
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
