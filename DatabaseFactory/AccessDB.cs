using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace DatabaseFactory
{
    public class AccessDB : DataBaseClass
    {
        OleDbConnection sqlConn;
        string strConn = "";
        public AccessDB(string ConnectionString)
        {
            strConn = ConnectionString;
            sqlConn = new OleDbConnection(strConn); 
        }

        public override bool TestConnection()
        {
            //throw new NotImplementedException();
            bool retval = false;
            try
            {
                sqlConn.Open();
                retval = true;

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

        public override void SetConnection(string ConnectionString)
        {
            strConn = ConnectionString;
            sqlConn = new OleDbConnection(strConn);
        }

        public override string GetConnection()
        {
            return strConn;
            //throw new NotImplementedException();
        }

        public override DataTable CreateTable(string SqlQuery)
        {
            DataTable ctable = new DataTable();
            try
            {
                sqlConn.Open();
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.Connection = sqlConn;
                    cmd.CommandText = SqlQuery;
                    using (OleDbDataAdapter adp = new OleDbDataAdapter(cmd))
                    {
                        adp.Fill(ctable);
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
            return ctable;
        }

        public override bool RunSql(string SqlQuery)
        {
            bool retval = false;
            try
            {
                sqlConn.Open();
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.Connection = sqlConn;
                    cmd.CommandText = SqlQuery;
                    retval = (cmd.ExecuteNonQuery() > 0 );
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
            return retval;
            //throw new NotImplementedException();
        }

        public override bool RunSql(string SqlQuery, IDataParameter[] SqlParams)
        {
            bool retval = false;
            try
            {
                sqlConn.Open();
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.Connection = sqlConn;
                    cmd.CommandText = SqlQuery;
                    cmd.Parameters.AddRange(SqlParams);
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
            //throw new NotImplementedException();
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
