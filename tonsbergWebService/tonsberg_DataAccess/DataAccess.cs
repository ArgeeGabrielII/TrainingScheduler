using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace tonsberg_DataAccess
{
    public class DataAccess
    {
        #region Declaration

        public SqlConnection m_sqlCon;
        public SqlParameter m_sqlParam;

        public SqlTransaction SqlTrans;
        public SqlCommand SqlCom;

        public string ConnectionString;
        const int CommandTimeout = 120;

        #endregion

        #region Property

        public SqlConnection sqlCon
        {
            get { return m_sqlCon; }
            set { m_sqlCon = value; }
        }

        public SqlParameter sqlParam
        {
            get { return m_sqlParam; }
            set { m_sqlParam = value; }
        }

        #endregion

        #region DB Connection

        public void dbConnect()
        {
            try
            {
                sqlCon = new SqlConnection();
                ConnectionString = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
                sqlCon.ConnectionString = ConnectionString;
                sqlCon.Open();
            }
            catch (Exception ex) { throw ex; }
        }

        public void dbClose()
        {
            try
            {
                if (sqlCon != null) { sqlCon.Close(); }
                if (SqlTrans != null) { SqlTrans.Dispose(); }
            }
            catch (Exception ex) { throw ex; }
        }

        #endregion

        #region Script Parameters

        public void ClearParameter()
        {
            try
            {
                sqlParam = new SqlParameter();
                SqlCom = new SqlCommand();
            }
            catch (Exception ex) { throw ex; }
        }

        public void AddParameter(string ParamName, object ParamValue)
        {
            try { SqlCom.Parameters.AddWithValue(ParamName, ParamValue); }
            catch (Exception ex) { throw ex; }
        }

        #endregion

        #region Script Commands

        public DataTableReader ExecuteReader(string SQL, CommandType commType)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();

                SqlCom.CommandTimeout = CommandTimeout;
                SqlCom.Transaction = SqlTrans;
                SqlCom.CommandText = SQL;
                SqlCom.CommandType = commType;
                SqlCom.Connection = sqlCon;

                da.SelectCommand = SqlCom;
                da.Fill(ds);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0) { return ds.Tables[0].CreateDataReader(); }
                    else { return null; }
                }
                else { return null; }
            }
            catch (Exception ex) { throw ex; }
        }

        public DataSet ExecuteQuery(string SQL, CommandType commType)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();

                SqlCom.CommandTimeout = CommandTimeout;
                SqlCom.Transaction = SqlTrans;
                SqlCom.CommandText = SQL;
                SqlCom.CommandType = commType;
                SqlCom.Connection = sqlCon;

                da.SelectCommand = SqlCom;
                da.Fill(ds);

                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        public int ExecuteNonQuery(string SQL, CommandType commType)
        {
            try
            {
                SqlCom.CommandTimeout = CommandTimeout;
                SqlCom.Transaction = SqlTrans;
                SqlCom.CommandText = SQL;
                SqlCom.CommandType = commType;
                SqlCom.Connection = sqlCon;

                return SqlCom.ExecuteNonQuery();
            }
            catch (Exception ex) { throw ex; }
        }

        #endregion
    }
}
