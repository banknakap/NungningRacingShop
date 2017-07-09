using Nungning.BLL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NungningRacingShop.Backend.Promotion
{
    public partial class PromotionList : PageControl
    {
        public override bool requirelogin()
        {
            return true;
        }
        public override bool requireAdmin()
        {
            return true;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindPromotionList();

            }
        }
        private const string UnSelected = "------- กรุณาเลือก ---------";
    
        private void bindPromotionList()
        {
            var result = PromotionController.SearchPromotion(null, null);
            rptPromotions.DataSource = result;
            rptPromotions.DataBind();
        }

        protected void rptPromotions_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                string promotion_id = (string)e.CommandArgument;
                switch (e.CommandName)
                {
                    case "EDIT":
                        RedirectTo("~/Backend/Promotion/PromotionEdit.aspx" + "?promotion_id=" + promotion_id);
                        break;
                    case "DEL":
                        PromotionController.DelPromotion(promotion_id, true);
                        break;
                    default:
                        break;
                }
                bindPromotionList();
            }
            catch (Exception exc)
            {

            }
        }
        public string getImage(string image_name)
        {
            return NungningRacingShop.Utility.Utility.getImage(image_name);
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                searchPromotion();
            }
            catch (Exception ex)
            {
                ShowMessage(Page, "เกิดข้อผิดพลาดในระบบ");
            }
        }
        private void searchPromotion()
        {
            var result = PromotionController.SearchPromotion(null,txtTitle.Text);
            rptPromotions.DataSource = result;
            rptPromotions.DataBind();
        }



    }
}