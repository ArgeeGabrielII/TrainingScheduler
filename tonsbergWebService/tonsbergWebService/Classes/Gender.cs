using System.Runtime.Serialization;

namespace tonsbergWebService.Classes
{
    [DataContract]
    public class Gender
    {
        [DataMember]
        public int GenderID { get; set; }

        [DataMember]
        public string GenderName { get; set; }
    }
}