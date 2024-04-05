namespace RatingCarsForSale.Test
{
    public class Tests
    {
        //2 testy dla metody sprawdzaj¹cej poprawnoœæ danych, pierwszy z nieprawid³owymi wartoœciami rzuca wyj¹tek( czyli tak jak byæ powinno),
        //drugi test z poprawnymi wartoœciami nie rzuca wyj¹tku czyli dzia³a poprawnie 
        [Test]
        public void CheckMethodThrowsException()
        {
            string name = "aaa13";
            string model ="³ysy ¿ul";
            string batterysize = "cc-90";
            string enginesize = "1cc0000";
            string hp="xxxx";
            string vmax="xxxx";
            string fcons="dad";
            string fuel = "ssad";
            string econs="xxx";
            string color="kwaczki";
            string body="typ s³onia";
            string yearprod="x2013";
            string price="444ss4";

            Assert.Throws<Exception>(() => CarsForSaleDatabase.CheckCorrectDataCar(name, model, body, batterysize, enginesize, fuel, color, hp, fcons, econs, vmax, yearprod, price));
        }
        [Test]
        public void CheckMethodNotThrowsException()
        {
            string name = "Audi";
            string model = "A6";
            string batterysize = "0";
            string enginesize = "2000";
            string hp = "205";
            string vmax = "260";
            string fcons = "8";
            string fuel = "Petrol";
            string econs = "0";
            string color = "Bordo";
            string body = "Sedan";
            string yearprod = "2016";
            string price = "60000";
            
            Assert.DoesNotThrow(() => CarsForSaleDatabase.CheckCorrectDataCar(name, model, body, enginesize,batterysize, fuel, color, hp, fcons, econs, vmax, yearprod, price));
          
        }

        //  Tworzymy nowy obiekt CarForSaleInFile i dodajemy oceny (poprawne dane) dla danego auta( do pliku) 
        //  pobieramy nazwê pliku z ocenami i pobiermay z niego oceny, asercja sprawdza czy istnieje plik ( czyli dodano dane do pliku)
        //  oraz zlicza sumê ocen z pliku i porównuje j¹ do oczekiwanej wartoœci tutaj 30
        [Test]
        public void WhenUsingCorrectGradeToCarShouldCreateFileWithGrade()
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

            var car = new CarForSaleInFile(name, model, body, enginesize, batterysize, fuel, color, hp, fcons, econs, vmax, yearprod, price);
            
            car.AddGrade(5);
            car.AddGrade('A');
            car.AddGrade("A");
            car.AddGrade("5");
            
            var grades = car.GetFileNameWithGrade();
            var grad = 0;
            List<int> allgrades = new List<int>();
            var sgrade = File.ReadAllText(grades).Split(" ").ToList();
            sgrade.RemoveAt(sgrade.Count - 1);
            foreach (var item in sgrade)
            { 
                grad = grad + int.Parse(item);
            } 
            Assert.IsTrue(File.Exists(car.GetFileNameWithGrade()));
            Assert.AreEqual(30, grad);
        }
    }
}