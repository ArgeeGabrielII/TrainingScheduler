using System.Runtime.Serialization;

namespace tonsbergWebService.Classes
{
    [DataContract]
    public class AccountsReceivableHIstory
    {
        [DataMember]
        public int RegistrationID { get; set; }

        [DataMember]
        public string TraineeID { get; set; }

        [DataMember]
        public int CourseID { get; set; }

        [DataMember]
        public string CourseCode { get; set; }

        [DataMember]
        public string CourseName { get; set; }

        [DataMember]
        public string TransactionDate { get; set; }

        [DataMember]
        public decimal AmountPaid { get; set; }

        [DataMember]
        public string PaymentDetails { get; set; }
    }
}