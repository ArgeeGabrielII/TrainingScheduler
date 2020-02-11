using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI.WebControls;

namespace webApplication_Tonsberg
{
    public class _gControls
    {
        #region Computer Address

        public string localComputerName = Environment.MachineName;

        public string GetIPAddress()
        {
            string strIP = string.Empty;
            HttpRequest httpReq = HttpContext.Current.Request;

            try
            {
                WebRequest request = WebRequest.Create("http://bot.whatismyipaddress.com/");
                using (WebResponse response = request.GetResponse())
                using (StreamReader sr = new StreamReader(response.GetResponseStream())) { strIP = sr.ReadToEnd(); }
            }
            catch
            {
                if (httpReq.ServerVariables["HTTP_CLIENT_IP"] != null)
                {
                    strIP = httpReq.ServerVariables["HTTP_CLIENT_IP"].ToString();
                }
                else if (httpReq.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
                {
                    strIP = httpReq.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
                }
                //test for host address reported by the server
                else if (
                        //if exists
                        (httpReq.UserHostAddress.Length != 0)
                        &&
                        //and if not localhost IPV6 or localhost name
                        ((httpReq.UserHostAddress != "::1") || (httpReq.UserHostAddress != "localhost"))
                    )
                {
                    strIP = httpReq.UserHostAddress;
                }
            }

            return strIP;
        }

        #endregion

        public int ToInt32(string inputString)
        {
            if (inputString != "")
                return Convert.ToInt32(inputString);
            else
                return 0;
        }

        public decimal ToDecimal(string inputString)
        {
            if (inputString != "")
                return Convert.ToDecimal(inputString);
            else
                return 0;
        }

        public bool ToBoolean(string inputString)
        {
            if (inputString != "")
                return Convert.ToBoolean(inputString);
            else
                return false;
        }

        public string RemoveSpaceAfter(string inputString)
        {
            string _outString = string.Empty;

            try
            {
                string[] Split = inputString.Split(new Char[] { ' ' });

                for (int i = 0; i < Split.Length; i++)
                {
                    _outString += Convert.ToString(Split[i]);
                }
                return _outString;
            }
            catch { return _outString; }
        }

        public DateTime _dt(string _txtDate)
        {
            try { return Convert.ToDateTime(_txtDate); }
            catch { return Convert.ToDateTime("1/1/1900"); }
        }

        public string cProperCase(string text)
        {
            TextInfo myTI = new CultureInfo("en-US", false).TextInfo;
            return myTI.ToTitleCase(text.ToLower());
        }

        public bool Validate_Access(bool _sessionState)
        {
            if (_sessionState == true) { return true; }
            else { return false; }
        }

        public bool Load_CheckBox(string _bool)
        {
            if (_bool == "True") { return true; }
            else { return false; }
        }

        public void DeserializeDataTable(string _json, GridView _gv)
        {
            var table = JsonConvert.DeserializeObject<DataTable>(_json);

            _gv.DataSource = table;
            _gv.DataBind();
        }

        public void DeserializeDropDownList(string _json, string DataTextField, string DataValueField, DropDownList _ddl)
        {
            var table = JsonConvert.DeserializeObject<DataTable>(_json);

            try
            {
                _ddl.DataSource = table;
                _ddl.DataTextField = DataTextField;
                _ddl.DataValueField = DataValueField;
                _ddl.DataBind();
                _ddl.Items.Insert(0, new ListItem("Select", "0"));
            }
            catch (Exception ex) { throw ex; }
        }
    }
}