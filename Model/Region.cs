namespace MaiProject.Model
{
    public class Region
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Region(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
