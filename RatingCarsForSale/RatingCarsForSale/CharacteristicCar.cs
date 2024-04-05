


namespace RatingCarsForSale
{
    public class CharacteristicCar
    {
        public string CarCondition { get; private set; }
        public string DescriptionCar { get; private set; }
        public string FuelConsumption {  get; private set; }
        public CharacteristicCar()
        {
            this.CarCondition = "brak danych";
            this.DescriptionCar ="brak danych";
            this.FuelConsumption = "brak danych";
        }
        public void AddInfoCar(CarBase car) 
        {
            int year = DateTime.Now.Year;
            int howold = year - car.YearProduction;
            switch (howold)
            {
                case 0:
                case 1:
                    this.CarCondition = "jest to nowe auto";
                    break;
                case <= 5:
                    this.CarCondition = "jest to prawie nowe auto";
                    break;
                case > 5 and <= 8:
                    this.CarCondition = "jest to stosunkowo młode auto";
                    break;
                case > 8 and <= 12:
                    this.CarCondition = "ma średni wiek jakdla auta";
                    break;
                case > 10 and <= 15:
                    this.CarCondition = "to już stare auto";
                    break ;
                case > 15:
                    this.CarCondition = "jest bardzo starym autem";
                    break ;
            }
            var cons = car.AverageFuelComsumptionPer100KM;
            switch (cons)
            {
                case <= 5.5f:
                    if (car.FuelType == Fuel.Diesel)
                    {
                        this.FuelConsumption = " Ten diesel bardzo mało pali i jest bardzo oszczędny.";
                    }
                    if (car.FuelType == Fuel.Petrol)
                    {
                        this.FuelConsumption = "Ten samochód jest bardzo oszczędny i ma niewielki apetyt na benzynę.";
                    }
                    break;
                case > 5.5f and <=7:
                    if (car.FuelType == Fuel.Diesel)
                    {
                        this.FuelConsumption = "Ten diesel pali niewiele więcej i jest ekonomiczny.";
                    }
                    if (car.FuelType == Fuel.Petrol)
                    {
                        this.FuelConsumption = "Ten samochód jest oszczędny i zużywa niewiele paliwa.";
                    }
                    break;
                    case > 7 and <=10:
                    if (car.FuelType == Fuel.Petrol)
                    {
                        this.FuelConsumption = "Ten samochód pali trochę więcej paliwa niż większość stawki.";
                    }
                    if (car.FuelType == Fuel.Diesel )
                    {
                        this.FuelConsumption = "Jak na diesla samochód spala trochę powyżej normy niż najoszczędniejsze jednostki wysokoprężne";
                    }
                    break;
                case > 10:
                    if (car.FuelType == Fuel.Petrol)
                    {
                        this.FuelConsumption = "Ten samochód to prawdziwy pochłaniacz benzyny, nie kupuj jeśli nie masz zasobnego worka z pieniędzmi na paliwo.";
                    }
                    if (car.FuelType == Fuel.Diesel)
                    {
                        this.FuelConsumption = "Diesel, który pochłania takie ilości ropy to wysysacz pieniędzy z kieszeni.";
                    }
                    break;
            }

            this.DescriptionCar = $"Auto marki {car.NameCar} model {car.ModelCar} to {car.BodyType.ToString().ToLower()} w kolorze {car.Color}m posiada" +
               $" {(car.FuelType == Fuel.Petrol ? "silnik benzynowy" : (car.FuelType == Fuel.Diesel)? "silnik diesla" : car.FuelType == Fuel.Hybrid ? " napęd hybrydowy (silnik benzynowy + silnik elektryczny" : "silnik elektryczny")}" +
               $" {(car.FuelType == Fuel.ElectricVehicle?$"o mocy {car.HP}":car.FuelType == Fuel.Hybrid? $"o pojemności {car.EngineSize} cm3 i mocy łącznej {car.HP} KM" : $"o pojemności {car.EngineSize} cm3 o mocy {car.HP} KM ")}" +
               $"i prędkości maksymalnej {car.MaximumSpeed} km/h. Egzemplarz został wyprodukowany w roku {car.YearProduction}.";
        }
    }
}
