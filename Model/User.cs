namespace MaiProject.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Employee Employee { get; set; }

        public User(int id, string login, string password, Employee employee)
        {
            Id = id;
            Login = login;
            Password = password;
            Employee = employee;
        }
    }
}
