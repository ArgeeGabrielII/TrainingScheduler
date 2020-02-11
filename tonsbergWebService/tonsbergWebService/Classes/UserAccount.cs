using System.Runtime.Serialization;

namespace tonsbergWebService.Classes
{
    [DataContract]
    public class UserAccount
    {
        [DataMember]
        public int UserID { get; set; }

        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string EmailAddress { get; set; }

        [DataMember]
        public int GroupID { get; set; }

        [DataMember]
        public string GroupName { get; set; }

        [DataMember]
        public string Office { get; set; }

        [DataMember]
        public bool Active { get; set; }

        [DataMember]
        public int DepartmentID { get; set; }

        [DataMember]
        public string DepartmentName { get; set; }

        [DataMember]
        public string Token { get; set; } 
    }
}