using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Nungning.BLL.Info;

namespace Nungning.BLL.Provider
{
    public abstract class DataProvider
    {

        #region "Shared/Static Methods"

        /// <summary>
        /// singleton reference to the instantiated object 
        /// </summary>
        private static DataProvider objProvider = null;

        /// <summary>
        /// constructor
        /// </summary>
        static DataProvider()
        {
            CreateProvider();
        }

        /// <summary>
        /// dynamically create provider 
        /// </summary>
        private static void CreateProvider()
        {
            //if (objProvider == null)
            //{
            //    objProvider = new TMT.Point;
            //}

            Type t = Type.GetType("Nungning.DAL.SQLDataProvider,Nungning.DAL");
            objProvider = (DataProvider)System.Activator.CreateInstance(t
                        , new object[] { },
                        new object[] { }
                    );




        }

        private Type getType(string typeName)
        {
            var type = Type.GetType(typeName);
            if (type != null) return type;
            foreach (var a in AppDomain.CurrentDomain.GetAssemblies())
            {
                type = a.GetType(typeName);
                if (type != null)
                    return type;
            }
            return null;

        }

        /// <summary>
        /// return the provider 
        /// </summary>
        /// <returns></returns>
        public static DataProvider Instance()
        {
            return objProvider;
        }

        #endregion


        #region User
        public abstract IDataReader GetUserByLogin(string user_name, string password);
        public abstract IDataReader AddUser(UserInfo user);
        public abstract IDataReader SetUser(UserInfo user);
        public abstract IDataReader GetUser(string user_infoid);
        public abstract IDataReader SearchUser(string user_name, string first_name);
        #endregion

        #region Product
        public abstract IDataReader AddProduct(ProductInfo pro);
        public abstract IDataReader AddProductImage(ProductImageInfo proimage);
        public abstract IDataReader AddProductCategory(ProductCategoryInfo pcate);
        public abstract IDataReader GetProduct(string product_id, string product_category_id);
        public abstract IDataReader GetProductImage(string image_id, string product_id);
        public abstract IDataReader GetProductCategory(string product_category_id);
        public abstract IDataReader SetProduct(ProductInfo pro);
        public abstract IDataReader SetProductCategory(ProductCategoryInfo pcate);
        public abstract IDataReader SetProductImage(ProductImageInfo proimage);
        public abstract IDataReader SearchProduct(ProductInfo pro);
        public abstract IDataReader SearchProductCategory(ProductCategoryInfo proc);
        #endregion

        #region Bill
        public abstract IDataReader AddBill(string user_infoid,float total_price, string address, string create_by);
        public abstract IDataReader AddBillDetail(string bill_id, string product_id, int amount, float sum_price, string create_by);
        public abstract IDataReader GetBill(string bill_id,string user_infoid);
        public abstract IDataReader GetBillDetail(string bill_detail_id, string bill_id);
        #endregion

        #region Notice

        public abstract IDataReader GetNotice(string notice_id);
        public abstract IDataReader AddNotice(NoticeInfo notice);
        public abstract IDataReader SetNotice(NoticeInfo notice);
        public abstract IDataReader SearchNotice(string notice_id, string title);

        #endregion

        #region Webboard
        public abstract IDataReader AddComment(CommentInfo comment);
        public abstract IDataReader AddTopic(TopicInfo topic);
        public abstract IDataReader GetComment(string comment_id,string topic_id);
        public abstract IDataReader GetTopic(string topic_id);
        public abstract IDataReader SearchTopic(string title);
        public abstract IDataReader SetComment(CommentInfo comment);
        public abstract IDataReader SetTopic(TopicInfo topic);
        #endregion
        public abstract IDataReader GetLinkPage(string link_page);

        #region Promotion
        public abstract IDataReader GetPromotion(string promotion_id);
        public abstract IDataReader AddPromotion(PromotionInfo promotion);
        public abstract IDataReader SetPromotion(PromotionInfo promotion);
        public abstract IDataReader SearchPromotion(string promotion_id, string title);
        #endregion
    }
}
