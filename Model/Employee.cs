using System;

namespace MaiProject.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public string LastName { get; set; }                           // Фамилия
        public string FirstName { get; set; }                          // Имя
        public string MiddleName { get; set; }                         // Отчество
        public Registration Registration { get; set; }          // Адрес регистрации
        public Address Address { get; set; }                  // Адрес прописки
        public Position Position { get; set; }                         // Должность
        public string Snils { get; set; }                              // Снилс
        public string INN { get; set; }                                // ИНН
        public DateOnly DateOfBirth { get; set; }                      // Дата рождения
        public string Phone { get; set; }                              // Номер телефона
        public Citizenship Citizenship { get; set; }                   // Гражданство
        public ForeignLanguage ForeignLanguage { get; set; }           // Иностранный язык
        public Education Education { get; set; }                       // Образование
        public string FamilyStatus { get; set; }                       // Семейное положение
        public string Email { get; set; }                              // Электронная почта
        public Passport Passport { get; set; }                         // Паспорт
        public string EmploymentHistorySeries { get; set; }            // Серия ТК
        public string EmploymentHistoryNumber { get; set; }            // Номер ТК
        public MilitaryRegistration MilitaryRegistration { get; set; } // Воинский учет
        public string MedicalCardNumber { get; set; }                  // Номер мед книжки
        public Payment PaymentAccount { get; set; }             // Расчетный счет

        public Employee(int id, string lastName, string firstName, string middleName, Registration registration, Address address, Position position, string snils, string iNN, DateOnly dateOfBirth, string phone, Citizenship citizenship, ForeignLanguage foreignLanguage, Education education, string familyStatus, string email, Passport passport, string employmentHistorySeries, string employmentHistoryNumber, MilitaryRegistration militaryRegistration, string medicalCardNumber, Payment paymentAccount)
        {
            Id = id;
            LastName = lastName;
            FirstName = firstName;
            MiddleName = middleName;
            Registration = registration;
            Address = address;
            Position = position;
            Snils = snils;
            INN = iNN;
            DateOfBirth = dateOfBirth;
            Phone = phone;
            Citizenship = citizenship;
            ForeignLanguage = foreignLanguage;
            Education = education;
            FamilyStatus = familyStatus;
            Email = email;
            Passport = passport;
            EmploymentHistorySeries = employmentHistorySeries;
            EmploymentHistoryNumber = employmentHistoryNumber;
            MilitaryRegistration = militaryRegistration;
            MedicalCardNumber = medicalCardNumber;
            PaymentAccount = paymentAccount;
        }
    }
}
