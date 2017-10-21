using Nungning.BLL.Controller;
using Nungning.BLL.Info;
using NungningRacingShop.Controller;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NungningRacingShop.Backend.Promotion
{
    public partial class PromotionEdit : PageControl
    {
        public override bool requirelogin()
        {
            return true;
        }
        public override bool requireAdmin()
        {
            return true;
        }

        private string promotion_id
        {
            set
            {
                ViewState["promotion_id"] = value;
            }
            get
            {
                return (string)ViewState["promotion_id"];
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            promotion_id = Request.QueryString["promotion_id"];
            if (!IsPostBack)
            {
                if (string.IsNullOrEmpty(promotion_id))
                    return;
                bindDDLPromotionType();
                bindPromotion();
            }

        }
        private const string UnSelected = "------- กรุณาเลือก ---------";
        private void bindDDLPromotionType()
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
                    setNotice();
                }
                else
                    ShowMessage(Page, resultValidate);
            }
            catch (Exception ex)
            {
                ShowMessage(Page, "เกิดข้อผิดพลาดในระบบ");
            }
        }

        private void setNotice()
        {
            PromotionInfo promotion = new PromotionInfo();
            promotion.promotion_id = promotion_id;
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

            float completePrice;
            float.TryParse(txtCompletePrice.Text, out completePrice);

            promotion.complete_price = completePrice;

            promotion.free_amount = free;
            promotion.title = txtTitle.Text;
            promotion.description = txtDesciption.Text;
            promotion.image = imgName.Value;

            if (fileImage.HasFile)
            {

                var current = fileImage.PostedFile;
                string exttension = System.IO.Path.GetExtension(current.FileName);
                string newNameImage = Guid.NewGuid().ToString();
                current.SaveAs(System.IO.Path.Combine(Server.MapPath("~/Images/"), newNameImage + exttension));
                listofuploadedfiles.Text += String.Format("{0}<br />", newNameImage + exttension);
                promotion.image = newNameImage + exttension;

                /*if (File.Exists(System.IO.Path.Combine(Server.MapPath("~/Images/"), imgName.Value)))
                {
                    File.Delete(System.IO.Path.Combine(Server.MapPath("~/Images/"), imgName.Value));
                }*/
            }
            promotion.lastupdate_by = (SessionApp.user_info == null) ? "No Login" : SessionApp.user_info.user_name;
            var result = PromotionController.SetPromotion(promotion);

            if (result == null)
            {
                ShowMessage(Page, "แก้ไขผิดพลาด");
            }
            else
            {
                bindPromotion();
                ShowMessage(Page, "แก้ไขสำเร็จ");
            }



        }


        private void bindPromotion()
        {
            var result = PromotionController.GetPromotion(promotion_id);
            if (result.Count > 0)
            {
                var current = result[0];
                if (current != null)
                {
                    txtPromotionCode.Text = current.promotion_code;
                    ddlPromotonType.SelectedValue = current.promotion_type.ToString();
                    txtDiscountPercent.Text = current.discount_percent.ToString();
                    txtDiscountValue.Text = current.discount_value.ToString();
                    txtFreeProductId.Text = current.free_product_id;
                    txtFreeAmount.Text = current.free_amount.ToString();
                    txtTitle.Text = current.title;
                    txtDesciption.Text = current.description;
                    imgPromotion.ImageUrl = getImage(current.image);
                    imgName.Value = current.image;

                    txtCompletePrice.Text = current.complete_price.ToString();
                }
            }
            
        }
        public string getImage(string image_name)
        {
            return NungningRacingShop.Utility.Utility.getImage(image_name);
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