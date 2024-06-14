namespace MaiProject.Model
{
    public class Education
    {
        public int Id { get; set; }
        public string Degree { get; set; }
        public string Institution { get; set; }
        public string DiplomaSeries { get; set; }
        public string DiplomaNumber { get; set; }
        public string Qualification { get; set; }
        public string Direction { get; set; }

        public Education(int id, string degree, string institution, string diplomaSeries, string diplomaNumber, string qualification, string direction)
        {
            Id = id;
            Degree = degree;
            Institution = institution;
            DiplomaSeries = diplomaSeries;
            DiplomaNumber = diplomaNumber;
            Qualification = qualification;
            Direction = direction;
        }
    }
}
