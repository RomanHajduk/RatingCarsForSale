using RatingCarsForSale;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Text.RegularExpressions;

List<CarForSaleInFile> carDatabase;
CarsForSaleDatabase.CheckedCorrectCarData += CarsForSaleDatabase_CheckedCorrectCarData;
CarsForSaleDatabase.CarAddedToDatabase += CarsForSaleDatabase_CarAddedToDatabase;
CarsForSaleDatabase.CarRemovedFromDatabase += CarsForSaleDatabase_CarRemovedFromDatabase;
CarsForSaleDatabase.DeletedDatabaseFile += CarsForSaleDatabase_DeletedDatabaseFile;
CarsForSaleDatabase.RemovedFileWithDescription += CarsForSaleDatabase_RemovedFileWithDescription;
CarsForSaleDatabase.RemovedFileWithGrades += CarsForSaleDatabase_RemovedFileWithGrades;

void CarsForSaleDatabase_RemovedFileWithGrades(object sender, EventArgs args)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("The file with grades for choosen car has been deleted!");
    Console.ForegroundColor = ConsoleColor.White;
}

void CarsForSaleDatabase_RemovedFileWithDescription(object sender, EventArgs args)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("The file with reviews for choosen car has been deleted!");
    Console.ForegroundColor = ConsoleColor.White;
}

void CarsForSaleDatabase_DeletedDatabaseFile(object sender, EventArgs args)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Database is empty. Database has been deleted!");
    Console.ForegroundColor = ConsoleColor.White;
}

void CarsForSaleDatabase_CarRemovedFromDatabase(object sender, EventArgs args)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Car deleted from database.");
    Console.ForegroundColor = ConsoleColor.White;
}

void CarForSaleInFile_GradeAddedToCar(object sender, EventArgs args)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Grade added.");
    Console.ForegroundColor= ConsoleColor.White;
}

void CarForSaleInFile_DescriptionAddedToCar(object sender, EventArgs args)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Added review for choosen car.");
    Console.ForegroundColor = ConsoleColor.White;
}
void CarsForSaleDatabase_CarAddedToDatabase(object sender,EventArgs args)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Added Car for sale to database.");
    Console.ForegroundColor = ConsoleColor.White;
}

void CarsForSaleDatabase_CheckedCorrectCarData(object sender, EventArgs args)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Added correct data for car");
    Console.ForegroundColor = ConsoleColor.White;
}

