using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;


namespace RatingCarsForSale
{
    public static class CarsForSaleDatabase
    {
        public delegate void CarAddedToDatabaseDelegate(object sender, EventArgs args);
        public delegate void CarRemovedFromDatabaseDelegate(object sender, EventArgs args);
        public delegate void CheckedCorrectCarDataDelegate(object sender, EventArgs args);
        public delegate void RemovedFileWithGradesDelegate(object sender, EventArgs args);  
        public delegate void RemovedFileWithDescriptionDelegate(object sender, EventArgs args); 
        public delegate void DeletedDatabaseFileDelegate(object sender, EventArgs args);

        public static event CarAddedToDatabaseDelegate CarAddedToDatabase;
        public static event CarRemovedFromDatabaseDelegate CarRemovedFromDatabase;
        public static event CheckedCorrectCarDataDelegate CheckedCorrectCarData;
        public static event RemovedFileWithGradesDelegate RemovedFileWithGrades;
        public static event RemovedFileWithDescriptionDelegate RemovedFileWithDescription;
        public static event DeletedDatabaseFileDelegate DeletedDatabaseFile;

        // plik, który przechowuje listę z autami na sprzedaż

        const string databaseCarsForSale = "CarForSaleDatabase.txt";

        // metoda sprawdza czy wprowadzone dane są poprawne, aby dodać można było utworzyć obiekt typu CarForsSaleInFile i dodać go do listy w pliku

