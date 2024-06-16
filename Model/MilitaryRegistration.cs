namespace MaiProject.Model
{
    public class MilitaryRegistration
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int ReserveCategory { get; set; }
        public string Rank { get; set; }
        public string Team { get; set; }
        public string Specialization { get; set; }
        public string Suitability { get; set; }
        public string Commissariat { get; set; }
        public string MilitaryState { get; set; }
        public string Fired { get; set; }

        public MilitaryRegistration(int id, string number, int reserveCategory, string rank, string team, string specialization, string suitability, string commissariat, string militaryState, string fired)
        {
            Id = id;
            Number = number;
            ReserveCategory = reserveCategory;
            Rank = rank;
            Team = team;
            Specialization = specialization;
            Suitability = suitability;
            Commissariat = commissariat;
            MilitaryState = militaryState;
            Fired = fired;
        }
    }
}
