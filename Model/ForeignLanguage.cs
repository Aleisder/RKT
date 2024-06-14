namespace MaiProject.Model
{
    public class ForeignLanguage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Level { get; set; }

        public ForeignLanguage(int id, string name, string level)
        {
            Id = id;
            Name = name;
            Level = level;
        }
    }
}
