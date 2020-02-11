using System.Runtime.Serialization;

namespace tonsbergWebService.Classes
{
    [DataContract]
    public class EnrolledTraineReport
    {
        [DataMember]
        public string TraineeID { get; set; }

        [DataMember]
        public string TraineeName { get; set; }

        [DataMember]
        public string ContactNo { get; set; }

        [DataMember]
        public string DateOfBirth { get; set; }

        [DataMember]
        public string PlaceOfBirth { get; set; }

        [DataMember]
        public string PositionRank { get; set; }

        [DataMember]
        public string EnrollmentDate { get; set; }
    }
}