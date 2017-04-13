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

        #endregion

        #region Product
        public abstract IDataReader AddProduct(ProductInfo pro);
        public abstract IDataReader AddProductImage(ProductImageInfo proimage);
        public abstract IDataReader AddProductCategory(ProductCategoryInfo pcate);
        public abstract IDataReader GetProduct(string product_id, string product_category_id);
        public abstract IDataReader GetProductImage(string product_id);
        public abstract IDataReader GetProductCategory(string product_category_id);
        public abstract IDataReader SetProduct(ProductInfo pro);
        public abstract IDataReader SetProductCategory(ProductCategoryInfo pcate);
        public abstract IDataReader SetProductImage(ProductImageInfo proimage);
        #endregion

    }
}
