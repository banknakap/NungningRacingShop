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
    public class BillController
    {

        public static BillInfo AddBill(string user_infoid,float total_price,string address,string create_by)
        {
            return CBO.FillObject<BillInfo>(DataProvider.Instance().AddBill(user_infoid,total_price,address,create_by));
        }

        public static BillDetailInfo AddBillDetail(string bill_id, string product_id, int amount, float sum_price,string create_by)
        {
            return CBO.FillObject<BillDetailInfo>(DataProvider.Instance().AddBillDetail( bill_id,  product_id,  amount,  sum_price,  create_by));
        }

        public static BillInfo GetBill(string bill_id,string user_infoid)
        {
            return CBO.FillObject<BillInfo>(DataProvider.Instance().GetBill(bill_id, user_infoid));
        }

        public static BillDetailInfo GetBillDetail(string bill_detail_id, string bill_id)
        {
            return CBO.FillObject<BillDetailInfo>(DataProvider.Instance().GetBillDetail(bill_detail_id, bill_id));
        }

    }

}
