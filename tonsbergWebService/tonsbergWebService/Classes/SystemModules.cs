using System.Runtime.Serialization;

namespace tonsbergWebService.Classes
{
    [DataContract]
    public class SystemModules
    {
        [DataMember]
        public int ModuleID { get; set; }

        [DataMember]
        public string ModuleName { get; set; }

        [DataMember]
        public string ModuleDescription { get; set; }

        [DataMember]
        public string ModuleURL { get; set; } 
    }
}