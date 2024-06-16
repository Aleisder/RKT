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

            string query = "SELECT [Администраторы].[ID_Кадровика],\r\n       [Логин],\r\n\t   [Пароль],\r\n\t   [Администраторы].[ID_Сотрудника],\r\n\t   [Фамилия],\r\n\t   [Имя],\r\n\t   [Отчество],\r\n\t   [Адрес_регистрации].[ID_Адреса_регистрации],\r\n\t   [Адрес_регистрации].[Регион],\r\n\t   [Регион].[Название],\r\n\t   [Адрес_регистрации].[Пункт],\r\n\t   [Адрес_регистрации].[Улица],\r\n\t   [Адрес_регистрации].[Дом],\r\n\t   [Адрес_регистрации].[Корпус],\r\n\t   [Адрес_регистрации].[Строение],\r\n\t   [Адрес_регистрации].[Квартира],\r\n\t   [Сотрудники].[Адрес_проживания],\r\n\t   [Адрес_проживания].[Регион],\r\n\t   [Регион].[Название],\r\n\t   [Адрес_проживания].[Пункт],\r\n\t   [Адрес_регистрации].[Улица],\r\n\t   [Адрес_регистрации].[Дом],\r\n\t   [Адрес_регистрации].[Корпус],\r\n\t   [Адрес_регистрации].[Строение],\r\n\t   [Адрес_регистрации].[Квартира],\r\n\t   [Должность],\r\n\t   [Должности].[Название_должности],\r\n\t   [СНИЛС],\r\n\t   [Сотрудники].[ИНН],\r\n\t   [Дата_рождения],\r\n\t   [Номер_телефона],\r\n\t   [Сотрудники].[Гражданство],\r\n\t   [Гражданство].[Гражданство] AS [Название_гражданства],\r\n\t   [Сотрудники].[Иностранный_язык],\r\n\t   [Иностранный_язык].[Наименование_языка],\r\n\t   [Иностранный_язык].[Уровень_знания],\r\n\t   [Сотрудники].[Образование],\r\n\t   [Образование].[Степень_образования],\r\n       [Образование].[Наименование_учебного_заведения],\r\n       [Образование].[Серия_диплома],\r\n       [Образование].[Номер_диплома],\r\n       [Образование].[Квалификация],\r\n       [Образование].[Направление],\r\n\t   [Семейное_положение],\r\n\t   [Электронная_почта],\r\n\t   [Сотрудники].[Паспорт],\r\n\t   [Паспорт].[Серия_паспорта],\r\n       [Паспорт].[Номер_паспорта],\r\n       [Паспорт].[Кем_выдан],\r\n       [Паспорт].[Дата_выдачи],\r\n       [Паспорт].[Код_подразделения],\r\n       [Паспорт].[Пол],\r\n\t   [Серия_ТК],\r\n\t   [Номер_ТК],\r\n\t   [Сотрудники].[Воинский_учет],\r\n\t   [Воинский_учет].[Номер_военного_билета],\r\n       [Воинский_учет].[Категория_запаса],\r\n       [Воинский_учет].[Воинское_звание],\r\n       [Воинский_учет].[Состав],\r\n       [Воинский_учет].[ВУС],\r\n       [Воинский_учет].[Категория_годности],\r\n       [Воинский_учет].[Наименование_ВК],\r\n       [Воинский_учет].[Состояние_на_ВУ],\r\n       [Воинский_учет].[Отментка_о_снятии],\r\n\t   [Номер_мед_книжки],\r\n\t   [Сотрудники].[Расчетный_счет],\r\n\t   [Расчетный_счет].[Лицевой_счет],\r\n       [Расчетный_счет].[Расчетный_счет],\r\n       [Расчетный_счет].[Наименование_банка],\r\n       [Расчетный_счет].[БИК],\r\n\t   [Расчетный_счет].[ИНН],\r\n       [Расчетный_счет].[КПП],\r\n       [Расчетный_счет].[Номер_БК]\r\n  FROM [Администраторы]\r\n  JOIN [Сотрудники] ON [Администраторы].[ID_Сотрудника] = [Сотрудники].[ID_Сотрудника]\r\n  JOIN [Адрес_регистрации] ON [Сотрудники].[Адрес_регистрации] = [Адрес_регистрации].[ID_Адреса_регистрации]\r\n  JOIN [Адрес_проживания] ON [Адрес_проживания].[ID_Адреса] = [Сотрудники].[Адрес_проживания]\r\n  JOIN [Регион] ON [Адрес_регистрации].[ID_Адреса_регистрации] = [Регион].ID_Региона\r\n  JOIN [Должности] ON [Должности].[ID_Должности] = [Сотрудники].[Должность]\r\n  JOIN [Гражданство] ON [Гражданство].[ID_гражданства] = [Сотрудники].[Гражданство]\r\n  JOIN [Иностранный_язык] ON [Иностранный_язык].[ID_языка] = [Сотрудники].[Иностранный_язык]\r\n  JOIN [Образование] ON [Образование].[ID_образования] = [Сотрудники].[Образование]\r\n  JOIN [Паспорт] ON [Паспорт].[ID_Паспорта] = [Сотрудники].[Паспорт]\r\n  JOIN [Воинский_учет] ON [Воинский_учет].[ID_Военного_билета] = [Сотрудники].[Воинский_учет]\r\n  JOIN [Расчетный_счет] ON [Расчетный_счет].[ID_Расчетного_счета] = [Сотрудники].[Расчетный_счет];";

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
                string station = reader.GetString(10);
                string street = reader.GetString(11);
                string house = reader.GetString(12);
                string building = reader.GetString(13);
                int structure = reader.GetInt32(14);
                int apartment = reader.GetInt32(15);

                var registration = new Registration(registrationId, region, station, street, house, building, structure, apartment);

                int addressId = reader.GetInt32(16);
                int addressRegionId = reader.GetInt32(17);
                string addressRegionName = reader.GetString(18);

                region = new Region(addressRegionId, addressRegionName);
                station = reader.GetString(19);
                street = reader.GetString(20);
                house = reader.GetString(21);
                building = reader.GetString(22);
                structure = reader.GetInt32(23);
                apartment = reader.GetInt32(24);

                var address = new Address(addressId, region, station, street, house, building, structure, apartment);

                int positionId = reader.GetInt32(25);
                string positionName = reader.GetString(26);

                var position = new Position(positionId, positionName);

                string snils = reader.GetString(27);
                string inn = reader.GetString(28);
                DateOnly dateOfBirth = DateOnly.FromDateTime(reader.GetDateTime(29));
                string phone = reader.GetString(30);

                int citizenshipId = reader.GetInt32(31);
                string citizenshipName = reader.GetString(32);

                var citizenship = new Citizenship(citizenshipId, citizenshipName);

                int languageId = reader.GetInt32(33);
                string languageName = reader.GetString(34);
                string languageLevel = reader.GetString(35);

                var foreignLanguage = new ForeignLanguage(languageId, languageName, languageName);

                int educationId = reader.GetInt32(36);
                string degree = reader.GetString(37);
                string institution = reader.GetString(38);
                string diplomaSeries = reader.GetString(39);
                string diplomaNumber = reader.GetString(40);
                string qualification = reader.GetString(41);
                string direction = reader.GetString(42);

                var education = new Education(educationId, degree, institution, diplomaSeries, diplomaNumber, qualification, direction);

                string familyStatus = reader.GetString(43);
                string email = reader.GetString(44);

                int passportId = reader.GetInt32(45);
                int passportSeries = reader.GetInt32(46);
                int passportNumber = reader.GetInt32(47);
                string passportIssuedBy = reader.GetString(48);
                DateOnly passportIssuedDate = DateOnly.FromDateTime(reader.GetDateTime(49));
                string passportCode = reader.GetString(50);
                bool passportGender = reader.GetBoolean(51);

                var passport = new Passport(passportId, passportSeries, passportNumber, passportIssuedBy, passportIssuedDate, passportCode, passportGender);

                string employmentHistorySeries = reader.GetString(52);
                string employmentHistoryNumber = reader.GetString(53);

                int militaryId = reader.GetInt32(54);
                string militaryNumber = reader.GetString(55);
                int militaryReserveCategory = reader.GetInt32(56);
                string militaryRank = reader.GetString(57);
                string team = reader.GetString(58);
                string militarySpecialization = reader.GetString(59);
                string suitability = reader.GetString(60);
                string commissariat = reader.GetString(61);
                string militaryState = reader.GetString(62);
                string fired = reader.GetString(63);

                var militaryRegistration = new MilitaryRegistration(militaryId, militaryNumber, militaryReserveCategory, militaryRank, team, militarySpecialization, suitability, commissariat, militaryState, fired);

                string medicalCardNumber = reader.GetString(64);

                int paymentId = reader.GetInt32(65);
                string paymentPersonalAccount = reader.GetString(66);
                string paymentPayment = reader.GetString(67);
                string paymentBank = reader.GetString(68);
                int paymentBik = reader.GetInt32(69);
                int paymentInn = reader.GetInt32(70);
                int paymentKpp = reader.GetInt32(71);
                string paymentCardNumber = reader.GetString(72);

                var payment = new Payment(paymentId, paymentPersonalAccount, paymentPayment, paymentBank, paymentBik, paymentInn, paymentKpp, paymentCardNumber);

                var employee = new Employee(employeeId, lastName, firstName, middleName, registration, address, position, snils, inn, dateOfBirth, phone, citizenship, foreignLanguage, education, familyStatus, email, passport, employmentHistorySeries, employmentHistoryNumber, militaryRegistration, medicalCardNumber, payment);
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
