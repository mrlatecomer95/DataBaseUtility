using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DatabaseFactory
{
    interface IDataBaseItems
    {
        void SetConnection(String ConnectionString);
        string GetConnection();
        DataTable CreateTable(String SqlQuery);
        bool RunSql(string SqlQuery);
        bool RunSql(string SqlQuery, IDataParameter[] SqlParams);
        //int DLookUp(string category, string DomainName, int DefaultValue = 0, string Criteria = "");
        //bool DLookUp(string category, string DomainName, bool DefaultValue = false, string Criteria = "");
        //double DLookUp(string category, string DomainName, double DefaultValue = 0, string Criteria = "");
    }

    public abstract class DataBaseClass : IDataBaseItems
    {
        public abstract bool TestConnection();
        public abstract void SetConnection(string ConnectionString);
        public abstract string GetConnection();
        public abstract DataTable CreateTable(String SqlQuery);
        public abstract bool RunSql(string SqlQuery);
        public abstract bool RunSql(string SqlQuery, IDataParameter[] SqlParams);

        public abstract int DLookUp(string category, string DomainName, int DefaultValue = 0, string Criteria = "");
        public abstract bool DLookUp(string category, string DomainName, bool DefaultValue = false, string Criteria = "");
        public abstract string DLookUp(string category, string DomainName, string DefaultValue = "" , string Criteria = "");
        public abstract double DLookUp(string category, string DomainName, double DefaultValue = 0, string Criteria = "");
    }

}
