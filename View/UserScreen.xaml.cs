using DemoExam.Services;
using MaiProject.Model;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DemoExam.View
{
    public partial class UserScreen : Window
    {
        private readonly UserService userService;

        public UserScreen(int userId)
        {
            InitializeComponent();
            userService = new();

            UserDataGrid.ItemsSource = userService.users;
            UserListView.Visibility = Visibility.Collapsed;
        }

        private void OpenAddUserWindowClick(object sender, RoutedEventArgs e) => OpenAddUserWindow();

        private void CloseAddUserWindowClick(object sender, RoutedEventArgs e) => CloseAddUserWindow();

        private void CloseAddUserWindow()
        {
            RequestGrid.Visibility = Visibility.Collapsed;
            ClearTextBoxes();
        }

        private void OpenAddUserWindow()
        {
            RequestGrid.Visibility = Visibility.Visible;
            RequestButton.Visibility = Visibility.Visible;
            UpdateButton.Visibility = Visibility.Collapsed;
        }

        private void ClearTextBoxes()
        {
            SurnameTextxBox.Clear();
            NameTextBox.Clear();
            LoginTextBox.Clear();
            PasswordTextBox.Clear();
            RoleComboBox.Text = "";
        }

        private void ConfirmUserClick(object sender, RoutedEventArgs e)
        {
            var role = (Position)RoleComboBox.SelectedItem;

            //userService.Add(user);
            CloseAddUserWindow();
            ClearTextBoxes();
        }

        private void ExitClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var result = MessageBox.Show("Вы действительно хотите выйти из учётной записи?", "Выход", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                var screen = new AuthorizationScreen();
                screen.Show();
                Close();
            }
        }

        private void DeleteUserClick(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Вы действительно хотите удалить пользователя?", "Подтвердите действие", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                int index = UserListView.SelectedIndex;
                User user = userService.users.ElementAt(index);
                if (user != null)
                {
                    userService.Delete(user);
                }
            }
        }

        private void UserListItemClick(object sender, SelectionChangedEventArgs e)
        {
            switch (UserListView.SelectedItems.Count)
            {
                case 0:
                    DisableEditAndDeleteButtons();
                    break;
                case 1:
                    EnableEditAndDeleteButtons();
                    break;
                default:
                    EditButton.IsEnabled = false;
                    DeleteButton.IsEnabled = true;
                    break;
            }
        }

        private void EnableEditAndDeleteButtons()
        {
            DeleteButton.IsEnabled = true;
            EditButton.IsEnabled = true;
        }

        private void DisableEditAndDeleteButtons()
        {
            DeleteButton.IsEnabled = false;
            EditButton.IsEnabled = false;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            //User selectedUser = (User)UserListView.SelectedItem;
            //NameTextBox.Text = selectedUser.Name;
            //SurnameTextxBox.Text = selectedUser.Surname;
            //LoginTextBox.Text = selectedUser.Login;
            //PasswordTextBox.Text = selectedUser.Password;
            //RoleComboBox.SelectedItem = selectedUser.Role;
            //RequestButton.Visibility = Visibility.Collapsed;
            //UpdateButton.Visibility = Visibility.Visible;
            //RequestGrid.Visibility = Visibility.Visible;
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            //User selectedUser = (User)UserListView.SelectedItem;
            //selectedUser.Name = NameTextBox.Text;
            //selectedUser.Surname = SurnameTextxBox.Text;
            //selectedUser.Password = PasswordTextBox.Text;
            //selectedUser.Login = LoginTextBox.Text;
            //selectedUser.Role = (Position)RoleComboBox.SelectedItem;

            //int index = UserListView.SelectedIndex;

            //userService.Update(index, selectedUser);

            //CloseAddUserWindow();
        }

        private void HelpButtonClick(object sender, System.Windows.Input.MouseButtonEventArgs e) => HelpGrid.Visibility = Visibility.Visible;

        private void CloseHelpGrid(object sender, RoutedEventArgs e) => HelpGrid.Visibility = Visibility.Collapsed;
    }
}
