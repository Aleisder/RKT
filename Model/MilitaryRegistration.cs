namespace MaiProject.Model
{
    public class MilitaryRegistration
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Category { get; set; }
        public string Rank { get; set; }

        public MilitaryRegistration(int id, string number, string category, string rank)
        {
            Id = id;
            Number = number;
            Category = category;
            Rank = rank;
        }
    }
}
