using DemoExam.Repository;
using MaiProject.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MaiProject.Repository
{
    public class UserRepository : Repository<User>
    {
        private readonly RegistrationAddressRepository registrationAddressRepository = new();
        private readonly PermanentAddressRepository permanentAddressRepository = new();
        private readonly PositionRepository positionRepository = new();
        private readonly CitizenshipRepository citizenshipRepository = new();
        private readonly ForeignLanguageRepository foreignLanguageRepository = new();
        private readonly EducationRepository educationRepository = new();
        private readonly PassportRepository passportRepository = new();
        private readonly MilitaryRegistrationRepository militaryRegistrationRepository = new();
        private readonly PaymantAccountRepository paymantAccountRepository = new();

        public override int Add(User item)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            int regisrationId = registrationAddressRepository.Add(item.Employee.Registration);
            int addressId = permanentAddressRepository.Add(item.Employee.Address);
            int educationId = educationRepository.Add(item.Employee.Education);
            int passportId = passportRepository.Add(item.Employee.Passport);
            int militaryRegistrationId = militaryRegistrationRepository.Add(item.Employee.MilitaryRegistration);
            int paymentAccountId = paymantAccountRepository.Add(item.Employee.PaymentAccount);

            string query = "INSERT INTO [Сотрудники] ([Фамилия], [Имя], [Отчество], [Адрес_регистрации], [Адрес_проживания], [Должность], [СНИЛС], [ИНН], [Дата_рождения], [Граждантство], [Иностранный_язык], [Образование], [Семейное_положение], [Электронная_почта], [Паспорт], [Серия_ТК], [Номер_ТК], [Воинский_учет], [Номер_мед_книжки], [Расчетный счет]) VALUES (@lastName, @firstName, @middleName, @registrationId, @addressId, @positionId, @snils, @inn, @dateOfBirth, @citizenshipId, @foreignLanguageId, @educationId, @familyStatus, @email, @passportId, @employmentHistorySeries, @employmentHistoryNumber, @militaryRegistrationId, @medicalCardNumber, @paymentAccountId)";

            var lastNameParam = new SqlParameter("@lastName", item.Employee.LastName);
            var firstNameParam = new SqlParameter("@firstName", item.Employee.FirstName);
            var middleNameParam = new SqlParameter("@middleName", item.Employee.MiddleName);
            var registrationIdParam = new SqlParameter("@registrationId", regisrationId);
            var addressIdParam = new SqlParameter("@addressId", addressId);
            var positionIdParam = new SqlParameter("@positionId", item.Employee.Position.Id);
            var snilsParam = new SqlParameter("@snils", item.Employee.Snils);
            var innParam = new SqlParameter("@inn", item.Employee.INN);
            var dateOfBirthParam = new SqlParameter("@dateOfBirth", item.Employee.DateOfBirth);
            var citizenshipIdParam = new SqlParameter("@citizenshipId", item.Employee.Citizenship.Id);
            var foreignLanguageIdParam = new SqlParameter("@foreignLanguageId", item.Employee.ForeignLanguage.Id);
            var educationIdParam = new SqlParameter("@educationId", educationId);
            var familyStatusParam = new SqlParameter("@familyStatus", item.Employee.FamilyStatus);
            var emailParam = new SqlParameter("@email", item.Employee.Email);
            var passportIdParam = new SqlParameter("@passportId", passportId);
            var employmentHistorySeriesParam = new SqlParameter("@employmentHistorySeries", item.Employee.EmploymentHistorySeries);
            var employmentHistoryNumberParam = new SqlParameter("@employmentHistoryNumber", item.Employee.EmploymentHistoryNumber);
            var militaryRegistrationIdParam = new SqlParameter("@militaryRegistrationId", militaryRegistrationId);
            var medicalCardNumberParam = new SqlParameter("@medicalCardNumber", item.Employee.MedicalCardNumber);
            var paymentAccountParam = new SqlParameter("@paymentAccountId", paymentAccountId);

            SqlParameter[] parameters = { lastNameParam, firstNameParam, middleNameParam, registrationIdParam, addressIdParam, snilsParam, innParam, dateOfBirthParam, citizenshipIdParam, foreignLanguageIdParam, educationIdParam, familyStatusParam, passportIdParam, employmentHistorySeriesParam, employmentHistoryNumberParam, militaryRegistrationIdParam, medicalCardNumberParam, paymentAccountParam };

            var command = new SqlCommand(query, connection);
            command.Parameters.AddRange(parameters);

            using var reader = command.ExecuteReader();

            reader.Read();
            int id = reader.GetInt16(0);

            reader.Close();
            connection.Close();

            return id;
        }

        public override void Delete(User item)
        {
            throw new NotImplementedException();
        }

        public override List<User> GetAll()
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            string query = "SELECT * FROM [Администраторы]";

            var command = new SqlCommand(query, connection);
            using var reader = command.ExecuteReader();
            List<User> users = new();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string login = reader.GetString(1);
                string password = reader.GetString(2);
                int employeeId = reader.GetInt32(3);

                string employeeQuery = "SELECT * FROM [Сотрудники] WHERE [ID_сотрудника] = @employeeId";

                var employeeCommand = new SqlCommand(employeeQuery, connection);
                using var employeeReader = employeeCommand.ExecuteReader();
                employeeReader.Read();

                string lastName = employeeReader.GetString(1);
                string firstName = employeeReader.GetString(2);
                string middleName = employeeReader.GetString(3);

                int registrationId = employeeReader.GetInt32(4);
                RegistrationAddress registration = registrationAddressRepository.GetById(registrationId);

                int addressId = employeeReader.GetInt32(5);
                PermanentAddress address = permanentAddressRepository.GetById(addressId);

                int positionId = employeeReader.GetInt32(6);
                Position position = positionRepository.GetById(positionId);

                string snils = employeeReader.GetString(7);
                string INN = employeeReader.GetString(8);
                DateTime dateOfBirth = employeeReader.GetDateTime(9);
                string phone = employeeReader.GetString(10);

                int citizenshipId = employeeReader.GetInt32(11);
                Citizenship citizenship = citizenshipRepository.GetById(citizenshipId);

                int foreignLanguageId = employeeReader.GetInt32(12);
                ForeignLanguage foreignLanguage = foreignLanguageRepository.GetById(foreignLanguageId);

                var employee = new Employee(employeeId, lastName, firstName, middleName, registration, address, position, snils, INN, dateOfBirth, phone, citizenship, foreignLanguage);

                var user = new User(id, login, password, employee);
                users.Add(user);
            }
            return users;
        }

        public override User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override int Update(User item)
        {
            throw new NotImplementedException();
        }

        public User Validate(string login, string password)
        {
            return new User();
        }
    }
}
