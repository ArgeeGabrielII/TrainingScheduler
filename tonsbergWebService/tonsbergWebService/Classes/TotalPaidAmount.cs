using System.Runtime.Serialization;

namespace tonsbergWebService.Classes
{
    [DataContract]
    public class TotalPaidAmount
    {
        [DataMember]
        public int RegistrationID { get; set; }

        [DataMember]
        public string TraineeID { get; set; }

        [DataMember]
        public int CourseID { get; set; }

        [DataMember]
        public decimal TotalAmountPaid { get; set; }
    }
}