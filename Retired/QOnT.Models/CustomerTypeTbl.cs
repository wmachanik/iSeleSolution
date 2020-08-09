/// --- auto generated class for table: CustomerTypeTbl
using System;   // for DateTime variables
using System.Collections.Generic;      // for data stuff
using System.Data.Odbc;
using System.Configuration;
using System.Data;

namespace QOnT.Models
{
    public class CustomerTypeTbl
    {
        // internal variable declarations
        private int _CustTypeID;
        private string _CustTypeDesc;
        private string _Notes;

        // class definition
        public CustomerTypeTbl()
        {
            _CustTypeID = 0;
            _CustTypeDesc = string.Empty;
            _Notes = string.Empty;

        }
        // get and sets of public
        public int CustTypeID { get { return _CustTypeID; } set { _CustTypeID = value; } }
        public string CustTypeDesc { get { return _CustTypeDesc; } set { _CustTypeDesc = value; } }
        public string Notes { get { return _Notes; } set { _Notes = value; } }

        #region ConstantDeclarations
        const string CONST_CONSTRING = "Tracker08ConnectionString";
        const string CONST_SQL_SELECT = "SELECT CustTypeID, CustTypeDesc, Notes FROM CustomerTypeTbl";
        #endregion

        public List<CustomerTypeTbl> GetAll(string SortBy)
        {
            List<CustomerTypeTbl> _DataItems = new List<CustomerTypeTbl>();
            //string _connectionStr = ConfigurationManager.ConnectionStrings[QOnT.classes.TrackerDb.CONST_CONSTRING].ConnectionString;
            TrackerDb _TDB = new TrackerDb();

            //using (OdbcConnection _conn = new OdbcConnection(_connectionStr))
            //{
            string _sqlCmd = CONST_SQL_SELECT;
            if (!String.IsNullOrEmpty(SortBy)) _sqlCmd += " ORDER BY " + SortBy;     // Add order by string
                                                                                     //OdbcCommand _cmd = new OdbcCommand(_sqlCmd, _conn);                    // run the qurey we have built
                                                                                     //_conn.Open();
                                                                                     //            OdbcDataReader _DataReader = _TDB.ExecuteSQLGetDataReader(_sqlCmd);
            IDataReader _DataReader = _TDB.ExecuteSQLGetDataReader(_sqlCmd);
            while (_DataReader.Read())
            {
                CustomerTypeTbl _DataItem = new CustomerTypeTbl();

                _DataItem.CustTypeID = (_DataReader["CustTypeID"] == DBNull.Value) ? 0 : Convert.ToInt32(_DataReader["CustTypeID"]);
                _DataItem.CustTypeDesc = (_DataReader["CustTypeDesc"] == DBNull.Value) ? string.Empty : _DataReader["CustTypeDesc"].ToString();
                _DataItem.Notes = (_DataReader["Notes"] == DBNull.Value) ? string.Empty : _DataReader["Notes"].ToString();
                _DataItems.Add(_DataItem);
            }
            //}
            return _DataItems;
        }
    }
}
