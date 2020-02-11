using System.Runtime.Serialization;

namespace tonsbergWebService.Classes
{
    [DataContract]
    public class CivilStatus
    {
        [DataMember]
        public int CivilStatusID { get; set; }

        [DataMember]
        public string CivilStatusName { get; set; }
    }
}