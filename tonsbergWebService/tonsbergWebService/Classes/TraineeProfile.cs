using System.Runtime.Serialization;

namespace tonsbergWebService.Classes
{
    [DataContract]
    public class TraineeProfile
    {
        [DataMember]
        public int RegistrationID { get; set; }

        [DataMember]
        public string TraineeID { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string MiddleName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public int GenderID { get; set; }

        [DataMember]
        public int CivilStatusID { get; set; }

        [DataMember]
        public string ContactNo { get; set; }

        [DataMember]
        public string DateOfBirth { get; set; }

        [DataMember]
        public int Age { get; set; }

        [DataMember]
        public string PlaceOfBirth { get; set; }

        [DataMember]
        public bool Active { get; set; }

        [DataMember]
        public string PositionRank { get; set; }

        [DataMember]
        public int YearsOfSeaExperience { get; set; }

        [DataMember]
        public string MarinaLicense { get; set; }

        [DataMember]
        public string PRCLicense { get; set; }

        [DataMember]
        public string SIRBNo { get; set; }

        [DataMember]
        public string PassportNo { get; set; }

        [DataMember]
        public string SRCNo { get; set; }

        [DataMember]
        public string Others { get; set; }

        [DataMember]
        public string TotalPayment { get; set; }

        [DataMember]
        public string EnrollmentDate { get; set; }
    }
}