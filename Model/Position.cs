namespace MaiProject.Model
{
    public class Position
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Position(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString() => Name;
    }
}
