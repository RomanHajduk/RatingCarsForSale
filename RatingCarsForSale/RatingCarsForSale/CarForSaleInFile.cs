namespace RatingCarsForSale
{
    public class CarForSaleInFile : CarBase
    {
        //-----plik z ocenami i plik z opiniami
        
        string fileNameWithGrade;
        string fileNameWithDesciption;
        
        //-------plik z już istniejącymi identyfikatorami
        
        static string fileWithExistingID = "IDCarExisted.txt"; 
        
        public override event GradeAddedToCarDelegate GradeAddedToCar;
        public override event DescriptionAddedToCarDelegate DescriptionAddedToCar;
        public int CarID { get; private set; } //unikatowy id typu integer

        //--------Konstruktor tworzący nowy samochód na sprzedaż z unikatowym Id, wykorzystywany jest on przy dodawaniu (zapisywaniu) auta do bazy(pliku)  

        public CarForSaleInFile(string namecar, string modelcar, Body bodytype, int enginesize, float batterysize,
                                Fuel fueltype, string color, int hp, float fuelcoms, float enercoms,
                                int maxspeed, int yearproduction, float price) :
                                base(namecar, modelcar, bodytype, enginesize, batterysize,
                                    fueltype, color, hp, fuelcoms, enercoms,
                                    maxspeed, yearproduction, price)
        {
            CarID = CheckID(CarID);
            fileNameWithGrade = $"{CarID}{namecar}{modelcar}.txt";
            fileNameWithDesciption = $"{CarID}{namecar}{modelcar}desc.txt";
        }

        //-----------------------------------------------metody zwracające nazwy plików-------------------------------------------

        public string GetFileWithExistingID()
        { 
            return fileWithExistingID;
        }
        public string GetFileNameWithGrade()
        {
            return fileNameWithGrade;
        }
        public string GetFileNameWithDescription()
        {
            return fileNameWithDesciption;
        }

        //---------------Metoda sprawdza czy dany identyfikator już istnieje w pliku, jeśli istnieje to zwraca nowy identyfikator 

        public static int CheckID(int id)
        {
            
            int newid;
            if (!File.Exists(fileWithExistingID))
            {
                
                using (var writer = File.AppendText(fileWithExistingID))
                {
                    writer.Write(id);
                    writer.Write(" ");
                    newid = id;
                }
            }
            else
            {
                using (var reader = File.OpenText(fileWithExistingID))
                {
                    var allfiledata = reader.ReadToEnd();
                    for (int i = id; ; i++)
                    {
                        if (!allfiledata.Contains(i.ToString()))
                        {
                            newid = i;
                            break;
                        }
                    }
                }
                using (var writer = File.AppendText(fileWithExistingID))
                {
                    writer.Write(newid);
                    writer.Write(" ");
                }

            }
            return newid;
        }
        
        //---------------------------------Konstruktor dla już wprowadzonych aut do pliku( są w nim zapisane wraz z identyfikatorem auta CarID)------------------- 

        public CarForSaleInFile(int newID, string namecar, string modelcar,Body bodytype, int enginesize,float batterysize,
                                Fuel fueltype, string color,int hp, float fuelcoms, float enercoms,
                                int maxspeed, int yearproduction, float price) : 
                                base(namecar, modelcar, bodytype, enginesize, batterysize, 
                                    fueltype, color, hp, fuelcoms, enercoms, 
                                    maxspeed, yearproduction, price)
        {

            CarID = newID;
            fileNameWithGrade = $"{CarID}{namecar}{modelcar}.txt";
            fileNameWithDesciption = $"{CarID}{namecar}{modelcar}desc.txt";
        }

       
        //---------------------------------------------Dodanie opinii do pliku----------------------------------------------------

        public override void AddDescription(string description, int grade)
        {
            using (var writer = File.AppendText(fileNameWithDesciption))
            {
                writer.WriteLine(grade + "::" + description);
            }
            if (DescriptionAddedToCar != null) 
            { 
                DescriptionAddedToCar(this, EventArgs.Empty);
            }
        }

        //-----------------------------------metody dodające oceny do auta-------------------------------------------------------- 
        
        public override void AddGrade(int grade)
        {
            {
                if (grade >= 0 && grade <= 10)
                {
                    using (var writer = File.AppendText(fileNameWithGrade))
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
    
        //-----------------------metoda zwraca charakterystykę dla konkretnego auta, troszkę trzeba poprawić---------------------------------------------

        public override CharacteristicCar GetCharacteristicCar()
        {
            CharacteristicCar charcar = new CharacteristicCar();
            charcar.AddInfoCar(this);
            return charcar;
        }
        
        //------------------------------------------ metoda zwraca listę z opiniami wraz z przypisanymi ocenami,dane są zawarte w pliku dla wybranego auta,
        //------------------------------------------jeśli nie ma ocen to nie ma opinii więc metoda zwraca pustą listę. 
        public List<string>  GetCommentSaleOffer()
        {
            List<string> result = new List<string>();
            if (File.Exists(fileNameWithDesciption))
            {
                using (var reader = File.OpenText(fileNameWithDesciption))
                {
                    var line = reader.ReadLine();
                    while (line != null) 
                    {
                        var gradewithopinion = line.Split("::");
                        result.Add($"Grade: {gradewithopinion[0]} Opinion: {gradewithopinion[1]}");
                        line = reader.ReadLine();
                    }
                }
            }
            return result;
        
        }

        //-----------------------------------  Metoda pobiera statystyki, najpierw sprawdza czy istnieje plik z ocenami dla wybranego auta,
        //---------------------------jeśli plik istnieje dodaje kolejno oceny i zwraca statystyki nie pliku nie ma zwraca puste statystyki.
        public override Statistics GetStatistics()
        {
            Statistics stats =new Statistics();
            if (File.Exists(fileNameWithGrade))
            {
                using (var reader = File.OpenText(fileNameWithGrade))
                {
                    foreach(var item in reader.ReadLine().Split(" "))
                    {
                        if (item != "")
                        {
                            stats.AddGrade(int.Parse(item));
                        }
                    }
                }
                return stats;

            }
            else
            {
                return stats;
            }
        }
    }
}
