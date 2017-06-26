using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nungning.BLL.Info
{
    public class BillInfo
    {
        public string bill_id { get; set; }
        public long bill_code { get; set; }
        public float total_price { get; set; }
        public string address { get; set; }
        public DateTime create_date { get; set; }
        public string create_by { get; set; }
    }
}
