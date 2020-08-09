using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Text;

namespace iSele.QOnT2SQL
{
    class OdbcRepository
    {
        private readonly string connectionString;

        public OdbcRepository(string ConnectionString)
        {
            connectionString = ConnectionString;
        }
        public List<OdbcData> Get(string queryString)
        {
            List<OdbcData> _data = new List<OdbcData>();
            using (OdbcConnection _conn = new OdbcConnection(connectionString))
            {
                try
                {
                    _conn.Open();
                    OdbcTransaction _myTrans = _conn.BeginTransaction();
                    try
                    {
                        OdbcCommand _command = new OdbcCommand(queryString, _conn, _myTrans);
                        OdbcDataReader _OdbcReader = _command.ExecuteReader();

                        int i = 0;
                        while (_OdbcReader.Read())
                        {
                            _data.Add(new OdbcData { DataTypeName = _OdbcReader.GetDataTypeName(i), DataTypeValue = _OdbcReader.GetValue(i).ToString() });
                            i++;
                        }

                        _myTrans.Commit();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error! " + ex.Message);
                       
                        _myTrans.Rollback();
                        _data = null;
                    }
                    finally
                    {
                        _conn.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Can not open connection ! " + ex.Message);
                }
            }
            return _data;
        }
    }
}
