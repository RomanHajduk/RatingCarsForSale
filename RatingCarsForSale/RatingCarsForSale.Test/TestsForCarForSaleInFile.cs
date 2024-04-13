namespace RatingCarsForSale.Test
{
    public class Tests
    {
        [Test]
        public void WhenUsingCorrectGradeToCarShouldCreateFileWithGrade()
        {
            string name = "Audi";
            string model = "A6";
            int enginesize = 2000;
            int hp = 205;
            float fcons = 8;
            Fuel fuel = Fuel.Petrol;
            string color = "Bordo";
            Body body = Body.Sedan;
            int yearprod = 2016;
            int price = 60000;
            
            var car = new CarForSaleInFile(name, model, body, enginesize, fuel, color, hp, fcons, yearprod, price);
            if (File.Exists(car.GetFileWithGrades()))
            {
                File.Delete(car.GetFileWithGrades());    
            }
            car.AddGrade(5);
            car.AddGrade('A');
            car.AddGrade("A");
            car.AddGrade("5");

            var grades = car.GetFileWithGrades();
            var grad = 0;
            List<int> allgrades = new List<int>();
            var sgrade = File.ReadAllText(grades).Split(" ").ToList();
            sgrade.RemoveAt(sgrade.Count - 1);
            foreach (var item in sgrade)
            { 
                grad = grad + int.Parse(item);
            } 
            Assert.IsTrue(File.Exists(car.GetFileWithGrades()));
            Assert.That(grad, Is.EqualTo(30));
        }
        [Test]
        public void WhenAddedCorrectGradesToCarShouldBeCorrectStats()
        {
            string name = "Renault";
            string model = "Clio RS";
            int enginesize = 2000;
            int hp = 290;
            float fcons = 10;
            Fuel fuel = Fuel.Petrol;
            string color = "Niebieski";
            Body body = Body.Hatchback;
            int yearprod = 2015;
            int price = 55000;

            var car = new CarForSaleInFile(name, model, body, enginesize, fuel, color, hp, fcons, yearprod, price);
            if (File.Exists(car.GetFileWithGrades()))
            {
                File.Delete(car.GetFileWithGrades());
            }
            car.AddGrade(9);
            car.AddGrade('A');
            car.AddGrade("E");
            car.AddGrade("0");
            car.AddGrade("5");

            Statistics stats = car.GetStatistics();

            Assert.That(stats.Max, Is.EqualTo(10));
            Assert.That(stats.Min, Is.EqualTo(0));
            Assert.That(stats.Count, Is.EqualTo(5));
            Assert.That(stats.Average, Is.EqualTo(5.2f));
            Assert.That(stats.AverageLetter, Is.EqualTo('C'));

        }
    }
}