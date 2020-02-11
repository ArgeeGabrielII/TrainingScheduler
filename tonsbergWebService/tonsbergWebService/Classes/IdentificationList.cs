using System.Runtime.Serialization;

namespace tonsbergWebService.Classes
{
    [DataContract]
    public class IdentificationList
    {
        [DataMember]
        public int IdentificationListID { get; set; }

        [DataMember]
        public string IdentificationListName { get; set; }
    }
}