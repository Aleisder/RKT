using MaiProject.Model;
using MaiProject.Repository;
using System.Collections.ObjectModel;

namespace DemoExam.Services
{
    public class UserService
    {
        public readonly ObservableCollection<User> users = new();
        private readonly UserRepository userRepository = new();

        public UserService() => userRepository.GetAll().ForEach(x => users.Add(x));

        public void Add(User user)
        {
            int userId = userRepository.Add(user);
            User addedUser = userRepository.GetById(userId);
            users.Add(addedUser);
        }

        public void Update(int index, User user)
        {
            users.RemoveAt(index);
            users.Insert(index, user);
            userRepository.Update(user);
        }

        public void Delete(User user)
        {
            users.Remove(user);
            userRepository.Delete(user);
        }

        public User GetById(int id) => userRepository.GetById(id);

    }
}
