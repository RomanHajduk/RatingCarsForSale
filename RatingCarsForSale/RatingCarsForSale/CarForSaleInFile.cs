namespace RatingCarsForSale
{
    public class CarForSaleInFile : CarBase
    {

        readonly string fileNameWithGrades;

        public override event GradeAddedToCarDelegate GradeAddedToCar;
        public delegate void DownloadedGradesFromFileDelegate(object sender, EventArgs args);
        public event DownloadedGradesFromFileDelegate DownloadedGradesFromFile; 
        public float Price { get; private set; }

        
        public CarForSaleInFile(string namecar, string modelcar, Body bodytype, int engsize, 
                                Fuel fueltype, string color, int hp, float fuelcoms, int yearproduction, float price) :
                                base(namecar, modelcar, bodytype, engsize,
                                    fueltype, color, hp, fuelcoms, yearproduction)
        {
            this.Price = price;
            fileNameWithGrades = $"{namecar} {modelcar}.txt";
        }

        public string GetFileWithGrades()
        {
            return fileNameWithGrades;
        }

        public override void AddGrade(int grade)
        {
            {
                if (grade >= 0 && grade <= 10)
                {
                    using (var writer = File.AppendText(fileNameWithGrades))
                    {
                        writer.Write(grade);
                        writer.Write(" ");
                    }
                    if (GradeAddedToCar != null)
                    {
                        GradeAddedToCar(this, EventArgs.Empty);
                    }
                }
                else
                {
                    throw new Exception("Invalid data. Grade out of range: range 0-10!!!");
                }
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
                if (grade.Length == 1)
                {
                    this.AddGrade(char.Parse(grade));
                }
                else
                {
                    throw new Exception("This string is not int number");
                }
            };
        }
    
        
        public override Statistics GetStatistics()
        {
            Statistics stats =new Statistics();
            if (File.Exists(fileNameWithGrades))
            {
                using (var reader = File.OpenText(fileNameWithGrades))
                {
                    foreach(var item in reader.ReadLine().Split(" "))
                    {
                        if (item != "")
                        {
                            stats.AddGrade(int.Parse(item));
                        }
                    }
                }
                if (DownloadedGradesFromFile != null)
                {
                    DownloadedGradesFromFile(this,EventArgs.Empty);
                }
                return stats;

            }
            else
            {
                return stats;
            }
        }

        public override CharacteristicCar GetCharacteristicCar()
        {
            CharacteristicCar characteristicCar = new CharacteristicCar();
            characteristicCar.AddInfoCar(this);
            return characteristicCar;
        }
    }
}
