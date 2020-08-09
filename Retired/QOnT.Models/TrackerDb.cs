using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Web;
using System.Configuration;
using System.Data.Common;

//namespace QOnT.classes
namespace QOnT.Models

{
    public class TrackerDb
    {
        public const string CONST_CONSTRING = "Tracker08ConnectionString";
        public const int CONST_INVALIDID = 0;

        private OdbcConnection _TrackerDbConn = null;

        private List<OdbcParameter> _Parameters = null;
        private List<OdbcParameter> _WhereParameters = null;

        public List<OdbcParameter> Params { get { return _Parameters; } set { _Parameters = value; } }
        public List<OdbcParameter> WhereParams { get { return _WhereParameters; } set { _WhereParameters = value; } }


        public OdbcConnection TrackerDbConn
        {
            get { return this._TrackerDbConn; }
        }

        public TrackerDb()
        {
            Initialize();
        }

        private void Initialize()
        {
            if (_TrackerDbConn != null)
            {
                _TrackerDbConn.Dispose();
                _TrackerDbConn = null;
            }

            string _connectionString;

            //if (ConfigurationManager.ConnectionStrings[CONST_CONSTRING] == null ||
            //    ConfigurationManager.ConnectionStrings[CONST_CONSTRING].ConnectionString.Trim() == "")
            //{
            //    throw new Exception("A connection string named " + CONST_CONSTRING + " with a valid connection string " +
            //                        "must exist in the <connectionStrings> configuration section for the application.");
            //}
            _connectionString = @"Driver={Microsoft Access Driver (*.mdb, *.accdb)};DBQ=C:\\Backup\\Databases\\QuaffeeTracker08.mdb";
            this._TrackerDbConn = new OdbcConnection(_connectionString);
        }
        /// <summary>
        /// Execute the SQL statement does not return results, such as: delete, update, insert operation 
        /// </summary>
        /// <param name="strSQL">SQL String of a non Query Type</param>
        /// <returns>success or failure</returns>
        public string ExecuteNonQuerySQL(string strSQL)
        {
            string _resultState = "";

            _TrackerDbConn.Open();
            OdbcTransaction _myTrans = _TrackerDbConn.BeginTransaction();
            OdbcCommand _command = new OdbcCommand(strSQL, _TrackerDbConn, _myTrans);
            try
            {
                if (_Parameters != null)
                {
                    foreach (OdbcParameter param in _Parameters)
                    {
                        _command.Parameters.Add(param);
                    }
                }
                if (_WhereParameters != null)
                {
                    foreach (OdbcParameter param in _WhereParameters)
                    {
                        _command.Parameters.Add(param);
                    }
                }
                _command.ExecuteNonQuery();
                _myTrans.Commit();
                _resultState = "";
            }
            catch (Exception e)
            {
                _myTrans.Rollback();
                _resultState = e.Message;
            }
            finally
            {
                _TrackerDbConn.Close();
            }
            return _resultState;
        }
        internal string ExecuteNonQuerySQLWithParams(string strSQL, List<OdbcParameter> pParams, List<OdbcParameter> pWhereParams)
        {
            _Parameters = pParams;
            _WhereParameters = pWhereParams;
            return ExecuteNonQuerySQL(strSQL);

        }

        public IDataReader ExecuteSQLGetDataReader(string strSQL)
        {
            IDataReader _IDataReader = null;
            //            OdbcDataReader _DBDataReader = null;
            //_TrackerDbConn.Open();
            //OdbcTransaction _myTrans = _TrackerDbConn.BeginTransaction();
            //OdbcCommand _command = new OdbcCommand(strSQL, _TrackerDbConn, _myTrans);
            //try
            //{
            //if (_Parameters != null)
            //{
            //    foreach (OdbcParameter param in _Parameters)
            //    {
            //        _command.Parameters.Add(param);
            //    }
            //}
            //if (_WhereParameters != null)
            //{
            //    foreach (OdbcParameter param in _WhereParameters)
            //    {
            //        _command.Parameters.Add(param);
            //    }
            //}

            //_DBDataReader = _command.ExecuteReader();

            // _DBDataReader = (OdbcDataReader)
            _IDataReader = ReturnIDataReader(strSQL);
            // _IDataReader = _OdbcDataReader;
            //_myTrans.Commit();
            //}
            //catch
            //{
            //    //_myTrans.Rollback();
            //    _DBDataReader = null;
            //}
            //finally
            //{
            //    _TrackerDbConn.Close();
            //}

            return _IDataReader;
        }


        /// <summary>
        /// Execute the SQL statement returns the result to the DataSet
        /// </summary>
        /// <param Name="strSQL"> </ param> 
        /// <returns> DataSet </ returns> 

