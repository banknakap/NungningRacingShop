using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Nungning.BLL.Provider;
using Microsoft.ApplicationBlocks.Data;
using Nungning.BLL.Info;

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
            return SqlHelper.ExecuteReader(ConnectionString, GetFullyQualifiedName("usp_User_GetUserByLogin"), GetNull(user_name), GetNull(password));
        }
        public override IDataReader AddUser(UserInfo user)
        {
            return SqlHelper.ExecuteReader(ConnectionString, GetFullyQualifiedName("usp_User_AddUser")
                , GetNull(user.user_name)
                , GetNull(user.password)
                , GetNull(user.user_type)
                , GetNull(user.first_name)
                , GetNull(user.last_name)
                , GetNull(user.gender)
                , GetNull(user.address)
                , GetNull(user.create_date)
                , GetNull(user.create_by)
                , GetNull(user.lastupdate_date)
                , GetNull(user.lastupdate_by)
                );
        }


        #endregion

        #region product
        public override IDataReader AddProduct(ProductInfo pro)
        {
            return SqlHelper.ExecuteReader(ConnectionString, GetFullyQualifiedName("usp_Product_AddProduct")
                , GetNull(pro.title)
                , GetNull(pro.description)
                , GetNull(pro.product_category_id)
                , GetNull(pro.price)
                , GetNull(pro.amount)
                , GetNull(pro.create_by)
                );
        }

        public override IDataReader AddProductImage(ProductImageInfo proimage)
        {
            return SqlHelper.ExecuteReader(ConnectionString, GetFullyQualifiedName("usp_Product_AddProductImage")
                , GetNull(proimage.product_id)
                , GetNull(proimage.image)
                , GetNull(proimage.create_by)
                );
        }


        public override IDataReader AddProductCategory(ProductCategoryInfo pcate)
        {
            return SqlHelper.ExecuteReader(ConnectionString, GetFullyQualifiedName("usp_Product_AddProductCategory")
                , GetNull(pcate.title)
                , GetNull(pcate.description)
                , GetNull(pcate.create_by)
                );
        }
        public override IDataReader GetProduct(string product_id, string product_category_id)
        {
            return SqlHelper.ExecuteReader(ConnectionString, GetFullyQualifiedName("usp_Product_GetProduct")
                , GetNull(product_id)
                , GetNull(product_category_id)
                );
        }
        public override IDataReader GetProductImage(string image_id, string product_id)
        {
            return SqlHelper.ExecuteReader(ConnectionString, GetFullyQualifiedName("usp_Product_GetProductImage")
                , GetNull(image_id)
                , GetNull(product_id)
                );
        }

        public override IDataReader GetProductCategory(string product_category_id)
        {
            return SqlHelper.ExecuteReader(ConnectionString, GetFullyQualifiedName("usp_Product_GetProductCategory")
                , GetNull(product_category_id)
                );
        }

    

        public override IDataReader SetProduct(ProductInfo pro)
        {
            return SqlHelper.ExecuteReader(ConnectionString, GetFullyQualifiedName("usp_Product_SetProduct")
                , GetNull(pro.product_id)
                , GetNull(pro.title)
                , GetNull(pro.description)
                , GetNull(pro.product_category_id)
                , GetNull(pro.price)
                , GetNull(pro.amount)
                , GetNull(pro.display_sort)
                , GetNull(pro.lastupdate_by)
                , GetNull(pro.is_del)
                );
        }

        public override IDataReader SetProductCategory(ProductCategoryInfo pcate)
        {
            return SqlHelper.ExecuteReader(ConnectionString, GetFullyQualifiedName("usp_Product_SetProductCategory")
                , GetNull(pcate.product_category_id)
                , GetNull(pcate.title)
                , GetNull(pcate.description)
                , GetNull(pcate.display_sort)
                , GetNull(pcate.lastupdate_by)
                , GetNull(pcate.is_del)
                );
        }

        public override IDataReader SetProductImage(ProductImageInfo proimage)
        {
            return SqlHelper.ExecuteReader(ConnectionString, GetFullyQualifiedName("usp_Product_SetProductImage")
                , GetNull(proimage.image_id)
                , GetNull(proimage.product_id)
                , GetNull(proimage.image)
                , GetNull(proimage.display_sort)
                , GetNull(proimage.lastupdate_by)
                , GetNull(proimage.is_del)
                );
        }


        #endregion




    }
}
