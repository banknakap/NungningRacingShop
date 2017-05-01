using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nungning.BLL.Info
{
    public class BillDetailInfo
    {
        public string bill_detail_id { get; set; }
        public string bill_id { get; set; }
        public string product_id { get; set; }
        public int amount { get; set; }
        public float sum_price { get; set; }
        public DateTime create_date { get; set; }
        public string create_by { get; set; }
    }
}
