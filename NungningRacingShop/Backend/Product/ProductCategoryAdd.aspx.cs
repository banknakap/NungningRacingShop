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
    public partial class ProductCategoryAdd : MasterPageControl
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

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                string resultValidate = Onvalidate();
                if (string.IsNullOrEmpty(resultValidate))
                {
                    addProductCategory();
                }
                else
                    ShowMessage(Page, resultValidate);
            }
            catch (Exception ex)
            {
                ShowMessage(Page, "เกิดข้อผิดพลาดในระบบ");
            }
        }

        private void addProductCategory()
        {
            ProductCategoryInfo procate = new ProductCategoryInfo();
            procate.title = txtTitle.Text;
            procate.description = txtDesciption.Text;
            procate.create_by = (user_info==null) ? "No Login" : user_info.user_name;
            var result = ProductController.AddProductCategory(procate);

            if (result == null)
            {
                ShowMessage(Page, "ชื่อหมวดหมู่นี้มีอยู่ในระบบแล้ว");
            }
            else
            {
                ShowMessage(Page, "เพิ่มหมวดหมู่สำเร็จ");
            }
        }

        private string Onvalidate()
        {
            string errMsg = "";
            if (string.IsNullOrEmpty(txtTitle.Text)) { errMsg = "กรุณาระบุ ชื่อหมวดหมู่"; return errMsg; }
            if (string.IsNullOrEmpty(txtDesciption.Text)) { errMsg = "กรุณาระบุ คำอธิบาย"; return errMsg; }
            return errMsg;
        }
    }
}