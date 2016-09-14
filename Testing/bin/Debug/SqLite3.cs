using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace DatabaseFactory
{
    public class SqLite3 : DataBaseClass
    {
        //SQLiteConnection sqlConn = new SQLiteConnection();
        SQLiteConnection sqlConn;
        string strConn = "";
        public SqLite3(string ConnectionString)
        {
            strConn = ConnectionString;
            sqlConn = new SQLiteConnection(ConnectionString, true);
        }

        public override bool TestConnection()
        {
            bool retVal = false;
            try
            {
                sqlConn.Open();
                retVal = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //throw;
                retVal = false;
            }
            finally
            {
                if (sqlConn.State == ConnectionState.Open) sqlConn.Close();
            }
            return retVal;
        }

        public override void SetConnection(string ConnectionString)
        {
            strConn = ConnectionString;
            sqlConn = new SQLiteConnection(ConnectionString);
        }

        public override string GetConnection()
        {
            return strConn.ToString();
        }

        public override System.Data.DataTable CreateTable(string SqlQuery)
        {
            DataTable cTable = new DataTable();

            try
            {
                sqlConn.Open();
                //throw new NotImplementedException();
                using (SQLiteCommand cmd = new SQLiteCommand())
                {
                    cmd.Connection = sqlConn;
                    cmd.CommandText = SqlQuery;
                    using (SQLiteDataAdapter adp = new SQLiteDataAdapter(cmd))
                    {
                        adp.Fill(cTable);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                if (sqlConn.State == ConnectionState.Open) sqlConn.Close();
            }

            return cTable;

        }

        public override bool RunSql(string SqlQuery)
        {
            //throw new NotImplementedException();
            bool retval = false;
            try
            {
                sqlConn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand())
                {
                    cmd.Connection = sqlConn;
                    cmd.CommandText = SqlQuery;
                    retval = (cmd.ExecuteNonQuery() > 0);
                }

            }
            catch (Exception ex)
            {
                retval = false;
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                if (sqlConn.State == ConnectionState.Open) sqlConn.Close();
            }
            return retval;
        }

        public override bool RunSql(string SqlQuery, IDataParameter[] SqlParams)
        {
            //throw new NotImplementedException();
            bool retVal = false;
            try
            {
                sqlConn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand())
                {
                    cmd.Connection = sqlConn;
                    cmd.CommandText = SqlQuery;
                    cmd.Parameters.AddRange(SqlParams);
                    retVal = (cmd.ExecuteNonQuery() > 0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //throw;
            }
            finally
            {
                if (sqlConn.State == ConnectionState.Open) sqlConn.Close();
            }
            return retVal;
        }

        public override bool DLookUp(string category, string DomainName, bool DefaultValue = false, string Criteria = "")
        {
            throw new NotImplementedException();
        }
        public override double DLookUp(string category, string DomainName, double DefaultValue = 0, string Criteria = "")
        {
            throw new NotImplementedException();
        }
        public override int DLookUp(string category, string DomainName, int DefaultValue = 0, string Criteria = "")
        {
            throw new NotImplementedException();
        }
        public override string DLookUp(string category, string DomainName, string DefaultValue = "", string Criteria = "")
        {
            throw new NotImplementedException();
        }
    }
}
