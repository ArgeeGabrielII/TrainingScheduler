using System.Runtime.Serialization;

namespace tonsbergWebService.Classes
{
    [DataContract]
    public class TrainingRegistration
    {
        [DataMember]
        public int RegistrationID { get; set; }

        [DataMember]
        public int RegistrationCode { get; set; }

        [DataMember]
        public string DateRegistered { get; set; }

        [DataMember]
        public string TraineeID { get; set; }

        [DataMember]
        public int CourseID { get; set; }

        [DataMember]
        public int CourseCode { get; set; }

        [DataMember]
        public bool DropTrainee { get; set; } 
    }
}