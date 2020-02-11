using System.Runtime.Serialization;

namespace tonsbergWebService.Classes
{
    [DataContract]
    public class UserAccessRights
    {
        [DataMember]
        public int GroupRightID { get; set; }

        [DataMember]
        public int GroupID { get; set; }

        [DataMember]
        public int ModuleID { get; set; }

        [DataMember]
        public bool CanView { get; set; }

        [DataMember]
        public bool CanEdit { get; set; }

        [DataMember]
        public bool CanDelete { get; set; }

        [DataMember]
        public string ModuleName { get; set; }
    }
}