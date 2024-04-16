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
void DisplayReturnToMainMenu()
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Return to main menu");
    Console.ForegroundColor = ConsoleColor.White;
}
void DisplayReturnToSubmenu()
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Return to submenu.");
    Console.ForegroundColor = ConsoleColor.White;
}
void DisplayMainMenu()
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
}
void DisplaySubmenu()
{
    Console.WriteLine("*********************************\n" +
                      "*            Submenu            *\n" +
                      "*********************************\n" +
                      "Choose option:\n" +
                      "1. Add grade to car\n" +
                      "2. Display all statistics for car\n" +
                      "3. Display characteristic for car\n" +
                      "4. Exit to main menu");
}
CarForSaleInMemory CreatingObjectForCarForSaleInMemory()
{
    Console.Clear();
    Console.WriteLine("********************************************\n" +
                      "*   Creating object for class CarForSale   *\n" +
                      "********************************************");
    Random rnd = new Random();
    var choosen = rnd.Next(0, 4);
    choosen = (choosen == 0) ? choosen = 1 : (choosen == 4) ? choosen = 3 : choosen;
    var carforsale = (choosen == 1) ? new CarForSaleInMemory("Audi", "A6", Body.Combi, 3000, Fuel.Diesel, "Bordowy", 345, 8.0f, 2016, 78000) : (choosen == 2) ? new CarForSaleInMemory("Volvo", "V70", Body.Combi, 2500, Fuel.Diesel, "Błękitny", 250, 7.0f, 2014, 60000) : new CarForSaleInMemory("Renault", "Clio", Body.Hatchback, 1800, Fuel.Petrol, "Biały", 260, 6.0f, 2018, 80000);
    Console.WriteLine("*******************************************************\n" +
                      "*   Random object class CarForSale has been created   *\n" +
                      "*******************************************************");
    return carforsale;
}
CarForSaleInFile CreatingObjectForCarForSaleInFile()
{
    Console.Clear();
    Console.WriteLine("**************************************************\n" +
                      "*   Creating object for class CarForSaleInFile   *\n" +
                      "**************************************************");

    Random rnd = new Random();
    var choosen = rnd.Next(0, 4);
    choosen = (choosen == 0) ? choosen = 1 : (choosen == 4) ? choosen = 3 : choosen;
    var carforsale = (choosen == 1) ? new CarForSaleInFile("Audi", "A6", Body.Combi, 3000, Fuel.Diesel, "Bordowy", 345, 8.0f, 2016, 78000) : (choosen == 2) ? new CarForSaleInFile("Volvo", "V70", Body.Combi, 2500, Fuel.Diesel, "Błękitny", 250, 7.0f, 2014, 60000) : new CarForSaleInFile("Renault", "Clio", Body.Hatchback, 1800, Fuel.Petrol, "Biały", 260, 6.0f, 2018, 80000);
    Console.WriteLine("*************************************************************\n" +
                      "*   Random object class CarForSaleInFile has been created   *\n" +
                      "*************************************************************");
    return carforsale;
}
void ShowMessage(string message)
{
    Console.SetCursorPosition(0, Console.GetCursorPosition().Top);
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"{message}");
    Console.ForegroundColor = ConsoleColor.White;
}
void DisplayIncorrectOption()
{
    Console.SetCursorPosition(0, Console.GetCursorPosition().Top);
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Incorrect option.Please again choose correct option!!");
    Console.ForegroundColor = ConsoleColor.White;
}
void DisplayCharacteristicCar(CharacteristicCar charcar , string car)
{
    Console.WriteLine("--------------------------------------------------\n" +
                      $"           {car}                                 \n" +
                      "--------------------------------------------------\n" +
                      $"Stan auta: {car} {charcar.CarCondition}.\n" +
                      $"Opis auta: {charcar.DescriptionCar}\n" +
                      $"Spalanie:  {charcar.FuelConsumption}. \n" +
                      "--------------------------------------------------");
    Console.WriteLine("Press any key to return to submenu");
    Console.ReadKey();
    Console.Clear();
}
void DisplayStatistics(Statistics stats, string car)
{
    Console.WriteLine($"****************************************************\n" +
                      $"      Statistics for car {car}\n" +
                      $"****************************************************\n" +
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
void DisplayNoAddedGrades()
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("No rating added. First, add ratings for car to view car stats.");
    Console.ForegroundColor = ConsoleColor.White;
}
while (true)
{
    DisplayMainMenu();
    var choosenOption = Console.ReadKey();
    
    switch (choosenOption.Key)
    {
        case ConsoleKey.D1:
        case ConsoleKey.NumPad1:
            var ret = false;
            var carforsale = CreatingObjectForCarForSaleInMemory();
            carforsale.GradeAddedToCar += Carforsale_GradeAddedToCar;
            do
            {
                DisplaySubmenu();
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
                                    DisplayReturnToSubmenu();
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
                                ShowMessage(ex.Message);
                            }
                        } while (true);
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        if (carforsale.GetGrades().Count == 0)
                        {
                            ShowMessage("No rating added. First, add ratings for car to view car stats.");
                            await Task.Delay(2000);
                            Console.Clear();
                        }
                        else
                        {
                            Statistics stats = carforsale.GetStatistics();
                            DisplayStatistics(stats, carforsale.NameCar + " " + carforsale.ModelCar);
                        }
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        CharacteristicCar charcar = carforsale.GetCharacteristicCar();
                        DisplayCharacteristicCar(charcar, carforsale.NameCar + " " + carforsale.ModelCar);
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        ret = true;
                        DisplayReturnToSubmenu();
                        await Task.Delay(1500);
                        break;
                    default:
                        DisplayIncorrectOption();
                        await Task.Delay(2000);
                        Console.Clear();
                        break;
                }
            } while (!ret);
            break;
        case ConsoleKey.D2:
        case ConsoleKey.NumPad2:
            var carforsaleinfile = CreatingObjectForCarForSaleInFile();
            carforsaleinfile.GradeAddedToCar += Carforsaleinfile_GradeAddedToCar;
            carforsaleinfile.DownloadedGradesFromFile += Carforsaleinfile_DownloadedGradesFromFile;
            ret = false;
            do
            {
                DisplaySubmenu();
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
                                    DisplayReturnToSubmenu();
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
                                ShowMessage(ex.Message);
                            }
                        } while (true);
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        if (!File.Exists(carforsaleinfile.GetFileWithGrades()))
                        {
                            ShowMessage("No rating added. File with grades no exists. First, add ratings for car to view car stats.");
                            await Task.Delay(3000);
                            Console.Clear();
                        }
                        else
                        {
                            Console.Clear();
                            Statistics stats = carforsaleinfile.GetStatistics();
                            DisplayStatistics(stats, carforsaleinfile.NameCar + " " + carforsaleinfile.ModelCar);
                            
                        }
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        CharacteristicCar charcar = carforsaleinfile.GetCharacteristicCar();
                        DisplayCharacteristicCar(charcar, carforsaleinfile.NameCar + " " + carforsaleinfile.ModelCar);
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        ret = true;
                        DisplayReturnToMainMenu();
                        await Task.Delay(1500);
                        break;
                    default:
                        DisplayIncorrectOption();
                        await Task.Delay(2000);
                        Console.Clear();
                        break;
                }
            } while (!ret);
            break;
        case ConsoleKey.D3:
        case ConsoleKey.NumPad3:
            ShowMessage("Goodbye");
            Environment.Exit(0);
            break;
        default:
            DisplayIncorrectOption();
            await Task.Delay(2000);
            break;
    }
}

