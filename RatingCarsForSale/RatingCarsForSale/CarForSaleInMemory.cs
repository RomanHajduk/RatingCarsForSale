namespace RatingCarsForSale
{
    public class CarForSaleInMemory : CarBase
    {
        public override event GradeAddedToCarDelegate GradeAddedToCar;
        new List<int> grades = new List<int>();
       
        
        public CarForSaleInMemory(string namecar, string modelcar, Body bodytype, int enginecap,
                          Fuel fueltype, string color, int hp, float fuelcoms,
                          int yearproduction, float price) : 
                           base(namecar, modelcar, bodytype, enginecap ,fueltype, color, hp,fuelcoms, yearproduction,price)
        {
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
