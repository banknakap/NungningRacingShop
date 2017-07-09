
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nungning.BLL.Info
{
   public  class PromotionInfo
    {
        public string promotion_id { get; set; }
        public string promotion_code { get; set; }
        public int promotion_type { get; set; }
        public float discount_percent { get; set; }
        public float discount_value { get; set; }
        public string free_product_id { get; set; }
        public int free_amount { get; set; }
        public DateTime create_date { get; set; }
        public string create_by { get; set; }
        public DateTime lastupdate_date { get; set; }
        public string lastupdate_by { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public bool is_del { get; set; }
    }
}
