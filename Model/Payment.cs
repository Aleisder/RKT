namespace MaiProject.Model
{
    public class Payment
    {
        public int Id { get; set; }
        public string PersonalAccount { get; set; }
        public string PaymentAccount{ get; set; }
        public string Bank { get; set; }
        public int BIK { get; set; }
        public int INN { get; set; }
        public int KPP { get; set; }
        public string CardNumber { get; set; }

        public Payment(int id, string personalAccount, string payment, string bank, int bik, int inn, int kpp, string cardNumber)
        {
            Id = id;
            PersonalAccount = personalAccount;
            PaymentAccount = payment;
            Bank = bank;
            BIK = bik;
            INN = inn;
            KPP = kpp;
            CardNumber = cardNumber;
        }
    }
}
