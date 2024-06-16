using System;

namespace MaiProject.Model
{
    public class Passport
    {
        public int Id { get; set; }
        public int Series { get; set; }
        public int Number { get; set; }
        public string IssuedBy { get; set; }
        public DateOnly IssuedDate { get; set; }
        public string Code { get; set; }
        public bool Gender { get; set; }

        public Passport(int id, int series, int number, string issuedBy, DateOnly issuedDate, string code, bool gender)
        {
            Id = id;
            Series = series;
            Number = number;
            IssuedBy = issuedBy;
            IssuedDate = issuedDate;
            Code = code;
            Gender = gender;
        }
    }
}
