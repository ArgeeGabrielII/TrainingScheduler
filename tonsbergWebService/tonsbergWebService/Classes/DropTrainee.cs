using System.Runtime.Serialization;

namespace tonsbergWebService.Classes
{
    [DataContract]
    public class DropTrainee
    {
        [DataMember]
        public string TraineeID { get; set; }

        [DataMember]
        public int CourseID { get; set; }
    }
}