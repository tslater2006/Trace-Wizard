using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TraceWizard.Data
{
    [Serializable]
    public class SQLStatement
    {
        public static uint NextID;

        public uint InternalID = NextID++;
        public SQLStatement()
        {

        }

        public long LineNumber;
        public double Duration
        {
            get
            {
                return ExecTime + FetchTime;
            }
        }
        public ExecutionCall ParentCall;
        public int FetchCount;
        public string SQLID;
        public string Statement;

        public string WhereClause;
        public string FromClause;
        public double ExecTime;
        public double FetchTime;

        public bool IsError;

        public SQLError ErrorInfo;
        
        public int RCNumber;
        public List<SQLBindValue> BindValues = new List<SQLBindValue>();
        public SQLType Type;

        
        public string Context;

        public SQLStatement(string text)
        {
            Statement = text.Trim();
            DetermineType();
            ParseWhereClause();
            ParseFromClause();
            GenerateSQLID();
        }

        private void GenerateSQLID()
        {

            MD5CryptoServiceProvider hashlib = new MD5CryptoServiceProvider();
            byte[] arrData = null;
            byte[] byteHash = null;
            string sqlid = "";
            const string alphabet = "0123456789abcdfghjkmnpqrstuvwxyz";
            UInt64 MSB = default(UInt64);
            UInt64 LSB = default(UInt64);
            UInt64 sqln = default(UInt64);
            UInt32[] arr3 = {0,0,0,0};
            UInt32[] arr4 = { 0, 0, 0, 0 };
            string sql_text = Statement;

            sql_text = (sql_text + "\0");
            arrData = System.Text.Encoding.ASCII.GetBytes(sql_text);
            byteHash = hashlib.ComputeHash(arrData);
            Buffer.BlockCopy(byteHash, 8, arr3, 0, 4);
            Buffer.BlockCopy(byteHash, 12, arr4, 0, 4);
            MSB = (((arr3[0] | (arr3[1] << 8)) | (arr3[2] << 0x10)) | (arr3[3] << 0x18));
            LSB = (((arr4[0] | (arr4[1] << 8)) | (arr4[2] << 0x10)) | (arr4[3] << 0x18));
            sqln = (MSB << 32) + LSB;
            for (int iCount = 0; iCount <= 12; iCount++)
            {
                sqlid = alphabet[Convert.ToInt32((sqln >> (iCount * 5)) % 32)] + sqlid;
            }
            SQLID = sqlid;
        }
        private void ParseWhereClause()
        {
            Regex whereClause = new Regex(" WHERE (.*?)(ORDER|$)",RegexOptions.IgnoreCase);
            Match m = whereClause.Match(Statement);
            if (m.Success)
            {
                WhereClause = m.Groups[1].Value.Trim();
            } else
            {
                WhereClause = "";
            }
            
        }

        private void ParseFromClause()
        {
            Regex fromClause = new Regex(" FROM (.*?)(WHERE|ORDER|$)",RegexOptions.IgnoreCase);
            FromClause = fromClause.Match(Statement).Groups[1].Value.Trim();
        }

        private void DetermineType()
        {
            if (Statement.StartsWith("SELECT", StringComparison.InvariantCultureIgnoreCase))
            {
                this.Type = SQLType.SELECT;
            }
            if (Statement.StartsWith("UPDATE", StringComparison.InvariantCultureIgnoreCase))
            {
                this.Type = SQLType.UPDATE;
            }
            if (Statement.StartsWith("DELETE", StringComparison.InvariantCultureIgnoreCase))
            {
                this.Type = SQLType.DELETE;
            }
            if (Statement.StartsWith("INSERT", StringComparison.InvariantCultureIgnoreCase))
            {
                this.Type = SQLType.INSERT;
            }
        }

        public override string ToString()
        {
            return Statement;
        }
    }

    [Serializable]
    public class SQLBindValue
    {
        public static uint NextID;

        public uint InternalID = NextID++;
        public int Index;
        public int Type;
        public int Length;
        public string Value;
    }

    [Serializable]
    public enum SQLType
    {
        SELECT,UPDATE,DELETE,INSERT
    }

    [Serializable]
    public class SQLError
    {
        public static uint NextID;

        public uint InternalID = NextID++;
        public int ErrorPosition;
        public int ReturnCode;
        public string Message;

    }
}
