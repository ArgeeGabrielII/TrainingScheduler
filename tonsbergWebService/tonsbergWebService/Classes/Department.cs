using System.Runtime.Serialization;

namespace tonsbergWebService.Classes
{
    [DataContract]
    public class Department
    {
        [DataMember]
        public int DepartmentID { get; set; }

        [DataMember]
        public string DepartmentCode { get; set; }

        [DataMember]
        public string DepartmentName { get; set; }

        [DataMember]
        public bool Active { get; set; } 
    }
}