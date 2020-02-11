using System.Runtime.Serialization;

namespace tonsbergWebService.Classes
{
    [DataContract]
    public class Office
    {
        [DataMember]
        public int OfficeID { get; set; }

        [DataMember]
        public string OfficeCode { get; set; }

        [DataMember]
        public string OfficeName { get; set; }

        [DataMember]
        public string OfficeAddress { get; set; }

        [DataMember]
        public string ContactNo { get; set; }

        [DataMember]
        public bool Active { get; set; }
    }
}