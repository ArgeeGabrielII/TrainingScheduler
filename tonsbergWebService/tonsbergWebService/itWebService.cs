using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace tonsbergWebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface itWebService
    {
        #region Get Data

        #region Trainee Profile

        [OperationContract]
        string Get_TraineeProfile(string _Parameter, int _UserID, string _Token);

        [OperationContract]
        string Get_TraineeList(int _UserID, string _Token);

        [OperationContract]
        string Get_TraineeRecord(string TraineeID, int _UserID, string _Token);

        #endregion

        #region Training Registration

        [OperationContract]
        string Get_AvailableCourses(string _Parameter, int _UserID, string _Token);

        [OperationContract]
        string Get_EnrolledTrainee(string _Parameter, int _UserID, string _Token);

        #endregion

        #region Training Courses

        [OperationContract]
        string Get_TrainingCourses(string _Parameter, int _UserID, string _Token);

        #endregion

        #region Accounts Receivables

        [OperationContract]
        string Get_AccountsReceivableHistory(int _CourseID, string _TraineeID, int _UserID, string _Token);

        [OperationContract]
        string Get_TotalAmountPaid(int _CourseID, string _TraineeID, int _UserID, string _Token);

        [OperationContract]
        string Get_TraineeAccountsReceivable(string TraineeID, int _UserID, string _Token);
        
        #endregion

        #region Access Management

        [OperationContract]
        string GetUserPass(string Username, string Password);

        [OperationContract]
        string Get_UserAccessRights(int GroupID);

        #endregion

        #region Account Management

        [OperationContract]
        string Get_UserAccount(string _Parameter, int _UserID, string _Token);

        [OperationContract]
        string Get_UserGroups(string _Parameter, int _UserID, string _Token);

        [OperationContract]
        string Get_GroupRights(string _Parameter, int _UserID, string _Token);

        #endregion

        #region Data Management

        [OperationContract]
        string Get_Gender(string _Parameter, int _UserID, string _Token);

        [OperationContract]
        string Get_CivilStatus(string _Parameter, int _UserID, string _Token);

        [OperationContract]
        string Get_SystemModules(string _Parameter, int _UserID, string _Token);

        [OperationContract]
        string Get_Office(string _Parameter, int _UserID, string _Token);

        [OperationContract]
        string Get_Department(string _Parameter, int _UserID, string _Token);

        #endregion

        #region Reports
        
        [OperationContract]
        string Report_AccountsReceivable_All(string _DateFrom, string _DateTo, int _UserID, string _Token);

        [OperationContract]
        string Report_AccountsReceivable_Course(string _DateFrom, string _DateTo, int _CourseID, int _UserID, string _Token);

        [OperationContract]
        string Report_Sales_All(string _DateFrom, string _DateTo, int _UserID, string _Token);

        [OperationContract]
        string Report_Sales_Course(string _DateFrom, string _DateTo, int _CourseID, int _UserID, string _Token);

        [OperationContract]
        string Report_EnrolledTraineeCount_All(string _DateFrom, string _DateTo, int _UserID, string _Token);
        
        #endregion

        #endregion

        #region Save Data

        #region Trainee Profile

        [OperationContract]
        void Save_TraineeProfile(string TraineeID, string FirstName, string MiddleName, string LastName, int GenderID, int CivilStatusID, string ContactNo
            , string DateOfBirth, int Age, string PlaceOfBirth, bool Active, string PositionRank, int YearsOfSeaExperience, string MarinaLicense
            , string PRCLicense, string SIRBNo, string PassportNo, string SRCNo, string Others, string EnrollmentDate, int _UserID, string _Token);

        #endregion

        #region Training Registration

        [OperationContract]
        void Save_TraineeRegistration(int RegistrationID, string DateRegistered, string TraineeID, int CourseID, string CourseCode, bool DropTrainee
            , int _UserID, string _Token);

        [OperationContract]
        void Save_DropTrainee(string TraineeID, int CourseID, int RegistrationID, int _UserID, string _Token);

        #endregion

        #region Training Courses

        [OperationContract]
        void Save_TrainingCourses(int CourseID, string CourseCode, string CourseName, string TrainorName, int NoOfTrainees, int TrainingDuration
            , string TrainingStartDate, bool Active, decimal TrainingFee, string AssessorName, int _UserID, string _Token);
        
        #endregion

        #region Account Receivables

        [OperationContract]
        void Save_Payments(int RegistrationID, decimal AmountPaid, string PaymentDetails, int _UserID, string _Token);
        
        #endregion

        #region Account Management

        [OperationContract]
        void Save_UserAccounts(int UserID, string UserName, string Password, string FirstName, string LastName, int GroupID, string EmailAddress, string Office, int DepartmentID, bool Active, int _UserID, string _Token);

        [OperationContract]
        void Save_UserGroups(int ID, string GroupName, string Description, bool Active, int _UserID, string _Token);

        [OperationContract]
        void Save_GroupRights(int GroupRightID, int GroupID, int ModuleID, bool CanView, bool CanEdit, bool CanDelete, int _UserID, string _Token);

        [OperationContract]
        void Save_UserProfile(int UserID, string Password, int _UserID, string _Token);

        #endregion

        #region Data Management

        [OperationContract]
        void Save_Gender(int GenderID, string GenderName, int _UserID, string _Token);

        [OperationContract]
        void Save_CivilStatus(int CivilStatusID, string CivilStatusName, int _UserID, string _Token);

        //[OperationContract]
        //void Save_IdentificationList(int IdentificationListID, string IdentificationListName, int _UserID, string _Token);

        [OperationContract]
        void Save_SystemModules(int ModuleID, string ModuleName, string ModuleDescription, string ModuleURL, int _UserID, string _Token);

        [OperationContract]
        void Save_Office(int OfficeID, string OfficeCode, string OfficeName, string OfficeAddress, string ContactNo, bool Active, int _UserID, string _Token);

        [OperationContract]
        void Save_Department(int DepartmentID, string DepartmentCode, string DepartmentName, bool Active, int _UserID, string _Token);

        #endregion

        #endregion

        #region Logs Management

        [OperationContract]
        bool Validate_Token(int UserID, string TokenID);

        [OperationContract]
        string Get_TransactionHistory(string _Parameter, int _UserID, string _Token);

        [OperationContract]
        void Save_TransactionHistory(int UserID, string FormName, string EventName, string ExceptionError, string TransactionLogs, string ComputerName, string IPAddress);

        #endregion
    }
}