        public DataSet ReturnDataSet(string strSQL)
        {
            DataSet _DataSet = null;
            try
            {
                _TrackerDbConn.Open();
                _DataSet = new DataSet();
                OdbcDataAdapter _OdbcDA = new OdbcDataAdapter(strSQL, _TrackerDbConn);
                if (_Parameters != null)
                {
                    foreach (OdbcParameter param in _Parameters)
                    {
                        _OdbcDA.SelectCommand.Parameters.Add(param);
                    }
                }
                if (_WhereParameters != null)
                {
                    foreach (OdbcParameter param in _WhereParameters)
                    {
                        _OdbcDA.SelectCommand.Parameters.Add(param);
                    }
                }

                _OdbcDA.Fill(_DataSet, "objDataSet");
                
            }
            catch (OdbcException _ex)
            {
                // Handle exception.
                TrackerTools _Tools = new TrackerTools();
                _Tools.SetTrackerSessionErrorString(_ex.Message);
                if (_DataSet != null)
                    _DataSet.Dispose();
                throw;
            }
            finally
            {
                _TrackerDbConn.Close();
            }

            return _DataSet;
        }

        internal void AddParams(string pStr) { AddParams(pStr, DbType.String, "?"); }
        internal void AddParams(object pObj, DbType pDBType) { AddParams(pObj, pDBType, "?"); }
        internal void AddParams(object pObj, DbType pDBType, string pString)
        {
            if (_Parameters == null)
                _Parameters = new List<OdbcParameter>();

            _Parameters.Add(new OdbcParameter { DbType = pDBType, Value = pObj, ParameterName = pString });
        }
        public void AddWhereParams(object pObj, DbType pDBType)
        {
            AddWhereParams(pObj, pDBType, "?");
            //if (_WhereParameters == null)
            //    _WhereParameters = new List<OdbcParameter>();

            //_WhereParameters.Add(new OdbcParameter { DbType = pDBType, Value = pObj });
        }
        public void AddWhereParams(object pObj, DbType pDBType, string pString)
        {
            if (_WhereParameters == null)
                _WhereParameters = new List<OdbcParameter>();

            _WhereParameters.Add(new OdbcParameter { DbType = pDBType, Value = pObj, ParameterName = pString });
        }

        public OdbcDataReader ReturnDataReader(string strSQL)
        {
            OdbcDataReader _DataReader = null;
            try
            {
                _TrackerDbConn.Open();
                OdbcCommand _cmd = new OdbcCommand(strSQL, TrackerDbConn);
                if (_Parameters != null)
                {
                    foreach (OdbcParameter param in _Parameters)
                    {
                        _cmd.Parameters.Add(param);
                    }
                }
                if (_WhereParameters != null)
                {
                    foreach (OdbcParameter param in _WhereParameters)
                    {
                        _cmd.Parameters.Add(param);
                    }
                }
                //OdbcDataReader odbcDataReader = _cmd.ExecuteReader();

                _DataReader = _cmd.ExecuteReader();
            }
            catch (OdbcException _ex)
            {
                // Handle exception.
                TrackerTools _Tools = new TrackerTools();
                _Tools.SetTrackerSessionErrorString(_ex.Message);
                if (_DataReader != null)
                {
                    _DataReader.Dispose();
                    _DataReader = null;
                }
            }
            finally
            {
                ///
            }
            return _DataReader;
        }
        public IDataReader ReturnIDataReader(string strSQL)
        {
            IDataReader _IDataReader = null;
            try
            {
                _TrackerDbConn.Open();
                OdbcCommand _cmd = new OdbcCommand(strSQL, TrackerDbConn);
                if (_Parameters != null)
                {
                    foreach (OdbcParameter param in _Parameters)
                    {
                        _cmd.Parameters.Add(param);
                    }
                }
                if (_WhereParameters != null)
                {
                    foreach (OdbcParameter param in _WhereParameters)
                    {
                        _cmd.Parameters.Add(param);
                    }
                }
                OdbcDataReader _DataReader = _cmd.ExecuteReader();
                _IDataReader = _DataReader;
            }
            catch (OdbcException _ex)
            {
                // Handle exception.
                TrackerTools _Tools = new TrackerTools();
                _Tools.SetTrackerSessionErrorString(_ex.Message);
                //if (_DataReader != null)
                //{
                //    _DataReader.Dispose();
                //    _DataReader = null;
                //}
            }
            finally
            {
                ///
            }
            return _IDataReader; // _DataReader;
        }
        public void Close()
        {
            if (Params != null)
                Params.Clear();
            if (WhereParams != null)
                WhereParams.Clear();
            TrackerDbConn.Close();
        }

    }
}