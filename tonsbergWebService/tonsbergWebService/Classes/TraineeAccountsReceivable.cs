using System.Runtime.Serialization;

namespace tonsbergWebService.Classes
{
    [DataContract]
    public class TraineeAccountsReceivable
    {
        [DataMember]
        public int CourseID { get; set; }

        [DataMember]
        public string CourseCode { get; set; }

        [DataMember]
        public string CourseName { get; set; }

        [DataMember]
        public string TrainorName { get; set; }

        [DataMember]
        public string TrainingStartDate { get; set; }

        [DataMember]
        public int TrainingDuration { get; set; }

        [DataMember]
        public decimal TrainingFee { get; set; }

        [DataMember]
        public decimal TotalPayment { get; set; }

        [DataMember]
        public bool DropTrainee { get; set; } 
    }
}