using Nungning.BLL.Info;
using Nungning.BLL.Provider;
using NungningUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nungning.BLL.Controller
{
    public class ProductController
    {
        public static ProductInfo AddProduct(ProductInfo pro)
        {
            return CBO.FillObject<ProductInfo>(DataProvider.Instance().AddProduct(pro));
        }
        public static ProductCategoryInfo AddProductCategory(ProductCategoryInfo procate)
        {
            return CBO.FillObject<ProductCategoryInfo>(DataProvider.Instance().AddProductCategory(procate));
        }
        public static List<ProductCategoryInfo> GetProductCategory(string product_category_id)
        {
            return CBO.FillCollection<ProductCategoryInfo>(DataProvider.Instance().GetProductCategory(product_category_id));
        }
    }
}
