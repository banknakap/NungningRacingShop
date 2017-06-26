using Nungning.BLL.Controller;
using NungningRacingShop.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NungningRacingShop.Bill
{
    public partial class BillHistoryList : PageControl
    {
        public override bool requirelogin()
        {
            return true;
        }
        public override bool requireAdmin()
        {
            return false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (SessionApp.user_info == null)
                    return;
                bindBillList();

            }
        }

        private void bindBillList()
        {
            var result = BillController.GetBill(null, SessionApp.user_info.user_infoid);
            rptBills.DataSource = result.OrderByDescending(d => d.create_date);
            rptBills.DataBind();
        }

        protected void rptBills_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                string bill_id = (string)e.CommandArgument;
                switch (e.CommandName)
                {
                    case "DETAIL":
                        RedirectTo("~/Bill/BillDetail" + "?bill_id=" + bill_id);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception exc)
            {

            }
        }
    }
}