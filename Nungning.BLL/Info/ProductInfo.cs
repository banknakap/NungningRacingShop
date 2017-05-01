using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nungning.BLL.Info
{
    [Serializable()]
    public class ProductInfo
    {
        public string product_id { get; set; }
        public string product_category_id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public float price { get; set; }
        public long amount { get; set; }
        public int display_sort { get; set; }
        public DateTime create_date { get; set; }
        public string create_by { get; set; }
        public DateTime lastupdate_date { get; set; }
        public string lastupdate_by { get; set; }
        public bool is_del { get; set; }

        //extra
        public string catetitle { get; set; }
        public string catedes { get; set; }
        public string image_id { get; set; }
        public string image { get; set; }

        //cart extra
        public int cart_amount { get; set; }
        public float sum_price { get; set; }
    }
}
