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

        public static BillInfo AddBill(string user_infoid,float total_price,string address,string promotion_id,float net_price,string create_by)
        {
            return CBO.FillObject<BillInfo>(DataProvider.Instance().AddBill(user_infoid,total_price,address,promotion_id, net_price, create_by));
        }

        public static BillDetailInfo AddBillDetail(string bill_id, string product_id, int amount, float sum_price,string create_by)
        {
            return CBO.FillObject<BillDetailInfo>(DataProvider.Instance().AddBillDetail( bill_id,  product_id,  amount,  sum_price,  create_by));
        }

        public static List<BillInfo> GetBill(string bill_id,string user_infoid)
        {
            return CBO.FillCollection<BillInfo>(DataProvider.Instance().GetBill(bill_id, user_infoid));
        }

        public static List<BillInfo> GetBillUnConfirm(string bill_id, string user_infoid)
        {
            return CBO.FillCollection<BillInfo>(DataProvider.Instance().GetBillUnConfirm(bill_id, user_infoid));
        }

        public static List<BillDetailInfo> GetBillDetail(string bill_detail_id, string bill_id)
        {
            return CBO.FillCollection<BillDetailInfo>(DataProvider.Instance().GetBillDetail(bill_detail_id, bill_id));
        }

        public static BillPaymentInfo AddBillPayment(string bill_id, string payment_time, float payment_price, string create_by,string payment_account,string payment_name,string payment_image)
        {
            return CBO.FillObject<BillPaymentInfo>(DataProvider.Instance().AddBillPayment(bill_id, payment_time, payment_price, create_by,payment_account,payment_name,payment_image));
        }

        public static List<BillPaymentInfo> GetBillPayment(string bill_id)
        {
            return CBO.FillCollection<BillPaymentInfo>(DataProvider.Instance().GetBillPayment(bill_id));
        }

    }

}
