using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Runtime.CompilerServices;


namespace NungningUtility
{

    public class SqlHelper
    {
        [DebuggerNonUserCode]
        public SqlHelper()
        {
        }

        public static string concatParam(object Param)
        {
            string str = "";
            int num1 = Information.LBound((Array)Param, 1);
            int num2 = Information.UBound((Array)Param, 1);
            int num3 = num1;
            while (num3 <= num2)
            {
                if (num3 > 0)
                    str += ", ";
                string name = NewLateBinding.LateIndexGet(Param, new object[1]
                {
          (object) num3
                }, (string[])null).GetType().Name;
                if (Operators.CompareString(name, "String", false) == 0)
                    str = str + " N'" + NewLateBinding.LateIndexGet(Param, new object[1]
                    {
            (object) num3
                    }, (string[])null).ToString() + "'";
                else if (Operators.CompareString(name, "Integer", false) == 0)
                    str = str + " " + NewLateBinding.LateIndexGet(Param, new object[1]
                    {
            (object) num3
                    }, (string[])null).ToString();
                else if (Operators.CompareString(name, "Double", false) == 0)
                    str = str + " " + NewLateBinding.LateIndexGet(Param, new object[1]
                    {
            (object) num3
                    }, (string[])null).ToString();
                else if (Operators.CompareString(name, "Boolean", false) == 0)
                    str = str + " " + NewLateBinding.LateIndexGet(Param, new object[1]
                    {
            (object) num3
                    }, (string[])null).ToString();
                else if (Operators.CompareString(name, "DateTime", false) == 0)
                    str = str + " N'" + NewLateBinding.LateIndexGet(Param, new object[1]
                    {
            (object) num3
                    }, (string[])null).ToString() + "'";
                else
                    str = str + " " + NewLateBinding.LateIndexGet(Param, new object[1]
                    {
            (object) num3
                    }, (string[])null).ToString();
                checked { ++num3; }
            }
            return str;
        }

        public static SqlDataReader ExecuteReader(string ConnectionString, string CommandText, params object[] Param)
        {
            SqlCommand sqlCommand = new SqlCommand();
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "exec " + CommandText;
            sqlCommand.CommandText = sqlCommand.CommandText + SqlHelper.concatParam((object)Param);
            sqlConnection.Open();
            return sqlCommand.ExecuteReader();
        }

        public static void ExecuteNonQuery(string ConnectionString, string CommandText, params object[] Param)
        {
            SqlCommand sqlCommand = new SqlCommand();
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "exec " + CommandText;
            sqlCommand.CommandText = sqlCommand.CommandText + SqlHelper.concatParam((object)Param);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlCommand.Dispose();
            sqlConnection.Close();
        }

        public static object ExecuteScalar(string ConnectionString, string CommandText, params object[] Param)
        {
            SqlCommand sqlCommand = new SqlCommand();
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "exec " + CommandText;
            sqlCommand.CommandText = sqlCommand.CommandText + SqlHelper.concatParam((object)Param);
            sqlConnection.Open();
            object objectValue = RuntimeHelpers.GetObjectValue(sqlCommand.ExecuteScalar());
            sqlCommand.Dispose();
            sqlConnection.Close();
            return objectValue;
        }
    }

}
