using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.Odbc;

namespace QOnT.Models
{
    public class OrderTbl
    {
        const string CONST_CONSTRING = "Tracker08ConnectionString";
        const string CONST_ORDERSHEADER_SELECT = "SELECT CustomersTbl.CompanyName, OrdersTbl.CustomerId As CustId, OrdersTbl.OrderDate, OrdersTbl.RoastDate, " +
                                                 " OrdersTbl.RequiredByDate, PersonsTbl.Abreviation, PersonsTbl.PersonID,  OrdersTbl.Confirmed, OrdersTbl.Done, OrdersTbl.Notes " +
                                                 " FROM ((OrdersTbl LEFT OUTER JOIN PersonsTbl ON OrdersTbl.ToBeDeliveredBy = PersonsTbl.PersonID)" +
                                                 " LEFT OUTER JOIN CustomersTbl ON OrdersTbl.CustomerId = CustomersTbl.CustomerID)" +
                                                 " WHERE ([CustomerId] = ?) AND ([RoastDate] = ?)";
        const string CONST_ORDERSLINES_SELECT = "SELECT ItemTypeID, QuantityOrdered, PrepTypeID FROM OrdersTbl WHERE ([OrdersTbl.CustomerId] = ?) AND ([RoastDate] = ?)";
        // connection String
        //private string _connectionString;

        public OrderTbl()
        {
            Initialize();
        }
        public void Initialize()
        {
            // Initialize data source. Use "Tracker08" connection string from configuration.

            //if (ConfigurationManager.ConnectionStrings[CONST_CONSTRING] == null ||
            //    ConfigurationManager.ConnectionStrings[CONST_CONSTRING].ConnectionString.Trim() == "")
            //{
            //  throw new Exception("A connection string named " + CONST_CONSTRING + " with a valid connection string " +
            //                      "must exist in the <connectionStrings> configuration section for the application.");
            //}
            //_connectionString =
            //  ConfigurationManager.ConnectionStrings[CONST_CONSTRING].ConnectionString;
        }

        public List<OrderHeaderData> LoadOrderHeader(Int32 pCustomerID, DateTime pPrepDate)
        {
            List<OrderHeaderData> _OrderHeaders = new List<OrderHeaderData>();
            TrackerDb _TDB = new TrackerDb();

            string _sqlCmd = CONST_ORDERSHEADER_SELECT;
            //OleDbConnection _conn = new OleDbConnection(_connectionString);

            //OleDbCommand _cmd = new OleDbCommand(_sqlCmd, _conn);
            //_cmd.Parameters.Add(new OleDbParameter { Value = pCustomerID });
            //_cmd.Parameters.Add(new OleDbParameter { Value = pPrepDate } );

            _TDB.AddWhereParams(pCustomerID, DbType.Int32);
            _TDB.AddWhereParams(pPrepDate, DbType.Date);

            //_conn.Open();
            //OleDbDataReader objReader = _cmd.ExecuteReader();

            IDataReader _DataReader = _TDB.ExecuteSQLGetDataReader(_sqlCmd);

            while (_DataReader.Read())
            {
                OrderHeaderData _OrderHeader = new OrderHeaderData();

                _OrderHeader.CustomerID = (_DataReader["CustID"] == DBNull.Value) ? 0 : Convert.ToInt32(_DataReader["CustID"]);
//                _DataItem.MachineConditionID = (_DataReader["MachineConditionID"] == DBNull.Value) ? 0 : Convert.ToInt32(_DataReader["MachineConditionID"]);

                //        ohDetail.CompanyName = (string)objReader["CompanyName"];
                //        ohDetail.Abreviation = (string)objReader["Abreviation "];
                _OrderHeader.ToBeDeliveredBy = (_DataReader["PersonsID"] == DBNull.Value) ? TrackerTools.CONST_DEFAULT_DELIVERYBYID : Convert.ToInt32(_DataReader["PersonsID"]);
                _OrderHeader.Notes = (_DataReader["Notes"] == DBNull.Value) ? string.Empty : (string)_DataReader["Notes"];
                _OrderHeader.OrderDate = (_DataReader["OrderDate"] == DBNull.Value) ? DateTime.Now :  (DateTime)_DataReader["OrderDate"];
                _OrderHeader.RoastDate = (_DataReader["RoastDate"] == DBNull.Value) ? DateTime.Now : (DateTime)_DataReader["RoastDate"];
                _OrderHeader.RequiredByDate = (_DataReader["RequiredByDate"] == DBNull.Value) ? DateTime.Now : (DateTime)_DataReader["RequiredByDate"];
                _OrderHeader.Confirmed = (_DataReader["Confirmed"] == DBNull.Value) ? false : (bool)_DataReader["Confirmed"];
                _OrderHeader.Done = (_DataReader["Done"] == DBNull.Value) ? true : (bool)_DataReader["Done"];
                
                _OrderHeaders.Add(_OrderHeader);
            }
            _DataReader.Close();
            _TDB.Close();

            return _OrderHeaders;
        }

        internal void InsertNewOrderLine(OrderCls orderData)
        {
            throw new NotImplementedException();
        }

        internal long GetLastOrderAdded(object customerId, object orderDate, int cONST_SERVICEITEMID)
        {
            throw new NotImplementedException();
        }

        internal void UpdateIncDeliveryDateBy7(long relatedOrderID)
        {
            throw new NotImplementedException();
        }

        internal void UpdateOrderDeliveryDate(object p, long relatedOrderID)
        {
            throw new NotImplementedException();
        }

        internal void UpdateSetDoneByID(bool v, long relatedOrderID)
        {
            throw new NotImplementedException();
        }
    }
}