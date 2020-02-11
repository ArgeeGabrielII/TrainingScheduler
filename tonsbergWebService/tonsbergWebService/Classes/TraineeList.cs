using System.Runtime.Serialization;

namespace tonsbergWebService.Classes
{
    [DataContract]
    public class TraineeList
    {
        [DataMember]
        public string TraineeID { get; set; }

        [DataMember]
        public string TraineeName { get; set; }
    }
}