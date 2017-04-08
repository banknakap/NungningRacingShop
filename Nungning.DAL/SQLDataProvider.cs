using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Nungning.BLL.Provider;
using Microsoft.ApplicationBlocks.Data;

namespace Nungning.DAL
{
    /// <summary>
    /// Implementation of <see cref="DataProvider"/> interface.
    /// </summary>
    public class SQLDataProvider : DataProvider
    {
        #region Core
        /// <summary>
        /// Store procedure prefix.
        /// </summary>
        private const string ModuleQualifier = "";

        /// <summary>
        /// Gets or sets sql connection string.
        /// </summary>
        private string ConnectionString { get; set; }

        /// <summary>
        /// Gets or sets sql database owner.
        /// </summary>
        private string DatabaseOwner { get; set; }

        /// <summary>
        /// Gets or sets sql object qualifier.
        /// </summary>
        private string ObjectQualifier { get; set; }

        /// <summary>
        /// Return default value of null data type.
        /// </summary>
        /// <param name="value">Value to check.</param>
        /// <returns>Default null value.</returns>
        private object GetNull(object value)
        {
            if (value == null) return DBNull.Value;
            switch (value.GetType().FullName)
            {
                case "System.Int16":
                    if (Convert.ToInt16(value) != Int16.MinValue)
                    {
                        return value;
                    }
                    break;

                case "System.Int32":
                    if (Convert.ToInt32(value) != Int32.MinValue)
                    {
                        return value;
                    }
                    break;

                case "System.Int64":
                    if (Convert.ToInt64(value) != Int64.MinValue)
                    {
                        return value;
                    }
                    break;

                case "System.Single":
                    if (Convert.ToSingle(value) != Single.MinValue)
                    {
                        return value;
                    }
                    break;

                case "System.Double":
                    if (Convert.ToDouble(value) != Double.MinValue)
                    {
                        return value;
                    }
                    break;

                case "System.Decimal":
                    if (Convert.ToDecimal(value) != Decimal.MinValue)
                    {
                        return value;
                    }
                    break;

                case "System.DateTime":
                    if (Convert.ToDateTime(value) != DateTime.MinValue)
                    {
                        return value;
                    }
                    break;

                case "System.String":
                    if (!String.IsNullOrEmpty(Convert.ToString(value)))
                    {
                        return value;
                    }
                    break;

                default:
                    return value;
            }

            return DBNull.Value;
        }

        /// <summary>
        /// Retrieve database setting from config file.
        /// </summary>
        public SQLDataProvider()
        {
            ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString;
            DatabaseOwner = System.Configuration.ConfigurationManager.AppSettings["DatabaseOwner"] ?? "dbo";
            ObjectQualifier = System.Configuration.ConfigurationManager.AppSettings["ObjectQualifier"] ?? ".";
        }

        /// <summary>
        /// Retrieve full qualifier of store procedure.
        /// </summary>
        /// <param name="name">Short store procedure's name.</param>
        /// <returns>Full store procedure's name.</returns>
        private string GetFullyQualifiedName(string name)
        {
            return DatabaseOwner + ObjectQualifier + ModuleQualifier + name;
        }

        #endregion

        #region user
        public override IDataReader GetUserByLogin(string user_name, string password)
        {
            return SqlHelper.ExecuteReader(ConnectionString, GetFullyQualifiedName("usp_User_GetUserByLogin"),GetNull(user_name),GetNull(password));
        }
        #endregion



    }
}
