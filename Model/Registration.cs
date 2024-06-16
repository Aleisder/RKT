namespace MaiProject.Model
{
    public class Registration
    {
        public int Id { get; set; }
        public Region Region { get; set; }     // Регион
        public string Station { get; set; }    // Пункт
        public string Street { get; set; }     // Улица
        public string House { get; set; }      // Дом
        public string Building { get; set; }   // Корпус
        public int Sctructure { get; set; }    // Строение  
        public int Apartment { get; set; }     // Квартира

        public Registration(int id, Region region, string station, string street, string house, string building, int structure, int apartment)
        {
            Id = id;
            Region = region;
            Station = station;
            Street = street;
            House = house;
            Building = building;
            Sctructure = structure;
            Apartment = apartment;
        }
    }
}
