namespace MaiProject.Model
{
    public class Citizenship
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Citizenship(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
