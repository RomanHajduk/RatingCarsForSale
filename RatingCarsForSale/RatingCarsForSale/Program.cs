using RatingCarsForSale;

void Carforsaleinfile_GradeAddedToCar(object sender, EventArgs args)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Grade added to file.");
    Console.ForegroundColor = ConsoleColor.White;
}
void Carforsale_GradeAddedToCar(object sender, EventArgs args)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Grade added to list.");
    Console.ForegroundColor = ConsoleColor.White;
}
void Carforsaleinfile_DownloadedGradesFromFile(object sender, EventArgs args)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Grade downloaded from file.");
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
                      "\n1. Create object for CarForSale (store in memory) " +
                      "\n2. Create object for class CarForSaleInFile (store in file)" +
                      "\n3. Exit the application");
    Console.SetCursorPosition(0,Console.GetCursorPosition().Top);
    var choosenOption = Console.ReadKey();
    
    switch (choosenOption.Key)
    {
        case ConsoleKey.D1:
        case ConsoleKey.NumPad1:
            Console.Clear();
            Console.WriteLine("********************************************\n" +
                              "*   Creating object for class CarForSale   *\n" +
                              "********************************************");
            
            Console.SetCursorPosition(0, Console.GetCursorPosition().Top);
            Random rnd = new Random();
            var choosen = rnd.Next(1, 3);
            CarForSaleInMemory carforsale;
            carforsale = (choosen == 1) ? new CarForSaleInMemory("Audi", "A6", Body.Combi, 3000, Fuel.Diesel, "Bordowy", 345, 8.0f, 2016, 78000) : (choosen == 2) ? new CarForSaleInMemory("Volvo", "V70", Body.Combi, 2500, Fuel.Diesel, "Błękitny", 250, 7.0f, 2014, 60000) : new CarForSaleInMemory("Renault", "Clio", Body.Hatchback, 1800, Fuel.Petrol, "Biały", 260, 6.0f, 2018, 80000);
            var ret = false;
            carforsale.GradeAddedToCar += Carforsale_GradeAddedToCar;
            Console.WriteLine("*******************************************************\n" +
                              "*   Random object class CarForSale has been created   *\n" +
                              "*******************************************************");
            do
            {
                Console.WriteLine("*********************************\n" +
                                  "*            Submenu            *\n" +
                                  "*********************************\n" +
                                  "Choose option:\n" +
                                  "1. Add grade to car\n" +
                                  "2. Display all statistics for car\n" +
                                  "3. Display characteristic for car\n" +
                                  "4. Exit to main menu");
                
                
                var choosenOption2 = Console.ReadKey();
                Console.SetCursorPosition(0, Console.GetCursorPosition().Top);
                
                switch (choosenOption2.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        Console.Clear();
                        do
                        {
                            Console.Write("Enter grade for car (range 0-10, A-E(grade letter) or press q and confirm to exit):");
                            var grade = Console.ReadLine();
                            try
                            {
                                if (grade.ToUpper() == "Q")
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Return to submenu.");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    await Task.Delay(1500);
                                    Console.Clear();
                                    break;
                                }
                                else
                                {
                                    carforsale.AddGrade(grade);
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ex.Message}");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        } while (true);
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        if (carforsale.GetGrades().Count == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("No rating added. First, add ratings for car to view car stats.");
                            Console.ForegroundColor = ConsoleColor.White;
                            await Task.Delay(3000);
                            Console.Clear();
                        }
                        else
                        {
                            Statistics stats = carforsale.GetStatistics();
                            Console.WriteLine($"*********************************************************************************");
                            Console.WriteLine($"            Statistics for car {carforsale.NameCar} {carforsale.ModelCar}");
                            Console.WriteLine($"*********************************************************************************\n" +
                                              $"Statystyki: \n" +
                                              $"Count of grades:      {stats.Count}\n" +
                                              $"Minimal grade:        {stats.Min}\n" +
                                              $"Maximum grade:        {stats.Max}\n" +
                                              $"Average from grades:  {stats.Average}\n" +
                                              $"Average (letter):     {stats.AverageLetter}\n");
                            Console.WriteLine("Press any key to return to submenu");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        CharacteristicCar charcar = carforsale.GetCharacteristicCar();
                        Console.WriteLine("---------------------------------------------------------------------------------------------------");
                        Console.WriteLine($"                        {carforsale.NameCar} {carforsale.ModelCar}                                ");
                        Console.WriteLine("---------------------------------------------------------------------------------------------------");
                        Console.WriteLine($"Stan auta: {carforsale.NameCar} {carforsale.ModelCar} {charcar.CarCondition}");
                        Console.WriteLine($"Opis auta: {charcar.DescriptionCar}");
                        Console.WriteLine($"Spalanie:  {charcar.FuelConsumption}");
                        Console.WriteLine("---------------------------------------------------------------------------------------------------");
                        Console.WriteLine("Press any key to return to submenu");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        ret = true;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Return to main menu");
                        Console.ForegroundColor = ConsoleColor.White;
                        await Task.Delay(1500);
                        break;
                    default:
                        Console.SetCursorPosition(0, Console.GetCursorPosition().Top);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Incorrect option.Please again choose correct option!!");
                        Console.ForegroundColor = ConsoleColor.White;
                        await Task.Delay(2000);
                        Console.Clear();
                        break;
                }
            } while (!ret);
            break;
        case ConsoleKey.D2:
        case ConsoleKey.NumPad2:
            Console.Clear();
            Console.WriteLine("**************************************************\n" +
                              "*   Creating object for class CarForSaleInFile   *\n" +
                              "**************************************************");

            if (Console.GetCursorPosition().Left != 0)
            {
                Console.SetCursorPosition(0, Console.GetCursorPosition().Top);
            }
            rnd = new Random();
            choosen = rnd.Next(1, 3);
            CarForSaleInFile carforsaleinfile;
            carforsaleinfile = (choosen == 1) ? new CarForSaleInFile("Audi", "A6", Body.Combi, 3000, Fuel.Diesel, "Bordowy", 345, 8.0f, 2016, 78000) : (choosen == 2) ? new CarForSaleInFile("Volvo", "V70", Body.Combi, 2500, Fuel.Diesel, "Błękitny", 250, 7.0f, 2014, 60000) : new CarForSaleInFile("Renault", "Clio", Body.Hatchback, 1800, Fuel.Petrol, "Biały", 260, 6.0f, 2018, 80000);
            carforsaleinfile.GradeAddedToCar += Carforsaleinfile_GradeAddedToCar;
            carforsaleinfile.DownloadedGradesFromFile += Carforsaleinfile_DownloadedGradesFromFile;
            Console.WriteLine("*************************************************************\n" +
                              "*   Random object class CarForSaleInFile has been created   *\n" +
                              "*************************************************************");
            ret = false;
            do
            {
                Console.WriteLine("*********************************\n" +
                                  "*            Submenu            *\n" +
                                  "*********************************\n" +
                                  "Choose option:\n" +
                                  "1. Add grade to car\n" +
                                  "2. Display all statistics for car\n" +
                                  "3. Display characteristic for car\n" +
                                  "4. Exit to main menu");
                
                
                var choosenOption2 = Console.ReadKey();
                Console.SetCursorPosition(0, Console.GetCursorPosition().Top);
                
                switch (choosenOption2.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        Console.Clear();
                        do
                        {
                            Console.Write("Enter grade for car (range 0-10,A-E(grade letter) or press q and confirm to exit):");
                            var grade = Console.ReadLine();
                            try
                            {
                                if (grade.ToUpper() == "Q")
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Return to submenu.");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    await Task.Delay(1500);
                                    Console.Clear();
                                    break;
                                }
                                else
                                {
                                    carforsaleinfile.AddGrade(grade);
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ex.Message}");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        } while (true);
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        if (!File.Exists(carforsaleinfile.GetFileWithGrades()))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("No rating added. File with grades no exists. First, add ratings for car to view car stats.");
                            Console.ForegroundColor = ConsoleColor.White;
                            await Task.Delay(3000);
                            Console.Clear();
                        }
                        else
                        {
                            Console.Clear();
                            Statistics stats = carforsaleinfile.GetStatistics();
                            Console.WriteLine($"*********************************************************************************");
                            Console.WriteLine($"            Statistics for car {carforsaleinfile.NameCar} {carforsaleinfile.ModelCar}");
                            Console.WriteLine($"*********************************************************************************\n" +
                                              $"Statystyki: \n" +
                                              $"Count of grades:      {stats.Count}\n" +
                                              $"Minimal grade:        {stats.Min}\n" +
                                              $"Maximum grade:        {stats.Max}\n" +
                                              $"Average from grades:  {stats.Average}\n" +
                                              $"Average (letter):     {stats.AverageLetter}\n");
                            Console.WriteLine("Press any key to return to submenu");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        CharacteristicCar charcar = carforsaleinfile.GetCharacteristicCar();
                        Console.WriteLine("---------------------------------------------------------------------------------------------------");
                        Console.WriteLine($"                        {carforsaleinfile.NameCar} {carforsaleinfile.ModelCar}                                ");
                        Console.WriteLine("---------------------------------------------------------------------------------------------------");
                        Console.WriteLine($"Stan auta: {carforsaleinfile.NameCar} {carforsaleinfile.ModelCar} {charcar.CarCondition}");
                        Console.WriteLine($"Opis auta: {charcar.DescriptionCar}");
                        Console.WriteLine($"Spalanie:  {charcar.FuelConsumption}");
                        Console.WriteLine("---------------------------------------------------------------------------------------------------");
                        Console.WriteLine("Press any key to return to submenu");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        ret = true;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Return to main menu");
                        Console.ForegroundColor = ConsoleColor.White;
                        await Task.Delay(1500);
                        break;
                    default:
                        Console.SetCursorPosition(0, Console.GetCursorPosition().Top);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Incorrect option.Please again choose correct option!!");
                        Console.ForegroundColor = ConsoleColor.White;
                        await Task.Delay(2000);
                        Console.Clear();
                        break;
                }
            } while (!ret);
            break;
        case ConsoleKey.D3:
        case ConsoleKey.NumPad3:    
            Environment.Exit(0);
            break;
        default:
            Console.SetCursorPosition(0, Console.GetCursorPosition().Top);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Incorrect option.Please again choose correct option!!");
            Console.ForegroundColor= ConsoleColor.White;
            await Task.Delay(2000);
            break;
    }
}

