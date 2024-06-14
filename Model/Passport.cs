using System;

namespace MaiProject.Model
{
    public class Passport
    {
        public int Id { get; set; }
        public string Series { get; set; }
        public string Number { get; set; }
        public string IssuedBy { get; set; }
        public DateOnly IssuedDate { get; set; }
        public string Code { get; set; }
        public string Gender { get; set; }

        public Passport(int id, string series, string number, string issuedBy, DateOnly issuedDate, string code, string gender)
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
