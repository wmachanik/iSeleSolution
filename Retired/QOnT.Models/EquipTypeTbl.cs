/// --- auto generated class for table: EquipType
using System;   // for DateTime variables
using System.Collections.Generic;      // for data stuff
using System.Data.Odbc;
using System.Configuration;
using System.Data;

namespace QOnT.Models
{
    public class EquipTypeTbl
    {
        // internal variable declarations
        private int _EquipTypeId;
        private string _EquipTypeName;
        private string _EquipTypeDesc;
        // class definition
        public EquipTypeTbl()
        {
            _EquipTypeId = 0;
            _EquipTypeName = string.Empty;
            _EquipTypeDesc = string.Empty;
        }
        // get and sets of public
        public int EquipTypeId { get { return _EquipTypeId; } set { _EquipTypeId = value; } }
        public string EquipTypeName { get { return _EquipTypeName; } set { _EquipTypeName = value; } }
        public string EquipTypeDesc { get { return _EquipTypeDesc; } set { _EquipTypeDesc = (value == null) ? string.Empty : value; } }

        #region ConstantDeclarations
        const string CONST_SQL_SELECT = "SELECT EquipTypeId, EquipTypeName, EquipTypeDesc FROM EquipTypeTbl";
        const string CONST_SQL_UPDATE = "UPDATE EquipTypeTbl SET EquipTypeName = ?, EquipTypeDesc = ? WHERE EquipTypeId = ?";
        #endregion

        public List<EquipTypeTbl> GetAll(string SortBy)
        {
            List<EquipTypeTbl> _DataItems = new List<EquipTypeTbl>();
            TrackerDb _TrackerDb = new TrackerDb();
            // string _connectionStr = ConfigurationManager.ConnectionStrings[QOnT.classes.TrackerDb.CONST_CONSTRING].ConnectionString;

            string _sqlCmd = CONST_SQL_SELECT;
            _sqlCmd += (!String.IsNullOrEmpty(SortBy)) ? " ORDER BY " + SortBy : " ORDER BY EquipTypeName";   // add default order

            IDataReader _DataReader = _TrackerDb.ExecuteSQLGetDataReader(_sqlCmd);
            while (_DataReader.Read())
            {
                EquipTypeTbl _DataItem = new EquipTypeTbl();

                _DataItem.EquipTypeId = (_DataReader["EquipTypeId"] == DBNull.Value) ? 0 : Convert.ToInt32(_DataReader["EquipTypeId"]);
                _DataItem.EquipTypeName = (_DataReader["EquipTypeName"] == DBNull.Value) ? string.Empty : _DataReader["EquipTypeName"].ToString();
                _DataItem.EquipTypeDesc = (_DataReader["EquipTypeDesc"] == DBNull.Value) ? string.Empty : _DataReader["EquipTypeDesc"].ToString();
                _DataItems.Add(_DataItem);
            }
            return _DataItems;
        }
        public static void UpdateEquipItem(EquipTypeTbl objEquipType)
        {
            //string _connectionStr = ConfigurationManager.ConnectionStrings[QOnT.classes.TrackerDb.CONST_CONSTRING].ConnectionString; ;

            //using (OdbcConnection _conn = new OdbcConnection(_connectionStr))
            //{
            //    string _sqlCmd = CONST_SQL_UPDATE;
            //    OdbcCommand _cmd = new OdbcCommand(_sqlCmd, _conn);                    // prepare the qurey we have built
            //    #region Parameters
            //    //        objEquipType.EquipTypeName = (objEquipType.EquipTypeName == null) ? string.Empty : objEquipType.EquipTypeName;
            //    //        objEquipType.EquipTypeDesc = (objEquipType.EquipTypeDesc == null) ? string.Empty : objEquipType.EquipTypeDesc;
            //    _cmd.Parameters.Add(new OdbcParameter { Value = objEquipType.EquipTypeName });
            //    _cmd.Parameters.Add(new OdbcParameter { Value = objEquipType.EquipTypeDesc });
            //    // Where clause
            //    _cmd.Parameters.Add(new OdbcParameter { Value = objEquipType.EquipTypeId });
            //    #endregion
            //    _conn.Open();
            //    _cmd.ExecuteNonQuery();
            //    _conn.Close();
            //}

        }

    }
}
