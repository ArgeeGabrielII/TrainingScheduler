using System.Runtime.Serialization;

namespace tonsbergWebService.Classes
{
    [DataContract]
    public class UserGroup
    {
        [DataMember]
        public int GroupID { get; set; }

        [DataMember]
        public string GroupName { get; set; }

        [DataMember]
        public string GroupDescription { get; set; }

        [DataMember]
        public bool Active { get; set; } 
    }
}