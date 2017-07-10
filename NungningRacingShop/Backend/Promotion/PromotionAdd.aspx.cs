using Nungning.BLL.Controller;
using Nungning.BLL.Info;
using NungningRacingShop.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NungningRacingShop.Backend.Promotion
{
    public partial class PromotionAdd : PageControl
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
                bindDllPromotionType();
            }

        }
        private const string UnSelected = "------- กรุณาเลือก ---------";
        private void bindDllPromotionType()
        {
            ddlPromotonType.DataBind();
            ddlPromotonType.Items.Insert(0, new ListItem(UnSelected, "0"));
            ddlPromotonType.Items.Insert(1, new ListItem("ส่วนลดแบบเปอเซ็น", "1"));
            ddlPromotonType.Items.Insert(2, new ListItem("ส่วนลดแบบราคาเต็ม", "2"));
            ddlPromotonType.Items.Insert(3, new ListItem("แถมสินค้า", "3"));


        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                string resultValidate = Onvalidate();
                if (string.IsNullOrEmpty(resultValidate))
                {
                    addPromotion();
                }
                else
                    ShowMessage(Page, resultValidate);
            }
            catch (Exception ex)
            {
                ShowMessage(Page, "เกิดข้อผิดพลาดในระบบ");
            }
        }

        private void addPromotion()
        {
            PromotionInfo promotion = new PromotionInfo();
            promotion.promotion_code = txtPromotionCode.Text;
            
            promotion.promotion_type = int.Parse(ddlPromotonType.SelectedValue);
            float percent;
            float.TryParse(txtDiscountPercent.Text, out percent);
            promotion.discount_percent = percent;

            float value;
            float.TryParse(txtDiscountValue.Text, out value);

            promotion.discount_value = value;
            promotion.free_product_id = txtFreeProductId.Text;
            int free;
            int.TryParse(txtFreeAmount.Text, out free);

           promotion.free_amount = free;
            promotion.title = txtTitle.Text;
            promotion.description = txtDesciption.Text;

            if (fileImage.HasFile)
            {
                var current = fileImage.PostedFile;
                string exttension = System.IO.Path.GetExtension(current.FileName);
                string newNameImage = Guid.NewGuid().ToString();
                current.SaveAs(System.IO.Path.Combine(Server.MapPath("~/Images/"), newNameImage + exttension));
                listofuploadedfiles.Text += String.Format("{0}<br />", newNameImage + exttension);
                promotion.image = newNameImage + exttension;
            }
            promotion.create_by = (SessionApp.user_info == null) ? "No Login" : SessionApp.user_info.user_name;
            promotion.lastupdate_by = (SessionApp.user_info == null) ? "No Login" : SessionApp.user_info.user_name;
            var result = PromotionController.AddPromotion(promotion);

            if (result == null)
            {
                ShowMessage(Page, "เพิ่มผิดพลาด");
            }
            else
            {
                ShowMessage(Page, "เพิ่มสำเร็จ");
            }

        }

        private string Onvalidate()
        {
            string errMsg = "";
            if (string.IsNullOrEmpty(txtPromotionCode.Text)) { errMsg = "กรุณาระบุ ชื่อหมวดหมู่"; return errMsg; }
            if (string.IsNullOrEmpty(txtTitle.Text)) { errMsg = "กรุณาระบุ ชื่อหมวดหมู่"; return errMsg; }
            if (string.IsNullOrEmpty(txtDesciption.Text)) { errMsg = "กรุณาระบุ คำอธิบาย"; return errMsg; }

            return errMsg;
        }

    }
}