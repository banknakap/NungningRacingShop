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
        public override IDataReader GetUser(string user_infoid)
        {
            return SqlHelper.ExecuteReader(ConnectionString, GetFullyQualifiedName("usp_User_GetUser"), GetNull(user_infoid));
        }
        public override IDataReader SearchUser(string user_name, string first_name)
        {
            return SqlHelper.ExecuteReader(ConnectionString, GetFullyQualifiedName("usp_User_SearchUser"), GetNull(user_name), GetNull(first_name));
        }
        public override IDataReader AddUser(UserInfo user)
        {
            return SqlHelper.ExecuteReader(ConnectionString, GetFullyQualifiedName("usp_User_AddUser")
                , GetNull(user.user_name)
                , GetNull(user.password)
                , GetNull(user.user_type)
                , GetNull(user.first_name)
                , GetNull(user.last_name)
                , GetNull(user.email)
                , GetNull(user.gender)
                , GetNull(user.address)
                , GetNull(user.create_date)
                , GetNull(user.create_by)
                , GetNull(user.lastupdate_date)
                , GetNull(user.lastupdate_by)
                );
        }

        public override IDataReader SetUser(UserInfo user)
        {
            return SqlHelper.ExecuteReader(ConnectionString, GetFullyQualifiedName("usp_User_SetUser")
                , GetNull(user.user_infoid)
                , GetNull(user.user_name)
                , GetNull(user.password)
                , GetNull(user.user_type)
                , GetNull(user.first_name)
                , GetNull(user.last_name)
                  , GetNull(user.email)
                , GetNull(user.gender)
                , GetNull(user.address)
                , GetNull(user.lastupdate_date)
                , GetNull(user.lastupdate_by)
                , GetNull(user.is_del)
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
        public override IDataReader SearchProduct(ProductInfo pro)
        {
            return SqlHelper.ExecuteReader(ConnectionString, GetFullyQualifiedName("usp_Product_SearchProduct")
                , GetNull(pro.product_id)
                , GetNull(pro.product_category_id)
                , GetNull(pro.title)
                );
        }
        public override IDataReader SearchProductCategory(ProductCategoryInfo proc)
        {
            return SqlHelper.ExecuteReader(ConnectionString, GetFullyQualifiedName("usp_Product_SearchProductCategory")
                , GetNull(proc.product_category_id)
                , GetNull(proc.title)
                );
        }



        #endregion

        #region Bill
        public override IDataReader AddBill(string user_infoid, float total_price, string address, string create_by)
        {
            return SqlHelper.ExecuteReader(ConnectionString, GetFullyQualifiedName("usp_Bill_AddBill")
                , GetNull(user_infoid)
                , GetNull(total_price)
                , GetNull(address)
                , GetNull(create_by)
                );
        }

        public override IDataReader AddBillDetail(string bill_id, string product_id, int amount, float sum_price, string create_by)
        {
            return SqlHelper.ExecuteReader(ConnectionString, GetFullyQualifiedName("usp_Bill_AddBillDetail")
                , GetNull(bill_id)
                , GetNull(product_id)
                , GetNull(amount)
                , GetNull(sum_price)
                , GetNull(create_by)
                );
        }
        public override IDataReader GetBill(string bill_id, string user_infoid)
        {
            return SqlHelper.ExecuteReader(ConnectionString, GetFullyQualifiedName("usp_Bill_GetBill")
                , GetNull(bill_id)
                , GetNull(user_infoid)
                );
        }

        public override IDataReader GetBillDetail(string bill_detail_id, string bill_id)
        {
            return SqlHelper.ExecuteReader(ConnectionString, GetFullyQualifiedName("usp_Bill_GetBillDetail")
                , GetNull(bill_detail_id)
                , GetNull(bill_id)
                );
        }



        #endregion

        #region Notice
        public override IDataReader GetNotice(string notice_id)
        {
            return SqlHelper.ExecuteReader(ConnectionString, GetFullyQualifiedName("usp_Notice_GetNotice")
                , GetNull(notice_id)
                );
        }
        public override IDataReader AddNotice(NoticeInfo notice)
        {
            return SqlHelper.ExecuteReader(ConnectionString, GetFullyQualifiedName("usp_Notice_AddNotice")
                , GetNull(notice.title)
                , GetNull(notice.description)
                , GetNull(notice.image)
                , GetNull(notice.url)
                , GetNull(notice.display_sort)
                , GetNull(notice.create_by)
                , GetNull(notice.lastupdate_by)
                , GetNull(notice.is_del)
                , GetNull(notice.link_page)
                , GetNull(notice.link_param)

                );
        }
        public override IDataReader SetNotice(NoticeInfo notice)
        {
            return SqlHelper.ExecuteReader(ConnectionString, GetFullyQualifiedName("usp_Notice_SetNotice")
                , GetNull(notice.notice_id)
                , GetNull(notice.title)
                , GetNull(notice.description)
                , GetNull(notice.image)
                , GetNull(notice.url)
                , GetNull(notice.display_sort)
                , GetNull(notice.create_by)
                , GetNull(notice.lastupdate_by)
                , GetNull(notice.is_del)
                , GetNull(notice.link_page)
                , GetNull(notice.link_param)
                );
        }
        public override IDataReader SearchNotice(string notice_id, string title)
        {
            return SqlHelper.ExecuteReader(ConnectionString, GetFullyQualifiedName("usp_Notice_SearchNotice")
                , GetNull(notice_id)
                , GetNull(title)
                );
        }

        #endregion

        #region Webboard
        public override IDataReader AddComment(CommentInfo comment)
        {
            return SqlHelper.ExecuteReader(ConnectionString, GetFullyQualifiedName("usp_Webboard_AddComment")
               , GetNull(comment.topic_id)
               , GetNull(comment.description)
               , GetNull(comment.create_by)
               );
        }

        public override IDataReader AddTopic(TopicInfo topic)
        {
            return SqlHelper.ExecuteReader(ConnectionString, GetFullyQualifiedName("usp_Webboard_AddTopic")
               , GetNull(topic.title)
               , GetNull(topic.description)
               , GetNull(topic.create_by)
               );
        }

        public override IDataReader GetComment(string comment_id, string topic_id)
        {
            return SqlHelper.ExecuteReader(ConnectionString, GetFullyQualifiedName("usp_Webboard_GetComment")
                , GetNull(comment_id)
                , GetNull(topic_id)
                );
        }
        public override IDataReader GetTopic(string topic_id)
        {
            return SqlHelper.ExecuteReader(ConnectionString, GetFullyQualifiedName("usp_Webboard_GetTopic")
                , GetNull(topic_id)
                );
        }
        public override IDataReader SetComment(CommentInfo comment)
        {
            return SqlHelper.ExecuteReader(ConnectionString, GetFullyQualifiedName("usp_Webboard_SetComment")
                , GetNull(comment.comment_id)
                , GetNull(comment.description)
                , GetNull(comment.lastupdate_by)
                , GetNull(comment.is_del)
                );
        }
        public override IDataReader SetTopic(TopicInfo topic)
        {
            return SqlHelper.ExecuteReader(ConnectionString, GetFullyQualifiedName("usp_Webboard_SetTopic")
              , GetNull(topic.topic_id)
              , GetNull(topic.title)
              , GetNull(topic.display_sort)
              , GetNull(topic.is_top)
              , GetNull(topic.read_count)
              , GetNull(topic.description)
              , GetNull(topic.lastupdate_by)
              , GetNull(topic.is_del)
              );
        }

        public override IDataReader SearchTopic(string title)
        {
            return SqlHelper.ExecuteReader(ConnectionString, GetFullyQualifiedName("usp_Webboard_SearchTopic")
              , GetNull(title)
              );
        }

        #endregion

        public override IDataReader GetLinkPage(string link_page)
        {
            return SqlHelper.ExecuteReader(ConnectionString, GetFullyQualifiedName("usp_LinkPage_GetLinkPage")
                , GetNull(link_page)
                );
        }

        #region Promotion

        public override IDataReader GetPromotion(string promotion_id)
        {
            return SqlHelper.ExecuteReader(ConnectionString, GetFullyQualifiedName("usp_Promotion_GetPromotion")
              , GetNull(promotion_id)
              );
        }
        public override IDataReader AddPromotion(PromotionInfo promotion)
        {
            return SqlHelper.ExecuteReader(ConnectionString, GetFullyQualifiedName("usp_Promotion_AddPromotion")
            , GetNull(promotion.promotion_code)
            , GetNull(promotion.promotion_type)
            , GetNull(promotion.discount_percent)
            , GetNull(promotion.discount_value)
            , GetNull(promotion.free_product_id)
            , GetNull(promotion.free_amount)
            , GetNull(promotion.create_by)
            , GetNull(promotion.title)
            , GetNull(promotion.description)
            , GetNull(promotion.image)
            );
        }
        public override IDataReader SetPromotion(PromotionInfo promotion)
        {
            return SqlHelper.ExecuteReader(ConnectionString, GetFullyQualifiedName("usp_Promotion_SetPromotion")
            , GetNull(promotion.promotion_id)
            , GetNull(promotion.promotion_code)
            , GetNull(promotion.promotion_type)
            , GetNull(promotion.discount_percent)
            , GetNull(promotion.discount_value)
            , GetNull(promotion.free_product_id)
            , GetNull(promotion.free_amount)
            , GetNull(promotion.lastupdate_by)
            , GetNull(promotion.title)
            , GetNull(promotion.description)
            , GetNull(promotion.image)
            , GetNull(promotion.is_del)
            );
        }
        public override IDataReader SearchPromotion(string promotion_id, string title)
        {
            return SqlHelper.ExecuteReader(ConnectionString, GetFullyQualifiedName("usp_Promotion_SearchPromotion")
             , GetNull(promotion_id)
              , GetNull(title)
             );
        }

        #endregion
    }
}
