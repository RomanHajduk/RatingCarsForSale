namespace RatingCarsForSale.Test
{
    public class TestsForCarForSaleInMemory
    {
        [Test]
        public void WhenAddedCorrectGrades_ShouldBeStoredInListWithGradesCorrectly() 
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

            var car = new CarForSaleInMemory(name, model, body, enginesize, fuel, color, hp, fcons, yearprod, price);

            car.AddGrade("7");
            car.AddGrade("A");
            car.AddGrade("9");
            car.AddGrade("10");
            Assert.AreEqual(7,car.GetGrades().ElementAt(0));
            Assert.AreEqual(10,car.GetGrades().ElementAt(1));
            Assert.AreEqual(9, car.GetGrades().ElementAt(2));
            Assert.AreEqual(10, car.GetGrades().ElementAt(3));
        }
        [Test]
        public void WhenAddedWrongGrade_ShouldBeOccursException()
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

            var car = new CarForSaleInMemory(name, model, body, enginesize, fuel, color, hp, fcons, yearprod, price);

            Assert.Throws<Exception>(() => car.AddGrade("Z"));
        }
        [Test]
        public void WhenAddedCorrectGrade_ShouldBeCorrectStatistics()
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

            var car = new CarForSaleInMemory(name, model, body, enginesize, fuel, color, hp, fcons, yearprod, price);

            car.AddGrade("8");
            car.AddGrade("6");
            car.AddGrade("A");
            car.AddGrade('E');
            car.AddGrade(0);

            Statistics statcar = new Statistics();
            statcar = car.GetStatistics();
            Assert.AreEqual(0, statcar.Min);
            Assert.AreEqual(10, statcar.Max);
            Assert.AreEqual(5,statcar.Count);
            Assert.AreEqual(5.2f, statcar.Average);
            Assert.AreEqual('C',statcar.AverageLetter);
        }
        [Test]
        public void WhenAddedCorrectAndIncorrectGrade_ShouldBeCorrectStatisticsOrThrowException()
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

            var car = new CarForSaleInMemory(name, model, body, enginesize, fuel, color, hp, fcons, yearprod, price);

            car.AddGrade("8");
            car.AddGrade("A");
            car.AddGrade('E');
            car.AddGrade(1);

            Statistics statcar = new Statistics();
            statcar = car.GetStatistics();
            Assert.AreEqual(1, statcar.Min);
            Assert.AreEqual(10, statcar.Max);
            Assert.AreEqual(4, statcar.Count);
            Assert.AreEqual(5.25f, statcar.Average);
            Assert.AreEqual('C', statcar.AverageLetter);

            Assert.Throws<Exception>(() => car.AddGrade("Z"));
            Assert.Throws<Exception>(() => car.AddGrade(-1));
        }
    }
}