        public static void CheckCorrectDataCar(string namecar, string modelcar, string bodytype, string engine, string battery,
                                               string fuel, string color, string horsepower, string fuelcomsumption, string energycomsumption,
                                               string max_speed, string yearprod, string sprice)
        {
            List<string> messageError = new List<string>();
            int enginesize, maxspeed, hp, yearproduction;
            Fuel fueltype;
            float batterysize, fuelcoms, enercoms, price;

            if (namecar != null && namecar !="")
            {
                if (!namecar.All(Char.IsLetter))
                {
                    messageError.Add("Namecar: string contains invalid characters (namecar can only contain letter)!");
                }
            }
            else
            {
                messageError.Add("Namecar: value is empty (namecar can only contain letter)!");
            }

            if (modelcar != null && modelcar !="")
            {
                if (!Regex.IsMatch(modelcar, @"^[\sa-zA-Z0-9]+$"))
                {
                    messageError.Add("Modelcar: string contains invalid characters (modelcar can only contain letter, number or whitespace between)!");
                }
            }
            else
            {
                messageError.Add("Modelcar: value is empty (modelcar can only contain letter, number or whitespace between)!");
            }

            if (bodytype != null && bodytype != "")
            {
                bodytype = bodytype[0].ToString().ToUpper() + bodytype.Substring(1);

                if (!(bodytype == Body.Hatchback.ToString() || bodytype == Body.Sedan.ToString() || bodytype == Body.Liftback.ToString() || bodytype == Body.Combi.ToString() ||
                    bodytype.ToUpper() == Body.SUV.ToString().ToLower() || bodytype == Body.Crossover.ToString() || bodytype == Body.Cabriolet.ToString() ||
                    bodytype == Body.Coupe.ToString() || bodytype == Body.Roadster.ToString()))
                {
                    messageError.Add("Car body type: value is not correct body (Correct value: Hatchback, Sedan, Liftback, Combi, SUV, Crossover, Cabriolet, Coupe, Roadster)!");
                }
            }
            else
            {
                messageError.Add("Car body type: is empty (Correct value: Hatchback, Sedan, Liftback, Combi, SUV, Crossover, Cabriolet, Coupe, Roadster)!");
            }

            if (int.TryParse(engine, out enginesize))
            {
                if (!(enginesize >= 0 && enginesize <= 8000))
                {
                    messageError.Add("Engine size: value is out of range (range 0-8000)!");
                }
            }
            else
            {
                messageError.Add("Engine size: value is not int number or empty (range 0-8000)!");
            }

            if (float.TryParse(battery, out batterysize))
            {

                if (!(batterysize >= 0 && batterysize <= 200))
                {
                    messageError.Add("Battery capacity: value is out of range (range 0-200)!");
                }
            }
            else
            {
                messageError.Add("Battery capacity: value is not float number or empty (range 0-200)!");
            }
            if (fuel != null && fuel !="")
            {
                if (!(fuel.ToLower() == Fuel.Petrol.ToString().ToLower() || fuel.ToLower() == Fuel.Diesel.ToString().ToLower() || fuel.ToLower() == Fuel.Hybrid.ToString().ToLower() || fuel.ToLower() == Fuel.ElectricVehicle.ToString().ToLower()))
                {
                    messageError.Add("Fuel: value is not correct fuel (Correct value: Petrol, Diesel, Hybrid, ElectricVehicle)!");
                }
            }
            else
            {
                messageError.Add("Fuel: value is empty (Correct value: Petrol, Diesel, Hybrid, ElectricVehicle)!");
            }

            if (color != null && color !="")
            {
                if (!color.All(Char.IsLetter))
                {
                    messageError.Add("Color: string contains invalid characters (color can only contain letter)!");
                }
            }
            else
            {
                messageError.Add("Color: string is empty (color can only contain letter)!");
            }

            if (int.TryParse(horsepower, out hp))
            {
                if (!(hp > 0 && hp <= 2000))
                {
                    messageError.Add("Horsepower:value is out of range (range 0-2000)!");
                }
            }
            else
            {
                messageError.Add("Horsepower: value is not int number or empty (range 0-2000)!");
            }

            if (float.TryParse(fuelcomsumption, out fuelcoms))
            {
                if (!(fuelcoms >= 0 && fuelcoms <= 40))
                {
                    messageError.Add("Fuel consumption: value is out of range (range 0-40)!");
                }
            }
            else
            {
                messageError.Add("Fuel  consumption: value is not float number or empty (range 0-40)!");
            }

            if (float.TryParse(energycomsumption, out enercoms))
            {
                if (!(enercoms >= 0 && enercoms <= 60))
                {
                    messageError.Add("Energy consumption: value is out of range (range 0-60)!");
                }
            }
            else
            {
                messageError.Add("Energy consumption: value is not float number or empty (range 0-60)!");
            }

            if (int.TryParse(max_speed, out maxspeed))
            {
                if (!(maxspeed > 1 && maxspeed <= 1000))
                {
                    messageError.Add("Maximum speed: value is out of range (range 1-1000)!");
                }
            }
            else
            {
                messageError.Add("Maximum speed: value is not int number or empty (range 1-1000)!");
            }

            if (int.TryParse(yearprod, out yearproduction))
            {
                if (!(yearproduction > 1960 && yearproduction < DateTime.Now.Year))
                {
                    messageError.Add($"Year production: value is out of range (range 1960-{DateTime.Now.Year})!");
                }
            }
            else
            {
                messageError.Add($"Year production: value is not int number or empty (range 1960-{DateTime.Now.Year})!");
            }

            if (float.TryParse(sprice, out price))
            {
                if (!(price >= 0))
                {
                    messageError.Add("Price: value cannot be negative (price can be positive float number or zero)!");
                }
            }
            else
            {
                messageError.Add("Price: value is not float number or empty (price can be positive float number or zero)!");
            }
            // sekcja sprawdza czy dodano jakieś adnotacje z błędami czyli lista nie jest pusta (właściwość listy:Count)
            // jeśli adnotacje są, to rzuca wyjątek z listą błędów walidacji danych, jeśli ich nie ma to ustawia tutaj eventa
            // o poprawności danych
            if (messageError.Count > 0)
            {
                string errorList= $"total count of errors: {messageError.Count}.\n";

                foreach (var error in messageError)
                {
                    errorList = errorList + error + "\n";
                }
                throw new Exception(errorList);
            }
            else
            {
                if (CheckedCorrectCarData != null)
                {
                    CheckedCorrectCarData(null, EventArgs.Empty);
                }
            }
        }

