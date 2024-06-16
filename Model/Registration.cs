namespace MaiProject.Model
{
    public class Registration
    {
        public int Id { get; set; }
        public Region Region { get; set; }    // Регион
        public string Station { get; set; }   // Пункт
        public string Street { get; set; }    // Улица
        public string Building { get; set; }  // Строение
        public string Housing { get; set; }   // Корпус
        public string Apartment { get; set; } // Квартира

        public Registration(int id, Region region, string station, string street, string building, string housing, string apartment)
        {
            Id = id;
            Region = region;
            Station = station;
            Street = street;
            Building = building;
            Housing = housing;
            Apartment = apartment;
        }
    }
}