while (true)
{
    Console.Clear();
    Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n" +
                      "+              A System For Rating Cars For Sale              +\n" +
                      "+                         MAIN MENU                           +\n" +
                      "++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
    Console.WriteLine("Choose option:" +
                      "\n1. Add car to database" +
                      "\n2. Display list of cars for sale" +
                      "\n3. Remove car from database" +
                      "\n4. Exit the application");
    var choosenOption = Console.ReadKey();

    switch (choosenOption.Key)
    {
        case ConsoleKey.D1:
        case ConsoleKey.NumPad1:
            Console.Clear();
            Console.WriteLine("*********************************************\n" +
                              "*      Adding car for sale to database      *\n" +
                              "*********************************************");

            do
            {
                if (Console.GetCursorPosition().Left != 0)
                {
                    Console.SetCursorPosition(0, Console.GetCursorPosition().Top);
                }
                Console.Write("Enter the car brand: ");
                var namecar = Console.ReadLine();
                Console.Write("Enter the car model: ");
                var modelcar = Console.ReadLine();
                Console.Write("Enter the body type: ");
                string bodytype = Console.ReadLine();
                Console.Write("Enter the engine capacity: ");
                string enginesize = Console.ReadLine();
                Console.Write("Enter the battery capacity: ");
                string capacitybattery = Console.ReadLine();
                Console.Write("Enter the type of fuel: ");
                string fueltype = Console.ReadLine();
                Console.Write("Enter the color of the car: ");
                string color = Console.ReadLine();
                Console.Write("Enter car HP: ");
                string horsepower = Console.ReadLine();
                Console.Write("Enter the average fuel consumption per 100 km: ");
                string fuelconsumption = Console.ReadLine();
                Console.Write("Enter the average energy consumption per 100 km: ");
                string energyconsumption = Console.ReadLine();
                Console.Write("Enter the maximum speed of the car: ");
                string max_speed = Console.ReadLine();
                Console.Write("Enter the year of production: ");
                string yearprod = Console.ReadLine();
                Console.Write("Enter the price of the car: ");
                string price = Console.ReadLine();
                try
                {
                    CarsForSaleDatabase.CheckCorrectDataCar(namecar, modelcar, bodytype, enginesize, 
                                                            capacitybattery, fueltype, color, horsepower, 
                                                            fuelconsumption, energyconsumption, max_speed, yearprod, price);
                    
                    CarsForSaleDatabase.AddCarForSale(namecar, modelcar, bodytype, int.Parse(enginesize), float.Parse(capacitybattery), fueltype, color, int.Parse(horsepower),
                                                     float.Parse(fuelconsumption), float.Parse(energyconsumption), int.Parse(max_speed), int.Parse(yearprod), float.Parse(price));
                    
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red; 
                    Console.WriteLine(e.Message);
                    Console.ForegroundColor= ConsoleColor.White;
                    await Task.Delay(1500);
                    break;
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Press q to finish adding car to databsae or press any key to continue...!");
                Console.ForegroundColor = ConsoleColor.White;

            } while (Console.ReadKey().Key != ConsoleKey.Q);
            Console.Clear();
            break;
        case ConsoleKey.D2:
        case ConsoleKey.NumPad2:
            while (true)
            {
                Console.Clear();
                try
                {
                    carDatabase = CarsForSaleDatabase.GetCars();
                    Console.WriteLine("*************************************************************************************************\n" +
                                      "*                                     LISTA AUT NA SPRZEDAŻ                                     *\n" +
                                      "*************************************************************************************************");
                    Console.WriteLine("*      *            *             *           * Pojemność * Pojemność *               *              *      * Zużycie  * Zużycie  *  Prędkość  *           *          *");
                    Console.WriteLine("*  ID  *    Marka   *    Model    *    Typ    *  Silnika  *  Baterii  *     Paliwo    *    Kolor     *  KM  * Paliwa   * Energii  * Maksymalna *    Rok    *   Cena   *");
                    Console.WriteLine("*      *            *             *  Nadwozia *    cm^3   *     kW    *               *              *      * na 100km * na 100km *    km/h    * produkcji *          *");      
                    Console.WriteLine("***********************************************************************************************************************************************************************");
                    foreach (var car in carDatabase) 
                    {
                        Console.Write("*");
                        Console.SetCursorPosition(3, Console.GetCursorPosition().Top);
                        Console.Write(car.CarID);
                        Console.SetCursorPosition(7, Console.GetCursorPosition().Top);
                        Console.Write("*");
                        Console.SetCursorPosition(9, Console.GetCursorPosition().Top);
                        Console.Write(car.NameCar);
                        Console.SetCursorPosition(20, Console.GetCursorPosition().Top);
                        Console.Write("*");
                        Console.SetCursorPosition(22, Console.GetCursorPosition().Top);
                        Console.Write(car.ModelCar);
                        Console.SetCursorPosition(34, Console.GetCursorPosition().Top);
                        Console.Write("*");
                        Console.SetCursorPosition(36, Console.GetCursorPosition().Top);
                        Console.Write(car.BodyType);
                        Console.SetCursorPosition(46, Console.GetCursorPosition().Top);
                        Console.Write("*");
                        Console.SetCursorPosition(50, Console.GetCursorPosition().Top);
                        Console.Write(car.EngineSize);
                        Console.SetCursorPosition(58, Console.GetCursorPosition().Top);
                        Console.Write("*");
                        Console.SetCursorPosition(63, Console.GetCursorPosition().Top);
                        Console.Write(car.BatteryCapacity);
                        Console.SetCursorPosition(70, Console.GetCursorPosition().Top);
                        Console.Write("*");
                        Console.SetCursorPosition(72, Console.GetCursorPosition().Top);
                        Console.Write(car.FuelType);
                        Console.SetCursorPosition(86, Console.GetCursorPosition().Top);
                        Console.Write("*");
                        Console.SetCursorPosition(88, Console.GetCursorPosition().Top);
                        Console.Write(car.Color);
                        Console.SetCursorPosition(101, Console.GetCursorPosition().Top);
                        Console.Write("*");
                        Console.SetCursorPosition(103, Console.GetCursorPosition().Top);
                        Console.Write(car.HP);
                        Console.SetCursorPosition(108, Console.GetCursorPosition().Top);
                        Console.Write("*");
                        Console.SetCursorPosition(113, Console.GetCursorPosition().Top);
                        Console.Write(car.AverageFuelComsumptionPer100KM);
                        Console.SetCursorPosition(119, Console.GetCursorPosition().Top);
                        Console.Write("*");
                        Console.SetCursorPosition(124, Console.GetCursorPosition().Top);
                        Console.Write(car.AverageEnergyComsumptionPer100KM);
                        Console.SetCursorPosition(130, Console.GetCursorPosition().Top);
                        Console.Write("*");
                        Console.SetCursorPosition(135, Console.GetCursorPosition().Top);
                        Console.Write(car.MaximumSpeed);
                        Console.SetCursorPosition(143, Console.GetCursorPosition().Top);
                        Console.Write("*");
                        Console.SetCursorPosition(147, Console.GetCursorPosition().Top);
                        Console.Write(car.YearProduction);
                        Console.SetCursorPosition(155, Console.GetCursorPosition().Top);
                        Console.Write("*");
                        Console.SetCursorPosition(158, Console.GetCursorPosition().Top);
                        Console.Write(car.Price);
                        Console.SetCursorPosition(166, Console.GetCursorPosition().Top);
                        Console.WriteLine("*");
                    }
                    Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n" +
                                      "+                 Submenu Rating Cars For Sale                 +\n" +
                                      "+                                                              +\n" +
                                      "++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
                    Console.WriteLine("       \n1. Grade and add review for choosen car" +
                                      "       \n2. Grade and add review for all cars" +
                                      "       \n3. Display statistics for all cars" +
                                      "       \n4. Display characteristic for choosen car" +
                                      "       \n5. Display added review for choosen car" +
                                      "       \n6. Return to main menu");
                    Console.Write("Choose option:");
                    var choosenOption2 = Console.ReadKey();
                    
                    switch (choosenOption2.Key)
                    {
                        case ConsoleKey.D1:
                        case ConsoleKey.NumPad1:
                            Console.Clear();
                            Console.SetCursorPosition(0, Console.GetCursorPosition().Top);
                            Console.Write("Enter car id:");
                            var inputcarid = Console.ReadLine();
                            int idc;
                            bool exi = false;
                            if (int.TryParse(inputcarid,out idc))
                            {
                                carDatabase = CarsForSaleDatabase.GetCars();
                                foreach (var car in carDatabase)
                                {
                                    if (idc == car.CarID)
                                    {
                                        exi = true;
                                        Console.WriteLine($"Enter the grade car id " +
                                                          $"{car.CarID} " +
                                                          $"{car.NameCar} " +
                                                          $"{car.ModelCar} " +
                                                          $"(range: 1-10) or press q and confirm to finish:");
                                        car.GradeAddedToCar += CarForSaleInFile_GradeAddedToCar;
                                        car.DescriptionAddedToCar += CarForSaleInFile_DescriptionAddedToCar;

                                        while (true)
                                        {
                                            var grade = Console.ReadLine();
                                            if (grade.ToUpper() != "Q")
                                            {
                                                try
                                                {
                                                    car.AddGrade(grade);
                                                    Console.WriteLine($"Add review for car for the grade {grade}:");
                                                    var review = Console.ReadLine();
                                                    car.AddDescription(review, int.Parse(grade));

                                                }
                                                catch (Exception ex)
                                                {
                                                    throw new Exception(ex.Message);
                                                }
                                                Console.ForegroundColor = ConsoleColor.Green;
                                                Console.WriteLine("Enter another grade (press q and confirm to finish)");
                                                Console.ForegroundColor = ConsoleColor.White;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Grading completed for selected car!");
                                                await Task.Delay(1500);
                                                break;
                                            }
                                        }
                                    }
                                }
                                if (!exi)
                                {
                                    throw new Exception("The car with the given id does not exist");
                                }
                            }
                            else
                            {
                                throw new Exception("This value is not int number");
                            }
                            break;
                        case ConsoleKey.D2:
                        case ConsoleKey.NumPad2:
                            Console.SetCursorPosition(0, Console.GetCursorPosition().Top);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Rating every car for sale in database");
                            Console.ForegroundColor = ConsoleColor.White;
                            foreach (var itemcar in carDatabase)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write($"Enter the grade for car id :");
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write($" {itemcar.CarID} {itemcar.NameCar} {itemcar.ModelCar} ");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("(range: 0-10): Press q and confirm to finish");
                                Console.ForegroundColor = ConsoleColor.White;
                                while (true)
                                {
                                    var grade = Console.ReadLine();
                                    if (grade.ToUpper() != "Q")
                                    {
                                        try
                                        {
                                            itemcar.AddGrade(grade);
                                            Console.WriteLine($"Add a review about the car:");
                                            var review = Console.ReadLine();
                                            itemcar.AddDescription(review, int.Parse(grade));
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine("Please enter another grade and review ( press q and confirm to finish rating selected car");
                                            Console.ForegroundColor = ConsoleColor.White;
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine(ex.Message);
                                            Console.ForegroundColor = ConsoleColor.White;
                                        }
                                    }
                                    else
                                    {   
                                        Console.WriteLine($"Grading completed and adding reviews for car id: {itemcar.CarID}!");
                                        break;
                                    }
                                }
                            }
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Grading completed and adding reviews for all cars from database!");
                            Console.ForegroundColor = ConsoleColor.White;
                            await Task.Delay(1500);
                            break;
                        case ConsoleKey.D3:
                        case ConsoleKey.NumPad3:
                            Console.SetCursorPosition(0, Console.GetCursorPosition().Top);
                            Console.Clear();
                            foreach (var itemcar in carDatabase)
                            {
                                var statCar = itemcar.GetStatistics();
                                Console.WriteLine("*********************************************************************************\n" +
                                                  $"Auto ID: {itemcar.CarID} {itemcar.NameCar} {itemcar.ModelCar} paliwo: {itemcar.FuelType} KM: {itemcar.HP}\n" +
                                                  $"*********************************************************************************\n" +
                                                  $"Statystyki: \n" +
                                                  $"Count of grades:      {statCar.Count}\n" +
                                                  $"Minimal grade:        {statCar.Min}\n" +
                                                  $"Maximum grade:        {statCar.Max}\n" +
                                                  $"Average from grades:  {statCar.Average}\n" +
                                                  $"Average (letter):     {statCar.AverageLetter}\n");
                            }
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Press any key to return to menu");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.ReadKey();
                            break;
                        case ConsoleKey.D4:
                        case ConsoleKey.NumPad4:
                            Console.Clear();    
                            Console.SetCursorPosition(0, Console.GetCursorPosition().Top);
                            Console.Write("Enter carID : ");
                            var id = Console.ReadLine();
                            int idcar;
                            bool exist = false;
                            CharacteristicCar characteristicCar;
                            if (int.TryParse(id, out idcar))
                            {
                                foreach (var itemcar in carDatabase)
                                {
                                    if (idcar == itemcar.CarID)
                                    {
                                        exist = true;
                                        Console.WriteLine("---------------------------------------------------------------------------------------------------");
                                        Console.WriteLine($"                        {itemcar.NameCar} {itemcar.ModelCar}                                      ");
                                        Console.WriteLine("---------------------------------------------------------------------------------------------------");
                                        characteristicCar = itemcar.GetCharacteristicCar();
                                        Console.WriteLine($"Stan auta: {itemcar.NameCar} {itemcar.ModelCar} {characteristicCar.CarCondition}");
                                        Console.WriteLine($"Opis auta: {characteristicCar.DescriptionCar}");
                                        Console.WriteLine($"Spalanie:  {itemcar.NameCar} {itemcar.ModelCar} {characteristicCar.FuelConsumption}");
                                        Console.WriteLine("---------------------------------------------------------------------------------------------------");

                                    }
                                }
                                if (!exist)
                                {
                                    throw new Exception("The car with the given id does not exist");
                                }
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Enter to any key to return to menu");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.ReadKey();
                            }
                            else 
                            {
                                throw new Exception("This value is not int number");
                            }
                            
                            break;
                        case ConsoleKey.D5:
                        case ConsoleKey.NumPad5:
                            int dcar;
                            Console.Clear();
                            Console.SetCursorPosition(0, Console.GetCursorPosition().Top);
                            Console.Write("Enter carID : ");
                            var ids = Console.ReadLine();
                            Console.Clear();
                            bool carexists = false;
                            if (int.TryParse(ids, out dcar))
                            {
                                foreach (var itemcar in carDatabase)
                                {
                                    if (dcar == itemcar.CarID)
                                    {
                                        var list = itemcar.GetCommentSaleOffer();
                                        carexists = true;
                                        Console.ForegroundColor = ConsoleColor.Yellow;    
                                        Console.WriteLine($"CarID {itemcar.CarID} {itemcar.NameCar} {itemcar.ModelCar}");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        foreach (var itemreview in list)
                                        {
                                            Console.WriteLine(itemreview);
                                        }
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("Enter to any key to return to menu");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.ReadKey();
                                    }
                                }
                                if (!carexists)
                                {
                                    throw new Exception("The car with the given id does not exist");
                                }
                            }
                            else
                            {
                                throw new Exception("This value is not a int number");
                            }
                            break;
                        case ConsoleKey.D6:
                        case ConsoleKey.NumPad6:
                            Console.SetCursorPosition(0, Console.GetCursorPosition().Top);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Return to main menu.");
                            Console.ForegroundColor = ConsoleColor.White;
                            await Task.Delay(1500);
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("The selected option does not exist. Select again (opcje 1 - 6)");
                            Console.ForegroundColor = ConsoleColor.White;
                            await Task.Delay(1500);
                            break;
                    }
                    if (choosenOption2.Key == ConsoleKey.D6 || choosenOption2.Key == ConsoleKey.NumPad6)
                    {
                        break;
                    }
                 
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ForegroundColor = ConsoleColor.White;
                    await Task.Delay(1500);
                    
                }
            }
            break;
        case ConsoleKey.D3:
        case ConsoleKey.NumPad3:
            try
            {
                Console.Clear();
                carDatabase = CarsForSaleDatabase.GetCars();
                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine("Attention!! If car id exists, this option delete car from database with assigned grades and reviews");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Enter ID car to remove from database(or press q and confirm to finish)");
                Console.ForegroundColor = ConsoleColor.White;
                var idcar = Console.ReadLine();
                if (idcar.All(Char.IsDigit))
                {
                    CarsForSaleDatabase.RemoveCar(int.Parse(idcar));
                }
                else
                {
                    if (idcar.ToUpper() == "Q")
                    {
                        break;
                    }
                    else
                    {
                        throw new Exception("Podana wartość nie jest numerem");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
            await Task.Delay(2500);
            break;
        case ConsoleKey.D4:    
        case ConsoleKey.NumPad4:
            Environment.Exit(0);
            Console.WriteLine("Exiting Application!!!");
            await Task.Delay(1300);
            break;

    }
}
