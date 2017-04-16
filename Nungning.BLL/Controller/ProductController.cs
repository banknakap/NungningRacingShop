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
        public static ProductImageInfo AddProductImage(string product_id,string image,string create_by)
        {
            ProductImageInfo proimage = new ProductImageInfo();
            proimage.product_id = product_id;
            proimage.image = image;
            proimage.create_by = create_by;
            return CBO.FillObject<ProductImageInfo>(DataProvider.Instance().AddProductImage(proimage));
        }
        public static ProductCategoryInfo AddProductCategory(ProductCategoryInfo procate)
        {
            return CBO.FillObject<ProductCategoryInfo>(DataProvider.Instance().AddProductCategory(procate));
        }
        public static List<ProductCategoryInfo> GetProductCategory(string product_category_id)
        {
            return CBO.FillCollection<ProductCategoryInfo>(DataProvider.Instance().GetProductCategory(product_category_id));
        }

        public static List<ProductInfo> GetProduct(string product_id,string product_category_id)
        {
            return CBO.FillCollection<ProductInfo>(DataProvider.Instance().GetProduct(product_id,product_category_id));
        }

        public static List<ProductInfo> SearchProduct(string product_id, string product_category_id, string title)
        {
            ProductInfo pro = new ProductInfo();
            pro.product_id = product_id;
            pro.product_category_id = product_category_id;
            pro.title = title;
            return CBO.FillCollection<ProductInfo>(DataProvider.Instance().SearchProduct(pro));
        }
        public static List<ProductInfo> SearchProductCategory( string product_category_id, string title)
        {
            ProductCategoryInfo pro = new ProductCategoryInfo();
            pro.product_category_id = product_category_id;
            pro.title = title;
            return CBO.FillCollection<ProductInfo>(DataProvider.Instance().SearchProductCategory(pro));
        }

        public static List<ProductImageInfo> GetProductImage(string image_id,string product_id)
        {
            return CBO.FillCollection<ProductImageInfo>(DataProvider.Instance().GetProductImage(image_id,product_id));
        }
        public static ProductInfo SetProduct(ProductInfo pro)
        {
            return CBO.FillObject<ProductInfo>(DataProvider.Instance().SetProduct(pro));
        }
        public static ProductImageInfo SetProductImage(ProductImageInfo proi)
        {
            return CBO.FillObject<ProductImageInfo>(DataProvider.Instance().SetProductImage(proi));
        }
        public static ProductCategoryInfo SetProductCategory(ProductCategoryInfo proc)
        {
            return CBO.FillObject<ProductCategoryInfo>(DataProvider.Instance().SetProductCategory(proc));
        }

        public static ProductCategoryInfo DelProductCategory(string product_category_id,bool is_del)
        {
            var result = GetProductCategory(product_category_id);
            if (result.Count == 1)
            {
                result[0].is_del = is_del;
                return CBO.FillObject<ProductCategoryInfo>(DataProvider.Instance().SetProductCategory(result[0]));
            }
            else
                return null;
        }

        public static ProductInfo DelProduct(string product_id, bool is_del)
        {
            var result = GetProduct(product_id,null);
            if (result.Count == 1)
            {
                result[0].is_del = is_del;
                return CBO.FillObject<ProductInfo>(DataProvider.Instance().SetProduct(result[0]));
            }
            else
                return null;
        }

        public static ProductImageInfo DelProductImage(string image_id, bool is_del)
        {
            var result = GetProductImage(image_id, null);
            if (result.Count == 1)
            {
                result[0].is_del = is_del;
                return CBO.FillObject<ProductImageInfo>(DataProvider.Instance().SetProductImage(result[0]));
            }
            else
                return null;
        }
    }
}
