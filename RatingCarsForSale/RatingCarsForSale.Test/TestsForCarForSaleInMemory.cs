namespace RatingCarsForSale.Test
{
    // Test sprawdza czy dodano poprawnie ocenę do listy
    public class TestsForCarForSaleInMemory
    {
        [Test]
        public void WhenAddedCorrectGrade_ShouldBeStoredInListWithGrades() 
        {
            string name = "Audi";
            string model = "A6";
            float batterysize = 0;
            int enginesize = 2000;
            int hp = 205;
            int vmax = 260;
            float fcons = 8;
            Fuel fuel = Fuel.Petrol;
            float econs = 0;
            string color = "Bordo";
            Body body = Body.Sedan;
            int yearprod = 2016;
            int price = 60000;

            var car = new CarForSale(name, model, body, enginesize, batterysize, fuel, color, hp, fcons, econs, vmax, yearprod, price);

            car.AddGrade("7");
            
            Assert.AreEqual(7,car.GetGrades().ElementAt(0));

        }

        // Test sprawdza czy metoda rzuca wyjątek przy wprowadzaniu nieprawidłowej oceny
        [Test]
        public void WhenAddedWrongGrade_ShouldBeOccursException()
        {
            string name = "Audi";
            string model = "A6";
            float batterysize = 0;
            int enginesize = 2000;
            int hp = 205;
            int vmax = 260;
            float fcons = 8;
            Fuel fuel = Fuel.Petrol;
            float econs = 0;
            string color = "Bordo";
            Body body = Body.Sedan;
            int yearprod = 2016;
            int price = 60000;

            var car = new CarForSale(name, model, body, enginesize, batterysize, fuel, color, hp, fcons, econs, vmax, yearprod, price);

            Assert.Throws<Exception>(() => car.AddGrade("Z"));
        }

        // Test sprawdza czy dodano poprawnie opinię na temat auta do listy i porównujemy ją z wartością oczekiwaną
        [Test]
        public void WhenAddedReview_ShouldBeStoredInListWithDescription()
        {
            string name = "Audi";
            string model = "A6";
            float batterysize = 0;
            int enginesize = 2000;
            int hp = 205;
            int vmax = 260;
            float fcons = 8;
            Fuel fuel = Fuel.Petrol;
            float econs = 0;
            string color = "Bordo";
            Body body = Body.Sedan;
            int yearprod = 2016;
            int price = 60000;
            
            var car = new CarForSale(name, model, body, enginesize, batterysize, fuel, color, hp, fcons, econs, vmax, yearprod, price);

            car.AddGrade("8");
            car.AddDescription("Super auto", 8);

            Assert.AreEqual("8::Super auto", car.GetDescription().ElementAt(0));
        }

        //Test sprawdza czy po wprowadzeniu poprawnych ocen, statystyki będą mieć prawidłowe wartości
        [Test]
        public void WhenAddedCorrectGrade_ShouldBeCorrectStatistics()
        {
            string name = "Audi";
            string model = "A6";
            float batterysize = 0;
            int enginesize = 2000;
            int hp = 205;
            int vmax = 260;
            float fcons = 8;
            Fuel fuel = Fuel.Petrol;
            float econs = 0;
            string color = "Bordo";
            Body body = Body.Sedan;
            int yearprod = 2016;
            int price = 60000;

            var car = new CarForSale(name, model, body, enginesize, batterysize, fuel, color, hp, fcons, econs, vmax, yearprod, price);

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

        // test sprawdza czy dodając poprawne oceny statystyki są prawidłowe a podając błędne oceny metoda rzuca wyjątek.  
        [Test]
        public void WhenAddedCorrectAndIncorrectGrade_ShouldBeCorrectStatisticsOrThrowException()
        {
            string name = "Audi";
            string model = "A6";
            float batterysize = 0;
            int enginesize = 2000;
            int hp = 205;
            int vmax = 260;
            float fcons = 8;
            Fuel fuel = Fuel.Petrol;
            float econs = 0;
            string color = "Bordo";
            Body body = Body.Sedan;
            int yearprod = 2016;
            int price = 60000;

            var car = new CarForSale(name, model, body, enginesize, batterysize, fuel, color, hp, fcons, econs, vmax, yearprod, price);

           
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
