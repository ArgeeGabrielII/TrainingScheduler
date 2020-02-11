using System.Runtime.Serialization;

namespace tonsbergWebService.Classes
{
    [DataContract]
    public class TrainingCourses
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
        public int NoOfTrainees { get; set; }

        [DataMember]
        public int EnrolledTrainees { get; set; }

        [DataMember]
        public string AvailableSlot { get; set; }

        [DataMember]
        public int TrainingDuration { get; set; }

        [DataMember]
        public string TrainingStartDate { get; set; }

        [DataMember]
        public bool Active { get; set; }

        [DataMember]
        public decimal TrainingFee { get; set; }

        [DataMember]
        public string AssessorName { get; set; }
    }
}