        //     metoda dodaje dane z utworzonego obiektu CarForSaleInFile do listy z autami na sprzedaż zapisanej w pliku 
        public static void AddCarForSale(string namecar, string modelcar, string bodytype, int enginesize, float batterysize,
                                string fueltype, string color, int hp, float fuelcoms, float enercoms,
                                int maxspeed, int yearproduction, float price)
        {

            bodytype = (bodytype.Equals(Body.SUV.ToString(),StringComparison.CurrentCultureIgnoreCase)) ? bodytype.ToUpper() : bodytype[0].ToString().ToUpper() + bodytype.Substring(1);
            Body typeBody = CheckBodyCar(bodytype);
            Fuel typeFuel = CheckTypeFuel(fueltype); ;
            

            var car = new CarForSaleInFile(namecar, modelcar, typeBody, enginesize, batterysize,
                                           typeFuel, color, hp, fuelcoms, enercoms,
                                           maxspeed, yearproduction, price);
            using (var writer = File.AppendText(databaseCarsForSale))
            {

                writer.WriteLine(car.CarID + "|" +
                                 car.NameCar + "|" +
                                 car.ModelCar + "|" +
                                 car.BodyType + "|" +
                                 car.EngineSize + "|" +
                                 car.BatteryCapacity + "|" +
                                 car.FuelType + "|" +
                                 car.Color + "|" +
                                 car.HP + "|" +
                                 car.AverageFuelComsumptionPer100KM + "|" +
                                 car.AverageEnergyComsumptionPer100KM + "|" +
                                 car.MaximumSpeed + "|" +
                                 car.YearProduction + "|" +
                                 car.Price);
            }
            
            if (CarAddedToDatabase != null)
            {
                CarAddedToDatabase(null, EventArgs.Empty);
            }
        }

        // metoda sprawdza zmienną string odpowiadający którejś z wartości typu wyliczeniowego Body ( czyli typu nadwozia) i zwraca konkretną wartość jako typ wyliczeniowy

        static Body CheckBodyCar(string bodytype)
        {
            Body btype = new Body();
            foreach (var item in Enum.GetValues(typeof(Body)))
            {
                if (bodytype == item.ToString())
                {
                    btype = (Body)item;
                }
            }
            return btype;
        }
        
        // metoda sprawdza zmienną string odpowiadający którejś z wartości typu wyliczeniowego Fuel ( czyli rodzaj paliwa) i zwraca konkretną wartość jako typ wyliczeniowy
        static Fuel CheckTypeFuel(string fueltype) 
        {
            Fuel ftype = new Fuel();    
            foreach (var item in Enum.GetValues(typeof(Fuel)))
            {
                if (fueltype.Equals(item.ToString(), StringComparison.CurrentCultureIgnoreCase))
                {
                    ftype = (Fuel)item;
                }
            }
            return ftype;
        }

        // Metoda zwraca listę z autami na sprzedaż pobranymi z pliku 
        // jeśli lista nie istnieje rzuca wyjątek

