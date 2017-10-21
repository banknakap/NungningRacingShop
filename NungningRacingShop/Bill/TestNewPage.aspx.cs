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
    public partial class TestNewPage : PageControl
    {
        public string bill_id
        {
            set
            {
                ViewState["bill_id"] = value;
            }
            get
            {
                return (string)ViewState["bill_id"];
            }
        }
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
            bill_id = Request.QueryString["bill_id"];

            if (SessionApp.user_info == null)
                return;

            var billinfo = BillController.GetBill(bill_id, SessionApp.user_info.user_infoid);
            string sdfsd = "";

        }
    }
}