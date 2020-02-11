using System.Runtime.Serialization;

namespace tonsbergWebService.Classes
{
    [DataContract]
    public class SalesReport
    {
        [DataMember]
        public string TraineeID { get; set; }

        [DataMember]
        public string TraineeName { get; set; }

        [DataMember]
        public string CourseCode { get; set; }

        [DataMember]
        public string CourseName { get; set; }

        [DataMember]
        public string TransactionDate { get; set; }

        [DataMember]
        public string AmountPaid { get; set; }
    }
}