        public static List<CarForSaleInFile> GetCars()
        {
            if (File.Exists(databaseCarsForSale))
            {
                List<CarForSaleInFile> carsforsale = new List<CarForSaleInFile>();
                using (var reader = File.OpenText(databaseCarsForSale))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                       
                        string[] dataCar = line.Split("|");

                        Body typeBody = CheckBodyCar(dataCar[3]);
                        Fuel typeFuel = CheckTypeFuel(dataCar[6]);
                        
                        carsforsale.Add(new CarForSaleInFile(int.Parse(dataCar[0]), dataCar[1], dataCar[2],  typeBody, int.Parse(dataCar[4]), float.Parse(dataCar[5]),
                                                           typeFuel, dataCar[7], int.Parse(dataCar[8]), float.Parse(dataCar[9]), float.Parse(dataCar[10]),
                                                           int.Parse(dataCar[11]), int.Parse(dataCar[12]), float.Parse(dataCar[13])));
                        
                        line = reader.ReadLine();
                        
                    }
                }
                return carsforsale;
            }
            else
            {
                throw new Exception("File with database carsforsale not exists!");
            }
        }

        //metoda usuwa obiekt typ car z listy czyli z pliku o podanym identyfikatorze ( jeśli istnieją pliki z ocenami auta oraz z opiniami
        //dotyczącymi tego auta to także zostają one usunięte), jeśli podamy nieistniejący identyfikator to metoda rzuca wyjątek, jeśli identyfikator
        //istnieje, usuwany auto o podanym id z listy a potem nową listę zapisujemy w pliku. Jeśli usuniemy ostatnie auto z listy , program usunie
        //plik z listą auta na sprzedaż, jeśli uruchomiono program po raz pierwszy lub nie dodano żadnego auta, to metoda rzuci wyjatek, że plik z listą 
        // nie istnieje
        // dodano eventy z usunięciem pliku z ocenami i opiniami oraz event o usunięciu auta z pliku i usunięciu pustego pliku z listą aut na sprzedaż

        public static void RemoveCar(int idcar)
        {
            if (File.Exists(databaseCarsForSale))
            {
                List<CarForSaleInFile> cars = GetCars();
                bool wantedidcar = false;
                
                foreach (CarForSaleInFile car in cars)
                {
                    if (idcar == car.CarID)
                    {
                        wantedidcar = true;
                        if (File.Exists(car.GetFileNameWithGrade()))
                        {
                            File.Delete(car.GetFileNameWithGrade());
                            if (RemovedFileWithGrades != null)
                            {
                                RemovedFileWithGrades(null, EventArgs.Empty);
                            }

                        }
                        if (File.Exists(car.GetFileNameWithDescription()))
                        {
                            File.Delete(car.GetFileNameWithDescription());
                            if (RemovedFileWithDescription != null) 
                            { 
                                RemovedFileWithDescription(null, EventArgs.Empty);
                            }
                        }

                        string allID;
                        using (var reader = File.OpenText(car.GetFileWithExistingID()))
                        {
                            allID = reader.ReadToEnd();
                        }
                        allID = allID.Remove(allID.IndexOf(idcar.ToString()), idcar.ToString().Length+1);
                        using (var writer = File.CreateText(car.GetFileWithExistingID()))
                        {
                            writer.Write(allID);
                        }
                        cars.Remove(car);
                        break;
                    }
                
                }   

                if (wantedidcar == false)
                {
                    throw new Exception("That car with an ID not exists in database");
                }
                else
                {   
                    using (var writer = File.CreateText(databaseCarsForSale))
                    {
                        foreach (var itemcar in cars)
                        {
                            writer.WriteLine(itemcar.CarID + "|" +
                                             itemcar.NameCar + "|" +
                                             itemcar.ModelCar + "|" +
                                             itemcar.BodyType + "|" +
                                             itemcar.EngineSize + "|" +
                                             itemcar.BatteryCapacity + "|" +
                                             itemcar.FuelType + "|" +
                                             itemcar.Color + "|" +
                                             itemcar.HP + "|" +
                                             itemcar.AverageFuelComsumptionPer100KM + "|" +
                                             itemcar.AverageEnergyComsumptionPer100KM + "|" +
                                             itemcar.MaximumSpeed + "|" +
                                             itemcar.YearProduction + "|" +
                                             itemcar.Price);

                        }
                    }
                    if (CarRemovedFromDatabase != null)
                    {
                        CarRemovedFromDatabase(null, EventArgs.Empty);
                    }
                    if (cars.Count == 0)
                    {
                        File.Delete(databaseCarsForSale);
                        if (DeletedDatabaseFile != null)
                        {
                            DeletedDatabaseFile(null, EventArgs.Empty);
                        }
                    }
                }
            }
            else
            {
                throw new Exception("Database with carsforsale not exists! First launch of the application or any car added to file");
            }
        }

    }
}
