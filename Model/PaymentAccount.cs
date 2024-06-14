namespace MaiProject.Model
{
    public class PaymentAccount
    {
        public int Id { get; set; }
        public string PersonalAccount { get; set; }
        public string Payment { get; set; }
        public string Bank { get; set; }
        public string BIK { get; set; }
        public string INN { get; set; }
        public string KPP { get; set; }
        public string CardNumber { get; set; }

        public PaymentAccount(int id, string personalAccount, string payment, string bank, string bIK, string iNN, string kPP, string cardNumber)
        {
            Id = id;
            PersonalAccount = personalAccount;
            Payment = payment;
            Bank = bank;
            BIK = bIK;
            INN = iNN;
            KPP = kPP;
            CardNumber = cardNumber;
        }
    }
}
