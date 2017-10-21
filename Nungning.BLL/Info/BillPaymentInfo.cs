using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nungning.BLL.Info
{
    public class BillPaymentInfo
    {
        public string payment_id { get; set; }
        public string bill_id { get; set; }
        public string payment_time { get; set; }
        public float payment_price { get; set; }
        public DateTime create_date { get; set; }
        public string create_by { get; set; }
        public DateTime lastupdate_date { get; set; }
        public string lastupdate_by { get; set; }
        public string  payment_account { get; set; }
        public string payment_name { get; set; }
        public string payment_image { get; set; }

        public string bill_code { get; set; }
    }
}
