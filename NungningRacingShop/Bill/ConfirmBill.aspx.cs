using Nungning.BLL.Controller;
using Nungning.BLL.Info;
using NungningRacingShop.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NungningRacingShop.Bill
{
    public partial class ConfirmBill : PageControl
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
                bindBillUnConfirm();
            }
        }
        private void bindBillUnConfirm()
        {
            var resultBills = BillController.GetBillUnConfirm(null, SessionApp.user_info.user_infoid);

            rptBillConfirms.DataSource = resultBills.OrderByDescending(d => d.create_date);
            rptBillConfirms.DataBind();
        }

        protected void rptBillConfirms_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                string sdfsdf = (string)e.CommandArgument;
                switch (e.CommandName)
                {
                    case "COMMAND":
                        RedirectTo("~/Bill/BillPayment.aspx?bill_id=" + sdfsdf);
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