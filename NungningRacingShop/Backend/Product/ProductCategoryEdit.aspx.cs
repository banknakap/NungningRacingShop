using Nungning.BLL.Controller;
using Nungning.BLL.Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NungningRacingShop.Backend.Product
{
    public partial class ProductCategoryEdit : MasterPageControl
    {
        private string product_category_id
        {
            set
            {
                ViewState["product_category_id"] = value;
            }
            get
            {
                return (string)ViewState["product_category_id"];
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            product_category_id = Request.QueryString["product_category_id"];
            if (!Page.IsPostBack)
            {

                bindCategory();
            }
        }
        private void bindCategory()
        {
            var result = ProductController.GetProductCategory(product_category_id);

            if (result.Count == 1)
            {
                txtTitle.Text = result[0].title;
                txtDesciption.Text = result[0].description;
            }

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                string resultValidate = Onvalidate();
                if (string.IsNullOrEmpty(resultValidate))
                {
                    setProductCategory();
                }
                else
                    ShowMessage(Page, resultValidate);
            }
            catch (Exception ex)
            {
                ShowMessage(Page, "เกิดข้อผิดพลาดในระบบ");
            }
        }

        private void setProductCategory()
        {
            ProductCategoryInfo procate = new ProductCategoryInfo();
            procate.product_category_id = product_category_id;
            procate.title = txtTitle.Text;
            procate.description = txtDesciption.Text;
            procate.lastupdate_by = (user_info == null) ? "No Login" : user_info.user_name;
            var result = ProductController.SetProductCategory(procate);

            if (result == null)
            {
                ShowMessage(Page, "แก้ไขผิดพลาด");
            }
            else
            {
                ShowMessage(Page, "แก้ไขหมวดหมู่สำเร็จ");
            }
        }
        private string Onvalidate()
        {
            string errMsg = "";
            if (string.IsNullOrEmpty(txtTitle.Text)) { errMsg = "กรุณาระบุ ชื่อหมวดหมู่"; return errMsg; }
            if (string.IsNullOrEmpty(txtDesciption.Text)) { errMsg = "กรุณาระบุ คำอธิบาย"; return errMsg; }
            return errMsg;
        }
        protected void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                var result = ProductController.DelProductCategory(product_category_id, true);
                if (result != null)
                    ShowMessage(Page, "ลบสำเร็จ");
                else
                    ShowMessage(Page, "ลบไม่สำเร็จ");
            }
            catch (Exception ex)
            {
                ShowMessage(Page, "เกิดข้อผิดพลาดในระบบ");
            }
        }

    }


}
