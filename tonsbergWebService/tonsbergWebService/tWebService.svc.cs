using System;
using System.Collections.Generic;
using System.Data;
using System.ServiceModel;
using System.Web.Script.Serialization;
using System.Web.Services;
using Newtonsoft.Json;
using tonsberg_DataAccess;
using tonsbergWebService.Classes;

namespace tonsbergWebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class tWebService : itWebService
    {
        #region Declaration(s)

        public DataAccess mclsda = new DataAccess();
        string _jsonResponse = string.Empty;
        JavaScriptSerializer jsonSerialiser = new JavaScriptSerializer();
        Global _g = new Global();

        #endregion 

        #region Get Data

        #region Trainee Profile

        [WebMethod]
        public string Get_TraineeProfile(string _Parameter, int _UserID, string _Token)
        {
            List<TraineeProfile> uTraineeProfile = new List<TraineeProfile>();

            try
            {
                mclsda.dbConnect();
                mclsda.ClearParameter();
                mclsda.AddParameter("Parameter", _Parameter);

                using (DataTableReader dtr = mclsda.ExecuteReader("[TRNG].[Get_TraineeProfile]", CommandType.StoredProcedure))
                {
                    if (dtr.HasRows)
                    {
                        while (dtr.Read())
                        {
                            string _DateOfBirth = _g._SetDate(dtr["DateOfBirth"].ToString());
                            string _EnrollmentDate = _g._SetDate(dtr["EnrollmentDate"].ToString());

                            uTraineeProfile.Add(new TraineeProfile
                            {
                                TraineeID = dtr["TraineeID"].ToString(),
                                FirstName = dtr["FirstName"].ToString(),
                                MiddleName = dtr["MiddleName"].ToString(),
                                LastName = dtr["LastName"].ToString(),
                                GenderID = _g.ToInt32(dtr["GenderID"].ToString()),
                                CivilStatusID = _g.ToInt32(dtr["CivilStatusID"].ToString()),
                                ContactNo = dtr["ContactNo"].ToString(),
                                DateOfBirth = _DateOfBirth,
                                Age = _g.ToInt32(dtr["Age"].ToString()),
                                PlaceOfBirth = dtr["PlaceOfBirth"].ToString(),
                                Active = _g.ToBoolean(dtr["Active"].ToString()),
                                PositionRank = dtr["PositionRank"].ToString(),
                                YearsOfSeaExperience = _g.ToInt32(dtr["YearsOfSeaExperience"].ToString()),
                                MarinaLicense = dtr["MarinaLicense"].ToString(),
                                PRCLicense = dtr["PRCLicense"].ToString(),
                                SIRBNo = dtr["SIRBNo"].ToString(),
                                PassportNo = dtr["PassportNo"].ToString(),
                                SRCNo = dtr["SRCNo"].ToString(),
                                Others = dtr["Others"].ToString(),
                                EnrollmentDate = _EnrollmentDate
                            });
                        }
                    }
                }

                _jsonResponse = jsonSerialiser.Serialize(uTraineeProfile);
            }
            catch (Exception) { _jsonResponse = ""; }
            finally { mclsda.dbClose(); }

            return _jsonResponse;
        }

        [WebMethod]
        public string Get_TraineeList(int _UserID, string _Token)
        {
            List<TraineeList> uTraineeList = new List<TraineeList>();

            try
            {
                mclsda.dbConnect();
                mclsda.ClearParameter();

                using (DataTableReader dtr = mclsda.ExecuteReader("[TRNG].[Get_TraineeList]", CommandType.StoredProcedure))
                {
                    if (dtr.HasRows)
                    {
                        while (dtr.Read())
                        {
                            uTraineeList.Add(new TraineeList
                            {
                                TraineeID = dtr["TraineeID"].ToString(),
                                TraineeName = dtr["TraineeName"].ToString()
                            });
                        }
                    }
                }

                _jsonResponse = jsonSerialiser.Serialize(uTraineeList);
            }
            catch (Exception) { _jsonResponse = ""; }
            finally { mclsda.dbClose(); }

            return _jsonResponse;
        }

        [WebMethod]
        public string Get_TraineeRecord(string TraineeID, int _UserID, string _Token)
        {
            List<TrainingCourses> uTrainingCourses = new List<TrainingCourses>();

            try
            {
                mclsda.dbConnect();
                mclsda.ClearParameter();
                mclsda.AddParameter("TraineeID", TraineeID);

                using (DataTableReader dtr = mclsda.ExecuteReader("[TRNG].[Get_TraineeRecord]", CommandType.StoredProcedure))
                {
                    if (dtr.HasRows)
                    {
                        while (dtr.Read())
                        {
                            string _TrainingStartDate = _g._SetDate(dtr["TrainingStartDate"].ToString());

                            uTrainingCourses.Add(new TrainingCourses
                            {
                                CourseID = _g.ToInt32(dtr["CourseID"].ToString()),
                                CourseCode = dtr["CourseCode"].ToString(),
                                CourseName = dtr["CourseName"].ToString(),
                                TrainorName = dtr["TrainorName"].ToString(),
                                TrainingStartDate = _TrainingStartDate,
                                TrainingDuration = _g.ToInt32(dtr["TrainingDuration"].ToString())
                            });
                        }
                    }
                }

                _jsonResponse = jsonSerialiser.Serialize(uTrainingCourses);
            }
            catch (Exception) { _jsonResponse = ""; }
            finally { mclsda.dbClose(); }

            return _jsonResponse;
        }

        #endregion

        #region Training Registration

        [WebMethod]
        public string Get_AvailableCourses(string _Parameter, int _UserID, string _Token)
        {
            List<TrainingCourses> uTrainingCourses = new List<TrainingCourses>();

            try
            {
                mclsda.dbConnect();
                mclsda.ClearParameter();
                mclsda.AddParameter("Parameter", _Parameter);

                using (DataTableReader dtr = mclsda.ExecuteReader("[TRNG].[Get_AvailableCourses]", CommandType.StoredProcedure))
                {
                    if (dtr.HasRows)
                    {
                        while (dtr.Read())
                        {
                            string _TrainingStartDate = _g._SetDate(dtr["TrainingStartDate"].ToString());

                            uTrainingCourses.Add(new TrainingCourses
                            {
                                CourseID = _g.ToInt32(dtr["CourseID"].ToString()),
                                CourseCode = dtr["CourseCode"].ToString(),
                                CourseName = dtr["CourseName"].ToString(),
                                TrainorName = dtr["TrainorName"].ToString(),
                                NoOfTrainees = _g.ToInt32(dtr["NoOfTrainees"].ToString()),
                                EnrolledTrainees = _g.ToInt32(dtr["EnrolledTrainees"].ToString()),
                                AvailableSlot = dtr["AvailableSlot"].ToString(),
                                TrainingDuration = _g.ToInt32(dtr["TrainingDuration"].ToString()),
                                TrainingStartDate = _TrainingStartDate,
                                Active = _g.ToBoolean(dtr["Active"].ToString()),
                                TrainingFee = _g.ToDecimal(dtr["TrainingFee"].ToString()),
                                AssessorName = dtr["AssessorName"].ToString()
                            });
                        }
                    }
                }

                _jsonResponse = jsonSerialiser.Serialize(uTrainingCourses);
            }
            catch (Exception) { _jsonResponse = ""; }
            finally { mclsda.dbClose(); }

            return _jsonResponse;
        }

        [WebMethod]
        public string Get_EnrolledTrainee(string _Parameter, int _UserID, string _Token)
        {
            List<TraineeProfile> uTraineeProfile = new List<TraineeProfile>();

            try
            {
                mclsda.dbConnect();
                mclsda.ClearParameter();
                mclsda.AddParameter("Parameter", _Parameter);

                using (DataTableReader dtr = mclsda.ExecuteReader("[TRNG].[Get_EnrolledTrainee]", CommandType.StoredProcedure))
                {
                    if (dtr.HasRows)
                    {
                        while (dtr.Read())
                        {
                            string _DateOfBirth = _g._SetDate(dtr["DateOfBirth"].ToString());
                            string _EnrollmentDate = _g._SetDate(dtr["EnrollmentDate"].ToString());

                            uTraineeProfile.Add(new TraineeProfile
                            {
                                RegistrationID = _g.ToInt32(dtr["RegistrationID"].ToString()),
                                TraineeID = dtr["TraineeID"].ToString(),
                                FirstName = dtr["FirstName"].ToString(),
                                MiddleName = dtr["MiddleName"].ToString(),
                                LastName = dtr["LastName"].ToString(),
                                GenderID = _g.ToInt32(dtr["GenderID"].ToString()),
                                CivilStatusID = _g.ToInt32(dtr["CivilStatusID"].ToString()),
                                ContactNo = dtr["ContactNo"].ToString(),
                                DateOfBirth = _DateOfBirth,
                                Age = _g.ToInt32(dtr["Age"].ToString()),
                                PlaceOfBirth = dtr["PlaceOfBirth"].ToString(),
                                Active = _g.ToBoolean(dtr["Active"].ToString()),
                                PositionRank = dtr["PositionRank"].ToString(),
                                YearsOfSeaExperience = _g.ToInt32(dtr["YearsOfSeaExperience"].ToString()),
                                MarinaLicense = dtr["MarinaLicense"].ToString(),
                                PRCLicense = dtr["PRCLicense"].ToString(),
                                SIRBNo = dtr["SIRBNo"].ToString(),
                                PassportNo = dtr["PassportNo"].ToString(),
                                SRCNo = dtr["SRCNo"].ToString(),
                                Others = dtr["Others"].ToString(),
                                EnrollmentDate = _EnrollmentDate,
                                TotalPayment = dtr["TotalPayment"].ToString()
                            });
                        }
                    }
                }

                _jsonResponse = jsonSerialiser.Serialize(uTraineeProfile);
            }
            catch (Exception) { _jsonResponse = ""; }
            finally { mclsda.dbClose(); }

            return _jsonResponse;
        }
        
        #endregion

        #region Training Courses

        [WebMethod]
        public string Get_TrainingCourses(string _Parameter, int _UserID, string _Token)
        {
            List<TrainingCourses> uTrainingCourses = new List<TrainingCourses>();

            try
            {
                mclsda.dbConnect();
                mclsda.ClearParameter();
                mclsda.AddParameter("Parameter", _Parameter);

                using (DataTableReader dtr = mclsda.ExecuteReader("[TRNG].[Get_TrainingCourses]", CommandType.StoredProcedure))
                {
                    if (dtr.HasRows)
                    {
                        while (dtr.Read())
                        {
                            string _TrainingStartDate = _g._SetDate(dtr["TrainingStartDate"].ToString());

                            uTrainingCourses.Add(new TrainingCourses
                            {
                                CourseID = _g.ToInt32(dtr["CourseID"].ToString()),
                                CourseCode = dtr["CourseCode"].ToString(),
                                CourseName = dtr["CourseName"].ToString(),
                                TrainorName = dtr["TrainorName"].ToString(),
                                NoOfTrainees = _g.ToInt32(dtr["NoOfTrainees"].ToString()),
                                EnrolledTrainees = _g.ToInt32(dtr["EnrolledTrainees"].ToString()),
                                AvailableSlot = dtr["AvailableSlot"].ToString(),
                                TrainingDuration = _g.ToInt32(dtr["TrainingDuration"].ToString()),
                                TrainingStartDate = _TrainingStartDate,
                                Active = _g.ToBoolean(dtr["Active"].ToString()),
                                TrainingFee = _g.ToDecimal(dtr["TrainingFee"].ToString()),
                                AssessorName = dtr["AssessorName"].ToString()
                            });
                        }
                    }
                }

                _jsonResponse = jsonSerialiser.Serialize(uTrainingCourses);
            }
            catch (Exception) { _jsonResponse = ""; }
            finally { mclsda.dbClose(); }

            return _jsonResponse;
        }

        #endregion

        #region Accounts Receivables

        [WebMethod]
        public string Get_AccountsReceivableHistory(int _CourseID, string _TraineeID, int _UserID, string _Token)
        {
            List<AccountsReceivableHIstory> uAccountsReceivableHIstory = new List<AccountsReceivableHIstory>();

            try
            {
                mclsda.dbConnect();
                mclsda.ClearParameter();
                mclsda.AddParameter("CourseID", _CourseID);
                mclsda.AddParameter("TraineeID", _TraineeID);

                using (DataTableReader dtr = mclsda.ExecuteReader("[ACCT].[Get_AccountsReceivableHistory]", CommandType.StoredProcedure))
                {
                    if (dtr.HasRows)
                    {
                        while (dtr.Read())
                        {
                            string _TransactionDate = _g._SetDate(dtr["TransactionDate"].ToString());

                            uAccountsReceivableHIstory.Add(new AccountsReceivableHIstory
                            {
                                RegistrationID = _g.ToInt32(dtr["RegistrationID"].ToString()),
                                TraineeID = dtr["TraineeID"].ToString(),
                                CourseID = _g.ToInt32(dtr["CourseID"].ToString()),
                                CourseCode = dtr["CourseCode"].ToString(),
                                CourseName = dtr["CourseName"].ToString(),
                                TransactionDate = _TransactionDate,
                                AmountPaid = _g.ToDecimal(dtr["AmountPaid"].ToString()),
                                PaymentDetails = dtr["PaymentDetails"].ToString(),
                            });
                        }
                    }
                }

                _jsonResponse = jsonSerialiser.Serialize(uAccountsReceivableHIstory);
            }
            catch (Exception) { _jsonResponse = ""; }
            finally { mclsda.dbClose(); }

            return _jsonResponse;
        }

        [WebMethod]
        public string Get_TotalAmountPaid(int _CourseID, string _TraineeID, int _UserID, string _Token)
        {
            List<TotalPaidAmount> uTotalPaidAmount = new List<TotalPaidAmount>();

            try
            {
                mclsda.dbConnect();
                mclsda.ClearParameter();
                mclsda.AddParameter("CourseID", _CourseID);
                mclsda.AddParameter("TraineeID", _TraineeID);

                using (DataTableReader dtr = mclsda.ExecuteReader("[ACCT].[Get_TotalAmountPaid]", CommandType.StoredProcedure))
                {
                    if (dtr.HasRows)
                    {
                        while (dtr.Read())
                        {
                            uTotalPaidAmount.Add(new TotalPaidAmount
                            {
                                RegistrationID = _g.ToInt32(dtr["RegistrationID"].ToString()),
                                TraineeID = dtr["TraineeID"].ToString(),
                                CourseID = _g.ToInt32(dtr["CourseID"].ToString()),
                                TotalAmountPaid = _g.ToDecimal(dtr["TotalAmountPaid"].ToString())
                            });
                        }
                    }
                }

                _jsonResponse = jsonSerialiser.Serialize(uTotalPaidAmount);
            }
            catch (Exception) { _jsonResponse = ""; }
            finally { mclsda.dbClose(); }

            return _jsonResponse;
        }

        [WebMethod]
        public string Get_TraineeAccountsReceivable(string TraineeID, int _UserID, string _Token)
        {
            List<TraineeAccountsReceivable> uTraineeAccountsReceivable = new List<TraineeAccountsReceivable>();

            try
            {
                mclsda.dbConnect();
                mclsda.ClearParameter();
                mclsda.AddParameter("TraineeID", TraineeID);

                using (DataTableReader dtr = mclsda.ExecuteReader("[ACCT].[Get_TraineeAccountsReceivable]", CommandType.StoredProcedure))
                {
                    if (dtr.HasRows)
                    {
                        while (dtr.Read())
                        {
                            string _TrainingStartDate = _g._SetDate(dtr["TrainingStartDate"].ToString());

                            uTraineeAccountsReceivable.Add(new TraineeAccountsReceivable
                            {
                                CourseID = _g.ToInt32(dtr["CourseID"].ToString()),
                                CourseCode = dtr["CourseCode"].ToString(),
                                CourseName = dtr["CourseName"].ToString(),
                                TrainorName = dtr["TrainorName"].ToString(),
                                TrainingStartDate = _TrainingStartDate,
                                TrainingDuration = _g.ToInt32(dtr["TrainingDuration"].ToString()),
                                TrainingFee = _g.ToDecimal(dtr["TrainingFee"].ToString()),
                                TotalPayment = _g.ToDecimal(dtr["TotalPayment"].ToString()),
                                DropTrainee = _g.ToBoolean(dtr["DropTrainee"].ToString())
                            });
                        }
                    }
                }

                _jsonResponse = jsonSerialiser.Serialize(uTraineeAccountsReceivable);
            }
            catch (Exception) { _jsonResponse = ""; }
            finally { mclsda.dbClose(); }

            return _jsonResponse;
        }
        
        #endregion

        #region Access Management

        [WebMethod]
        public string GetUserPass(string Username, string Password)
        {
            List<UserAccount> uAccount = new List<UserAccount>();

            try
            {
                mclsda.dbConnect();
                mclsda.ClearParameter();
                mclsda.AddParameter("Username", Username);
                mclsda.AddParameter("Password", Password);

                using (DataTableReader dtr = mclsda.ExecuteReader("[GEN].[User_Login]", CommandType.StoredProcedure))
                {
                    if (dtr.HasRows)
                    {
                        while (dtr.Read())
                        {
                            uAccount.Add(new UserAccount
                            {
                                UserID = _g.ToInt32(dtr["UserID"].ToString()),
                                UserName = dtr["UserName"].ToString(),
                                Password = dtr["Password"].ToString(),
                                FirstName = dtr["FirstName"].ToString(),
                                LastName = dtr["LastName"].ToString(),
                                EmailAddress = dtr["EmailAddress"].ToString(),
                                GroupID = _g.ToInt32(dtr["GroupID"].ToString()),
                                Office = dtr["Office"].ToString(),
                                Active = _g.ToBoolean(dtr["Active"].ToString()),
                                DepartmentID = _g.ToInt32(dtr["DepartmentID"].ToString()),
                                Token = "FzaXnRMR2345" + (_Cypher.Encrypt(dtr["UserName"].ToString(), _Cypher._PassPhrase + "FzaXnRMR2345"))
                            });
                        }
                    }
                }

                _jsonResponse = jsonSerialiser.Serialize(uAccount);
            }
            catch (Exception) { _jsonResponse = ""; }
            finally { mclsda.dbClose(); }

            return _jsonResponse;
        }

        [WebMethod]
        public string Get_UserAccessRights(int GroupID)
        {
            List<UserAccessRights> uUserAccessRights = new List<UserAccessRights>();

            try
            {
                mclsda.dbConnect();
                mclsda.ClearParameter();
                mclsda.AddParameter("GroupID", GroupID);

                using (DataTableReader dtr = mclsda.ExecuteReader("[GEN].[Get_UserAccessRights]", CommandType.StoredProcedure))
                {
                    if (dtr.HasRows)
                    {
                        while (dtr.Read())
                        {
                            uUserAccessRights.Add(new UserAccessRights
                            {
                                GroupRightID = _g.ToInt32(dtr["GroupRightID"].ToString()),
                                GroupID = _g.ToInt32(dtr["GroupID"].ToString()),
                                ModuleID = _g.ToInt32(dtr["ModuleID"].ToString()),
                                CanView = _g.ToBoolean(dtr["CanView"].ToString()),
                                CanEdit = _g.ToBoolean(dtr["CanEdit"].ToString()),
                                CanDelete = _g.ToBoolean(dtr["CanDelete"].ToString()),
                                ModuleName = dtr["ModuleName"].ToString()
                            });
                        }
                    }
                }

                _jsonResponse = jsonSerialiser.Serialize(uUserAccessRights);
            }
            catch (Exception) { _jsonResponse = ""; }
            finally { mclsda.dbClose(); }

            return _jsonResponse;
        }

        #endregion

        #region Account Management

        [WebMethod]
        public string Get_UserAccount(string _Parameter, int _UserID, string _Token)
        {
            List<UserAccount> uUserAccount = new List<UserAccount>();

            if (Validate_Token(_UserID, _Token))
            {
                try
                {
                    mclsda.dbConnect();
                    mclsda.ClearParameter();
                    mclsda.AddParameter("Parameter", _Parameter);

                    using (DataTableReader dtr = mclsda.ExecuteReader("[GEN].[Get_UserAccount]", CommandType.StoredProcedure))
                    {
                        if (dtr.HasRows)
                        {
                            while (dtr.Read())
                            {
                                uUserAccount.Add(new UserAccount
                                {
                                    UserID = _g.ToInt32(dtr["UserID"].ToString()),
                                    UserName = dtr["UserName"].ToString(),
                                    Password = dtr["Password"].ToString(),
                                    FirstName = dtr["FirstName"].ToString(),
                                    LastName = dtr["LastName"].ToString(),
                                    GroupID = _g.ToInt32(dtr["GroupID"].ToString()),
                                    GroupName = dtr["GroupName"].ToString(),
                                    EmailAddress = dtr["EmailAddress"].ToString(),
                                    DepartmentID = _g.ToInt32(dtr["DepartmentID"].ToString()),
                                    DepartmentName = dtr["DepartmentName"].ToString(),
                                    Office = dtr["Office"].ToString(),
                                    Active = _g.ToBoolean(dtr["Active"].ToString())
                                });
                            }
                        }
                    }

                    _jsonResponse = jsonSerialiser.Serialize(uUserAccount);
                }
                catch (Exception) { _jsonResponse = ""; }
                finally { mclsda.dbClose(); }
            }
            else { _jsonResponse = ""; }

            return _jsonResponse;
        }

        [WebMethod]
        public string Get_UserGroups(string _Parameter, int _UserID, string _Token)
        {
            List<UserGroup> uUserGroup = new List<UserGroup>();

            if (Validate_Token(_UserID, _Token))
            {
                try
                {
                    mclsda.dbConnect();
                    mclsda.ClearParameter();
                    mclsda.AddParameter("Parameter", _Parameter);

                    using (DataTableReader dtr = mclsda.ExecuteReader("[GEN].[Get_UserGroups]", CommandType.StoredProcedure))
                    {
                        if (dtr.HasRows)
                        {
                            while (dtr.Read())
                            {
                                uUserGroup.Add(new UserGroup
                                {
                                    GroupID = _g.ToInt32(dtr["GroupID"].ToString()),
                                    GroupName = dtr["GroupName"].ToString(),
                                    GroupDescription = dtr["GroupDescription"].ToString(),
                                    Active = _g.ToBoolean(dtr["Active"].ToString())
                                });
                            }
                        }
                    }

                    _jsonResponse = jsonSerialiser.Serialize(uUserGroup);
                }
                catch (Exception) { _jsonResponse = ""; }
                finally { mclsda.dbClose(); }
            }
            else { _jsonResponse = ""; }

            return _jsonResponse;
        }

        [WebMethod]
        public string Get_GroupRights(string _Parameter, int _UserID, string _Token)
        {
            List<GroupRights> uGroupRights = new List<GroupRights>();

            if (Validate_Token(_UserID, _Token))
            {
                try
                {
                    mclsda.dbConnect();
                    mclsda.ClearParameter();
                    mclsda.AddParameter("Parameter", _Parameter);

                    using (DataTableReader dtr = mclsda.ExecuteReader("[GEN].[Get_GroupRights]", CommandType.StoredProcedure))
                    {
                        if (dtr.HasRows)
                        {
                            while (dtr.Read())
                            {
                                uGroupRights.Add(new GroupRights
                                {
                                    GroupRightID = _g.ToInt32(dtr["GroupRightID"].ToString()),
                                    GroupID = _g.ToInt32(dtr["GroupID"].ToString()),
                                    ModuleID = _g.ToInt32(dtr["ModuleID"].ToString()),
                                    ModuleName = dtr["ModuleName"].ToString(),
                                    CanView = _g.ToBoolean(dtr["CanView"].ToString()),
                                    CanEdit = _g.ToBoolean(dtr["CanEdit"].ToString()),
                                    CanDelete = _g.ToBoolean(dtr["CanDelete"].ToString())
                                });
                            }
                        }
                    }

                    _jsonResponse = jsonSerialiser.Serialize(uGroupRights);
                }
                catch (Exception) { _jsonResponse = ""; }
                finally { mclsda.dbClose(); }
            }
            else { _jsonResponse = ""; }

            return _jsonResponse;
        }

        #endregion

        #region Data Management

        [WebMethod]
        public string Get_Gender(string _Parameter, int _UserID, string _Token)
        {
            List<Gender> uGender = new List<Gender>();

            if (Validate_Token(_UserID, _Token))
            {
                try
                {
                    mclsda.dbConnect();
                    mclsda.ClearParameter();
                    mclsda.AddParameter("Parameter", _Parameter);

                    using (DataTableReader dtr = mclsda.ExecuteReader("[GEN].[Get_Gender]", CommandType.StoredProcedure))
                    {
                        if (dtr.HasRows)
                        {
                            while (dtr.Read())
                            {
                                uGender.Add(new Gender
                                {
                                    GenderID = _g.ToInt32(dtr["GenderID"].ToString()),
                                    GenderName = dtr["GenderName"].ToString()
                                });
                            }
                        }
                    }

                    _jsonResponse = jsonSerialiser.Serialize(uGender);
                }
                catch (Exception) { _jsonResponse = ""; }
                finally { mclsda.dbClose(); }
            }
            else { _jsonResponse = ""; }

            return _jsonResponse;
        }

        [WebMethod]
        public string Get_CivilStatus(string _Parameter, int _UserID, string _Token)
        {
            List<CivilStatus> uCivilStatus = new List<CivilStatus>();

            if (Validate_Token(_UserID, _Token))
            {
                try
                {
                    mclsda.dbConnect();
                    mclsda.ClearParameter();
                    mclsda.AddParameter("Parameter", _Parameter);

                    using (DataTableReader dtr = mclsda.ExecuteReader("[GEN].[Get_CivilStatus]", CommandType.StoredProcedure))
                    {
                        if (dtr.HasRows)
                        {
                            while (dtr.Read())
                            {
                                uCivilStatus.Add(new CivilStatus
                                {
                                    CivilStatusID = _g.ToInt32(dtr["CivilStatusID"].ToString()),
                                    CivilStatusName = dtr["CivilStatusName"].ToString()
                                });
                            }
                        }
                    }

                    _jsonResponse = jsonSerialiser.Serialize(uCivilStatus);
                }
                catch (Exception) { _jsonResponse = ""; }
                finally { mclsda.dbClose(); }
            }
            else { _jsonResponse = ""; }

            return _jsonResponse;
        }

        [WebMethod]
        public string Get_SystemModules(string _Parameter, int _UserID, string _Token)
        {
            List<SystemModules> uPageModules = new List<SystemModules>();

            if (Validate_Token(_UserID, _Token))
            {
                try
                {
                    mclsda.dbConnect();
                    mclsda.ClearParameter();
                    mclsda.AddParameter("Parameter", _Parameter);

                    using (DataTableReader dtr = mclsda.ExecuteReader("[GEN].[Get_SystemModules]", CommandType.StoredProcedure))
                    {
                        if (dtr.HasRows)
                        {
                            while (dtr.Read())
                            {
                                uPageModules.Add(new SystemModules
                                {
                                    ModuleID = _g.ToInt32(dtr["ModuleID"].ToString()),
                                    ModuleName = dtr["ModuleName"].ToString(),
                                    ModuleDescription = dtr["ModuleDescription"].ToString(),
                                    ModuleURL = dtr["ModuleURL"].ToString()
                                });
                            }
                        }
                    }

                    _jsonResponse = jsonSerialiser.Serialize(uPageModules);
                }
                catch (Exception) { _jsonResponse = ""; }
                finally { mclsda.dbClose(); }
            }
            else { _jsonResponse = ""; }

            return _jsonResponse;
        }

        [WebMethod]
        public string Get_Office(string _Parameter, int _UserID, string _Token)
        {
            List<Office> uOffice = new List<Office>();

            if (Validate_Token(_UserID, _Token))
            {
                try
                {
                    mclsda.dbConnect();
                    mclsda.ClearParameter();
                    mclsda.AddParameter("Parameter", _Parameter);

                    using (DataTableReader dtr = mclsda.ExecuteReader("[GEN].[Get_Office]", CommandType.StoredProcedure))
                    {
                        if (dtr.HasRows)
                        {
                            while (dtr.Read())
                            {
                                uOffice.Add(new Office
                                {
                                    OfficeID = _g.ToInt32(dtr["OfficeID"].ToString()),
                                    OfficeCode = dtr["OfficeCode"].ToString(),
                                    OfficeName = dtr["OfficeName"].ToString(),
                                    OfficeAddress = dtr["OfficeAddress"].ToString(),
                                    ContactNo = dtr["ContactNo"].ToString(),
                                    Active = _g.ToBoolean(dtr["Active"].ToString())
                                });
                            }
                        }
                    }

                    _jsonResponse = jsonSerialiser.Serialize(uOffice);
                }
                catch (Exception) { _jsonResponse = ""; }
                finally { mclsda.dbClose(); }
            }
            else { _jsonResponse = ""; }

            return _jsonResponse;
        }

        [WebMethod]
        public string Get_Department(string _Parameter, int _UserID, string _Token)
        {
            List<Department> uDepartment = new List<Department>();

            if (Validate_Token(_UserID, _Token))
            {
                try
                {
                    mclsda.dbConnect();
                    mclsda.ClearParameter();
                    mclsda.AddParameter("Parameter", _Parameter);

                    using (DataTableReader dtr = mclsda.ExecuteReader("[GEN].[Get_Department]", CommandType.StoredProcedure))
                    {
                        if (dtr.HasRows)
                        {
                            while (dtr.Read())
                            {
                                uDepartment.Add(new Department
                                {
                                    DepartmentID = _g.ToInt32(dtr["DepartmentID"].ToString()),
                                    DepartmentCode = dtr["DepartmentCode"].ToString(),
                                    DepartmentName = dtr["DepartmentName"].ToString(),
                                    Active = _g.ToBoolean(dtr["Active"].ToString())
                                });
                            }
                        }
                    }

                    _jsonResponse = jsonSerialiser.Serialize(uDepartment);
                }
                catch (Exception) { _jsonResponse = ""; }
                finally { mclsda.dbClose(); }
            }
            else { _jsonResponse = ""; }

            return _jsonResponse;
        }

        #endregion

        #region Reports

        [WebMethod]
        public string Report_AccountsReceivable_All(string _DateFrom, string _DateTo, int _UserID, string _Token)
        {
            List<ARReport> uReport = new List<ARReport>();

            if (Validate_Token(_UserID, _Token))
            {
                try
                {
                    mclsda.dbConnect();
                    mclsda.ClearParameter();
                    mclsda.AddParameter("DateFrom", _DateFrom);
                    mclsda.AddParameter("DateTo", _DateTo);

                    using (DataTableReader dtr = mclsda.ExecuteReader("[ACCT].[Report_AccountsReceivable_All]", CommandType.StoredProcedure))
                    {
                        if (dtr.HasRows)
                        {
                            while (dtr.Read())
                            {
                                uReport.Add(new ARReport
                                {
                                    TraineeID = dtr["TraineeID"].ToString(),
                                    TraineeName = dtr["TraineeName"].ToString(),
                                    CourseCode = dtr["CourseCode"].ToString(),
                                    CourseName = dtr["CourseName"].ToString(),
                                    TotalPayment = dtr["TotalPayment"].ToString(),
                                    TotalBalance = dtr["TotalBalance"].ToString()
                                });
                            }
                        }
                    }

                    _jsonResponse = jsonSerialiser.Serialize(uReport);
                }
                catch (Exception) { _jsonResponse = ""; }
                finally { mclsda.dbClose(); }
            }
            else { _jsonResponse = ""; }

            return _jsonResponse;
        }

        [WebMethod]
        public string Report_AccountsReceivable_Course(string _DateFrom, string _DateTo, int _CourseID, int _UserID, string _Token)
        {
            List<ARReport> uReport = new List<ARReport>();

            if (Validate_Token(_UserID, _Token))
            {
                try
                {
                    mclsda.dbConnect();
                    mclsda.ClearParameter();
                    mclsda.AddParameter("DateFrom", _DateFrom);
                    mclsda.AddParameter("DateTo", _DateTo);
                    mclsda.AddParameter("CourseID", _CourseID);

                    using (DataTableReader dtr = mclsda.ExecuteReader("[ACCT].[Report_AccountsReceivable_Course]", CommandType.StoredProcedure))
                    {
                        if (dtr.HasRows)
                        {
                            while (dtr.Read())
                            {
                                uReport.Add(new ARReport
                                {
                                    TraineeID = dtr["TraineeID"].ToString(),
                                    TraineeName = dtr["TraineeName"].ToString(),
                                    CourseCode = dtr["CourseCode"].ToString(),
                                    CourseName = dtr["CourseName"].ToString(),
                                    TotalPayment = dtr["TotalPayment"].ToString(),
                                    TotalBalance = dtr["TotalBalance"].ToString()
                                });
                            }
                        }
                    }

                    _jsonResponse = jsonSerialiser.Serialize(uReport);
                }
                catch (Exception) { _jsonResponse = ""; }
                finally { mclsda.dbClose(); }
            }
            else { _jsonResponse = ""; }

            return _jsonResponse;
        }

        [WebMethod]
        public string Report_Sales_All(string _DateFrom, string _DateTo, int _UserID, string _Token)
        {
            List<SalesReport> uReport = new List<SalesReport>();

            if (Validate_Token(_UserID, _Token))
            {
                try
                {
                    mclsda.dbConnect();
                    mclsda.ClearParameter();
                    mclsda.AddParameter("DateFrom", _DateFrom);
                    mclsda.AddParameter("DateTo", _DateTo);

                    using (DataTableReader dtr = mclsda.ExecuteReader("[ACCT].[Report_Sales_All]", CommandType.StoredProcedure))
                    {
                        if (dtr.HasRows)
                        {
                            while (dtr.Read())
                            {
                                uReport.Add(new SalesReport
                                {
                                    TraineeID = dtr["TraineeID"].ToString(),
                                    TraineeName = dtr["TraineeName"].ToString(),
                                    CourseCode = dtr["CourseCode"].ToString(),
                                    CourseName = dtr["CourseName"].ToString(),
                                    TransactionDate = dtr["TransactionDate"].ToString(),
                                    AmountPaid = dtr["AmountPaid"].ToString()
                                });
                            }
                        }
                    }

                    _jsonResponse = jsonSerialiser.Serialize(uReport);
                }
                catch (Exception) { _jsonResponse = ""; }
                finally { mclsda.dbClose(); }
            }
            else { _jsonResponse = ""; }

            return _jsonResponse;
        }

        [WebMethod]
        public string Report_Sales_Course(string _DateFrom, string _DateTo, int _CourseID, int _UserID, string _Token)
        {
            List<ARReport> uReport = new List<ARReport>();

            if (Validate_Token(_UserID, _Token))
            {
                try
                {
                    mclsda.dbConnect();
                    mclsda.ClearParameter();
                    mclsda.AddParameter("DateFrom", _DateFrom);
                    mclsda.AddParameter("DateTo", _DateTo);
                    mclsda.AddParameter("CourseID", _CourseID);

                    using (DataTableReader dtr = mclsda.ExecuteReader("[ACCT].[Report_Sales_Course]", CommandType.StoredProcedure))
                    {
                        if (dtr.HasRows)
                        {
                            while (dtr.Read())
                            {
                                uReport.Add(new ARReport
                                {
                                    TraineeID = dtr["TraineeID"].ToString(),
                                    TraineeName = dtr["TraineeName"].ToString(),
                                    CourseCode = dtr["CourseCode"].ToString(),
                                    CourseName = dtr["CourseName"].ToString(),
                                    TransactionDate = dtr["TransactionDate"].ToString(),
                                    AmountPaid = dtr["AmountPaid"].ToString()
                                });
                            }
                        }
                    }

                    _jsonResponse = jsonSerialiser.Serialize(uReport);
                }
                catch (Exception) { _jsonResponse = ""; }
                finally { mclsda.dbClose(); }
            }
            else { _jsonResponse = ""; }

            return _jsonResponse;
        }

        [WebMethod]
        public string Report_EnrolledTraineeCount_All(string _DateFrom, string _DateTo, int _UserID, string _Token)
        {
            List<EnrolledTraineReport> uEnrolledTraineReport = new List<EnrolledTraineReport>();

            if (Validate_Token(_UserID, _Token))
            {
                try
                {
                    mclsda.dbConnect();
                    mclsda.ClearParameter();
                    mclsda.AddParameter("DateFrom", _DateFrom);
                    mclsda.AddParameter("DateTo", _DateTo);

                    using (DataTableReader dtr = mclsda.ExecuteReader("[ACCT].[Report_Sales_All]", CommandType.StoredProcedure))
                    {
                        if (dtr.HasRows)
                        {
                            while (dtr.Read())
                            {
                                uEnrolledTraineReport.Add(new EnrolledTraineReport
                                {
                                    TraineeID = dtr["TraineeID"].ToString(),
                                    TraineeName = dtr["TraineeName"].ToString(),
                                    ContactNo = dtr["ContactNo"].ToString(),
                                    DateOfBirth = dtr["DateOfBirth"].ToString(),
                                    PlaceOfBirth = dtr["PlaceOfBirth"].ToString(),
                                    PositionRank = dtr["PositionRank"].ToString(),
                                    EnrollmentDate = dtr["EnrollmentDate"].ToString()
                                });
                            }
                        }
                    }

                    _jsonResponse = jsonSerialiser.Serialize(uEnrolledTraineReport);
                }
                catch (Exception) { _jsonResponse = ""; }
                finally { mclsda.dbClose(); }
            }
            else { _jsonResponse = ""; }

            return _jsonResponse;
        }
        
        #endregion

        #endregion

        #region Save Data

        #region Trainee Profile

        [WebMethod]
        public void Save_TraineeProfile(string TraineeID, string FirstName, string MiddleName, string LastName, int GenderID, int CivilStatusID, string ContactNo, string DateOfBirth
            , int Age, string PlaceOfBirth, bool Active, string PositionRank, int YearsOfSeaExperience, string MarinaLicense, string PRCLicense, string SIRBNo, string PassportNo
            , string SRCNo, string Others, string EnrollmentDate, int _UserID, string _Token)
        {
            if (Validate_Token(_UserID, _Token))
            {
                try
                {
                    mclsda.dbConnect();
                    mclsda.ClearParameter();
                    mclsda.AddParameter("TraineeID", TraineeID);
                    mclsda.AddParameter("FirstName", FirstName);
                    mclsda.AddParameter("MiddleName", MiddleName);
                    mclsda.AddParameter("LastName", LastName);
                    mclsda.AddParameter("GenderID", GenderID);
                    mclsda.AddParameter("CivilStatusID", CivilStatusID);
                    mclsda.AddParameter("ContactNo", ContactNo);
                    mclsda.AddParameter("DateOfBirth", DateOfBirth);
                    mclsda.AddParameter("Age", Age);
                    mclsda.AddParameter("PlaceOfBirth", PlaceOfBirth);
                    mclsda.AddParameter("Active", Active);

                    mclsda.AddParameter("PositionRank", PositionRank);
                    mclsda.AddParameter("YearsOfSeaExperience", YearsOfSeaExperience);

                    mclsda.AddParameter("MarinaLicense", MarinaLicense);
                    mclsda.AddParameter("PRCLicense", PRCLicense);
                    mclsda.AddParameter("SIRBNo", SIRBNo);
                    mclsda.AddParameter("PassportNo", PassportNo);
                    mclsda.AddParameter("SRCNo", SRCNo);
                    mclsda.AddParameter("Others", Others);
                    mclsda.AddParameter("EnrollmentDate", EnrollmentDate);

                    mclsda.ExecuteNonQuery("[TRNG].[Save_TraineeProfile]", CommandType.StoredProcedure);
                }
                catch (Exception ex) { throw ex; }
                finally { mclsda.dbClose(); }
            }
        }

        #endregion

        #region Training Registration

        [WebMethod]
        public void Save_TraineeRegistration(int RegistrationID, string DateRegistered, string TraineeID, int CourseID, string CourseCode, bool DropTrainee
            , int _UserID, string _Token)
        {
            if (Validate_Token(_UserID, _Token))
            {
                try
                {
                    mclsda.dbConnect();
                    mclsda.ClearParameter();
                    mclsda.AddParameter("RegistrationID", RegistrationID);
                    mclsda.AddParameter("DateRegistered", DateRegistered);
                    mclsda.AddParameter("TraineeID", TraineeID);
                    mclsda.AddParameter("CourseID", CourseID);
                    mclsda.AddParameter("CourseCode", CourseCode);
                    mclsda.AddParameter("DropTrainee", DropTrainee);

                    mclsda.ExecuteNonQuery("[TRNG].[Save_TraineeRegistration]", CommandType.StoredProcedure);
                }
                catch (Exception ex) { throw ex; }
                finally { mclsda.dbClose(); }
            }
        }

        [WebMethod]
        public void Save_DropTrainee(string TraineeID, int CourseID, int RegistrationID, int _UserID, string _Token)
        {
            if (Validate_Token(_UserID, _Token))
            {
                try
                {
                    mclsda.dbConnect();
                    mclsda.ClearParameter();
                    mclsda.AddParameter("TraineeID", TraineeID);
                    mclsda.AddParameter("CourseID", CourseID);
                    mclsda.AddParameter("RegistrationID", RegistrationID);

                    mclsda.ExecuteNonQuery("[TRNG].[Save_DropTrainee]", CommandType.StoredProcedure);
                }
                catch (Exception ex) { throw ex; }
                finally { mclsda.dbClose(); }
            }
        }
        
        #endregion

        #region Training Courses

        [WebMethod]
        public void Save_TrainingCourses(int CourseID, string CourseCode, string CourseName, string TrainorName, int NoOfTrainees, int TrainingDuration
            , string TrainingStartDate, bool Active, decimal TrainingFee, string AssessorName, int _UserID, string _Token)
        {
            if (Validate_Token(_UserID, _Token))
            {
                try
                {
                    mclsda.dbConnect();
                    mclsda.ClearParameter();
                    mclsda.AddParameter("CourseID", CourseID);
                    mclsda.AddParameter("CourseCode", CourseCode);
                    mclsda.AddParameter("CourseName", CourseName);
                    mclsda.AddParameter("TrainorName", TrainorName);
                    mclsda.AddParameter("NoOfTrainees", NoOfTrainees);
                    mclsda.AddParameter("TrainingDuration", TrainingDuration);
                    mclsda.AddParameter("TrainingStartDate", TrainingStartDate);
                    mclsda.AddParameter("Active", Active);
                    mclsda.AddParameter("TrainingFee", TrainingFee);
                    mclsda.AddParameter("AssessorName", AssessorName);

                    mclsda.ExecuteNonQuery("[TRNG].[Save_TrainingCourses]", CommandType.StoredProcedure);
                }
                catch (Exception ex) { throw ex; }
                finally { mclsda.dbClose(); }
            }
        }

        #endregion

        #region Accounts Receivable

        [WebMethod]
        public void Save_Payments(int RegistrationID, decimal AmountPaid, string PaymentDetails, int _UserID, string _Token)
        {
            if (Validate_Token(_UserID, _Token))
            {
                try
                {
                    mclsda.dbConnect();
                    mclsda.ClearParameter();
                    mclsda.AddParameter("RegistrationID", RegistrationID);
                    mclsda.AddParameter("AmountPaid", AmountPaid);
                    mclsda.AddParameter("PaymentDetails", PaymentDetails);

                    mclsda.ExecuteNonQuery("[ACCT].[Save_Payments]", CommandType.StoredProcedure);
                }
                catch (Exception ex) { throw ex; }
                finally { mclsda.dbClose(); }
            }
        }
        
        #endregion

        #region Account Management

        [WebMethod]
        public void Save_UserAccounts(int UserID, string UserName, string Password, string FirstName, string LastName, int GroupID, string EmailAddress, string Office, int DepartmentID, bool Active, int _UserID, string _Token)
        {
            if (Validate_Token(_UserID, _Token))
            {
                try
                {
                    mclsda.dbConnect();
                    mclsda.ClearParameter();
                    mclsda.AddParameter("UserID", UserID);
                    mclsda.AddParameter("UserName", UserName);
                    mclsda.AddParameter("Password", Password);
                    mclsda.AddParameter("FirstName", FirstName);
                    mclsda.AddParameter("LastName", LastName);
                    mclsda.AddParameter("GroupID", GroupID);
                    mclsda.AddParameter("EmailAddress", EmailAddress);
                    mclsda.AddParameter("Office", Office);
                    mclsda.AddParameter("DepartmentID", DepartmentID);
                    mclsda.AddParameter("Active", Active);

                    mclsda.ExecuteNonQuery("[GEN].[Save_UserAccounts]", CommandType.StoredProcedure);

                }
                catch (Exception ex) { throw ex; }
                finally { mclsda.dbClose(); }
            }
        }

        [WebMethod]
        public void Save_UserGroups(int ID, string GroupName, string Description, bool Active, int _UserID, string _Token)
        {
            if (Validate_Token(_UserID, _Token))
            {
                try
                {
                    mclsda.dbConnect();
                    mclsda.ClearParameter();
                    mclsda.AddParameter("ID", ID);
                    mclsda.AddParameter("GroupName", GroupName);
                    mclsda.AddParameter("Description", Description);
                    mclsda.AddParameter("Active", Active);

                    mclsda.ExecuteNonQuery("[GEN].[Save_UserGroups]", CommandType.StoredProcedure);
                }
                catch (Exception ex) { throw ex; }
                finally { mclsda.dbClose(); }
            }
        }

        [WebMethod]
        public void Save_GroupRights(int GroupRightID, int GroupID, int ModuleID, bool CanView, bool CanEdit, bool CanDelete, int _UserID, string _Token)
        {
            if (Validate_Token(_UserID, _Token))
            {
                try
                {
                    mclsda.dbConnect();
                    mclsda.ClearParameter();
                    mclsda.AddParameter("GroupRightID", GroupRightID);
                    mclsda.AddParameter("GroupID", GroupID);
                    mclsda.AddParameter("ModuleID", ModuleID);
                    mclsda.AddParameter("CanView", CanView);
                    mclsda.AddParameter("CanEdit", CanEdit);
                    mclsda.AddParameter("CanDelete", CanDelete);

                    mclsda.ExecuteNonQuery("[GEN].[Save_GroupRights]", CommandType.StoredProcedure);
                }
                catch (Exception ex) { throw ex; }
                finally { mclsda.dbClose(); }
            }
        }

        [WebMethod]
        public void Save_UserProfile(int UserID, string Password, int _UserID, string _Token)
        {
            if (Validate_Token(_UserID, _Token))
            {
                try
                {
                    mclsda.dbConnect();
                    mclsda.ClearParameter();
                    mclsda.AddParameter("UserID", UserID);
                    mclsda.AddParameter("Password", Password);

                    mclsda.ExecuteNonQuery("[GEN].[Save_UserProfile]", CommandType.StoredProcedure);

                }
                catch (Exception ex) { throw ex; }
                finally { mclsda.dbClose(); }
            }
        }

        #endregion

        #region Data Management

        [WebMethod]
        public void Save_Gender(int GenderID, string GenderName, int _UserID, string _Token)
        {
            if (Validate_Token(_UserID, _Token))
            {
                try
                {
                    mclsda.dbConnect();
                    mclsda.ClearParameter();
                    mclsda.AddParameter("GenderID", GenderID);
                    mclsda.AddParameter("GenderName", GenderName);

                    mclsda.ExecuteNonQuery("[GEN].[Save_Gender]", CommandType.StoredProcedure);
                }
                catch (Exception ex) { throw ex; }
                finally { mclsda.dbClose(); }
            }
        }

        [WebMethod]
        public void Save_CivilStatus(int CivilStatusID, string CivilStatusName, int _UserID, string _Token)
        {
            if (Validate_Token(_UserID, _Token))
            {
                try
                {
                    mclsda.dbConnect();
                    mclsda.ClearParameter();
                    mclsda.AddParameter("CivilStatusID", CivilStatusID);
                    mclsda.AddParameter("CivilStatusName", CivilStatusName);

                    mclsda.ExecuteNonQuery("[GEN].[Save_CivilStatus]", CommandType.StoredProcedure);
                }
                catch (Exception ex) { throw ex; }
                finally { mclsda.dbClose(); }
            }
        }

        //[WebMethod]
        //public void Save_IdentificationList(int IdentificationListID, string IdentificationListName, int _UserID, string _Token)
        //{
        //    if (Validate_Token(_UserID, _Token))
        //    {
        //        try
        //        {
        //            mclsda.dbConnect();
        //            mclsda.ClearParameter();
        //            mclsda.AddParameter("IdentificationListID", IdentificationListID);
        //            mclsda.AddParameter("IdentificationListName", IdentificationListName);

        //            mclsda.ExecuteNonQuery("[GEN].[Save_IdentificationList]", CommandType.StoredProcedure);
        //        }
        //        catch (Exception ex) { throw ex; }
        //        finally { mclsda.dbClose(); }
        //    }
        //}

        [WebMethod]
        public void Save_SystemModules(int ModuleID, string ModuleName, string ModuleDescription, string ModuleURL, int _UserID, string _Token)
        {
            if (Validate_Token(_UserID, _Token))
            {
                try
                {
                    mclsda.dbConnect();
                    mclsda.ClearParameter();
                    mclsda.AddParameter("ModuleID", ModuleID);
                    mclsda.AddParameter("ModuleName", ModuleName);
                    mclsda.AddParameter("ModuleDescription", ModuleDescription);
                    mclsda.AddParameter("ModuleURL", ModuleURL);

                    mclsda.ExecuteNonQuery("[GEN].[Save_SystemModules]", CommandType.StoredProcedure);
                }
                catch (Exception ex) { throw ex; }
                finally { mclsda.dbClose(); }
            }
        }

        [WebMethod]
        public void Save_Office(int OfficeID, string OfficeCode, string OfficeName, string OfficeAddress, string ContactNo, bool Active, int _UserID, string _Token)
        {
            if (Validate_Token(_UserID, _Token))
            {
                try
                {
                    mclsda.dbConnect();
                    mclsda.ClearParameter();
                    mclsda.AddParameter("OfficeID", OfficeID);
                    mclsda.AddParameter("OfficeCode", OfficeCode);
                    mclsda.AddParameter("OfficeName", OfficeName);
                    mclsda.AddParameter("OfficeAddress", OfficeAddress);
                    mclsda.AddParameter("ContactNo", ContactNo);
                    mclsda.AddParameter("Active", Active);

                    mclsda.ExecuteNonQuery("[GEN].[Save_Office]", CommandType.StoredProcedure);
                }
                catch (Exception ex) { throw ex; }
                finally { mclsda.dbClose(); }
            }
        }

        [WebMethod]
        public void Save_Department(int DepartmentID, string DepartmentCode, string DepartmentName, bool Active, int _UserID, string _Token)
        {
            if (Validate_Token(_UserID, _Token))
            {
                try
                {
                    mclsda.dbConnect();
                    mclsda.ClearParameter();
                    mclsda.AddParameter("DepartmentID", DepartmentID);
                    mclsda.AddParameter("DepartmentCode", DepartmentCode);
                    mclsda.AddParameter("DepartmentName", DepartmentName);
                    mclsda.AddParameter("Active", Active);

                    mclsda.ExecuteNonQuery("[GEN].[Save_Department]", CommandType.StoredProcedure);
                }
                catch (Exception ex) { throw ex; }
                finally { mclsda.dbClose(); }
            }
        }

        #endregion

        #endregion

        #region Transaction Management

        [WebMethod]
        public bool Validate_Token(int UserID, string TokenID)
        {
            bool _ValidateToken = false;

            try
            {
                //Get _userToken and EncryptedString
                int _strCount = TokenID.Length;
                string _userToken = TokenID.Substring(0, 12);
                string _eString = TokenID.Substring(12, (_strCount - 12));
                string _uNM = _Cypher.Decrypt(_eString, _Cypher._PassPhrase + _userToken);

                mclsda.dbConnect();
                mclsda.ClearParameter();
                mclsda.AddParameter("UserID", UserID);

                using (DataTableReader dtr = mclsda.ExecuteReader("[GEN].[Get_Token]", CommandType.StoredProcedure))
                {
                    if (dtr.HasRows)
                    {
                        while (dtr.Read())
                        {
                            if (dtr["UserName"].ToString() == _uNM) { _ValidateToken = true; }
                            else { _ValidateToken = false; }
                        }
                    }
                    else { _ValidateToken = false; }
                }
            }
            catch (Exception) { _ValidateToken = false; }
            finally { mclsda.dbClose(); }

            return _ValidateToken;
        }

        [WebMethod]
        public string Get_TransactionHistory(string _Parameter, int _UserID, string _Token)
        {
            List<TransactionHistory> uTransactionHistory = new List<TransactionHistory>();

            if (Validate_Token(_UserID, _Token))
            {
                try
                {
                    mclsda.dbConnect();
                    mclsda.ClearParameter();
                    mclsda.AddParameter("Parameter", _Parameter);

                    using (DataTableReader dtr = mclsda.ExecuteReader("[GEN].[Get_TransactionHistory]", CommandType.StoredProcedure))
                    {
                        if (dtr.HasRows)
                        {
                            while (dtr.Read())
                            {
                                uTransactionHistory.Add(new TransactionHistory
                                {
                                    ID = _g.ToInt32(dtr["ID"].ToString()),
                                    UserID = _g.ToInt32(dtr["UserID"].ToString()),
                                    UserName = dtr["UserName"].ToString(),
                                    FormName = dtr["FormName"].ToString(),
                                    EventName = dtr["EventName"].ToString(),
                                    ExceptionError = dtr["ExceptionError"].ToString(),
                                    TransactionLogs = dtr["TransactionLogs"].ToString(),
                                    ComputerName = dtr["ComputerName"].ToString(),
                                    IPAddress = dtr["IPAddress"].ToString(),
                                    DateTimeLogs = dtr["DateTimeLogs"].ToString()
                                });
                            }
                        }
                    }

                    _jsonResponse = jsonSerialiser.Serialize(uTransactionHistory);
                }
                catch (Exception) { _jsonResponse = ""; }
                finally { mclsda.dbClose(); }
            }
            else { _jsonResponse = ""; }

            return _jsonResponse;
        }

        [WebMethod]
        public void Save_TransactionHistory(int UserID, string FormName, string EventName, string ExceptionError, string TransactionLogs, string ComputerName, string IPAddress)
        {
            try
            {
                mclsda.dbConnect();
                mclsda.ClearParameter();
                mclsda.AddParameter("UserID", UserID);
                mclsda.AddParameter("FormName", FormName);
                mclsda.AddParameter("EventName", EventName);
                mclsda.AddParameter("ExceptionError", ExceptionError);
                mclsda.AddParameter("TransactionLogs", TransactionLogs);
                mclsda.AddParameter("ComputerName", ComputerName);
                mclsda.AddParameter("IPAddress", IPAddress);

                mclsda.ExecuteQuery("[GEN].[Save_TransactionHistory]", CommandType.StoredProcedure);
            }
            catch (Exception) { }
            finally { mclsda.dbClose(); }
        }

        #endregion
    }
}
