using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tonsbergWebService
{
    public class Global
    {
        public string _SetDate(string _DateGiven)
        {
            string _Date;
            try
            {
                _Date = _DateGiven.Substring(0, _DateGiven.IndexOf(" "));
                if (_Date.Length != 10) { _Date = "0" + _Date; }
            }
            catch { _Date = ""; }

            return _Date;
        }

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
    }
}