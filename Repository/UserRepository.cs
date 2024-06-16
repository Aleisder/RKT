using DemoExam.Repository;
using MaiProject.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

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
            var query = "DELETE FROM [Администраторы] WHERE [ID_сотрудника] = @id";
            var idParam = new SqlParameter("@id", item.Id);
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            var command = new SqlCommand(query, connection);
            command.Parameters.Add(idParam);
            command.ExecuteNonQuery();
            connection.Close();
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
                int userId = reader.GetInt32(0);
                string login = reader.GetString(1);
                string password = reader.GetString(2);
                int employeeId = reader.GetInt32(3);

                string lastName = reader.GetString(4);
                string firstName = reader.GetString(5);
                string middleName = reader.GetString(6);

                int registrationId = reader.GetInt32(7);
                int registrationRegionId = reader.GetInt32(8);
                string registrationRegionName = reader.GetString(9);

                var region = new Region(registrationRegionId, registrationRegionName);
                string state = reader.GetString(10);
                string street = reader.GetString(11);
                string building = reader.GetString(12);
                string housing = reader.GetString(13);
                string apartment = reader.GetString(14);

                var registration = new Registration(registrationId, region, state, street, building, housing, apartment);

                int addressId = reader.GetInt32(15);
                int addressRegionId = reader.GetInt32(16);
                string addressRegionName = reader.GetString(17);

                region = new Region(addressRegionId, addressRegionName);
                state = reader.GetString(18);
                street = reader.GetString(19);
                building = reader.GetString(20);
                housing = reader.GetString(21);
                apartment = reader.GetString(22);

                var address = new Address(addressId, region, state, street, building, housing, apartment);

                int positionId = reader.GetInt32(23);
                string positionName = reader.GetString(24);

                var position = new Position(positionId, positionName);

                string snils = reader.GetString(25);
                string inn = reader.GetString(26);
                DateTime dateOfBirth = reader.GetDateTime(27);
                string phone = reader.GetString(28);

                int citizenshipId = reader.GetInt32(29);
                string citizenshipName = reader.GetString(30);

                var citizenship = new Citizenship(citizenshipId, citizenshipName);

                int languageId = reader.GetInt32(31);
                string languageName = reader.GetString(32);
                string languageLevel = reader.GetString(33);

                var foreignLanguage = new ForeignLanguage(languageId, languageName, languageName);

                int educationId = reader.GetInt32(34);
                string degree = reader.GetString(35);
                string institution = reader.GetString(35);
                string diplomaSeries = reader.GetString(36);
                string diplomaNumber = reader.GetString(37);
                string qualification = reader.GetString(38);
                string direction = reader.GetString(39);

                var education = new Education(educationId, degree, institution, diplomaSeries, diplomaNumber, qualification, direction);

                string familyStatus = reader.GetString(40);
                string email = reader.GetString(41);

                int passportId = reader.GetInt32(42);
                string passportSeries = reader.GetString(43);
                string passportNumber = reader.GetString(44);
                string passportIssuedBy = reader.GetString(45);
                DateOnly passportIssuedDate = reader.GetDateTime(46);
                string passportCode = reader.GetString(47);
                string passportGender = reader.GetString(48);

                string employmentHistorySeries = reader.GetString(49);
                string employmentHistoryNumber = reader.GetString(50);

                int militaryId = reader.GetInt32(51);
                string militaryNumber = reader.GetInt32(52);
                string militaryCategory = reader.GetString(53);
                string militaryRank = reader.GetString(54);

                var militaryRegistration = new MilitaryRegistration(militaryId, militaryNumber, militaryCategory, militaryCategory);

                string medicalCardNumber = reader.GetString(55);

                int paymentId = reader.GetInt32(56);
                string paymentPersonalAccount = reader.GetString(57);
                string paymentPayment = reader.GetString(58);
                string paymentBank = reader.GetString(59);
                string paymentBik = reader.GetString(60);
                string paymentInn = reader.GetString(61);
                string paymentKpp = reader.GetString(62);
                string paymentCardNumber = reader.GetString(63);

                var payment = new PaymentAccount(paymentId, paymentPersonalAccount, paymentPayment, paymentBank, paymentBik, paymentInn, paymentKpp, paymentCardNumber);

                var passport = new Passport(passportId, passportSeries, passportNumber, passportIssuedBy, passportIssuedDate, passportCode, passportGender);

                var employee = new Employee(employeeId, lastName, firstName, middleName, registration, null, position, snils, inn, dateOfBirth, phone, citizenship, foreignLanguage, education, familyStatus, email, passport, employmentHistorySeries, employmentHistoryNumber, militaryRegistration, medicalCardNumber, paymentAccount);
                var user = new User(userId, login, password, employee);
                users.Add(user);

            }
            reader.Close();
            connection.Close();

            return users;
        }

        public override User GetById(int id) => 
            GetAll()
            .Where(user => user.Id == id)
            .First();

        public override int Update(User item)
        {
            throw new NotImplementedException();
        }

        public User Validate(string login, string password) =>
            GetAll()
            .Where(user => user.Login == login && user.Password == password)
            .First();
    }
}
