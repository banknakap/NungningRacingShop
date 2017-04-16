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
    public partial class ProductAdd : PageControl
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
                bindDllCategoryProduct();
            }

        }
        private const string UnSelected = "------- กรุณาเลือก ---------";
        private void bindDllCategoryProduct()
        {
            var result = ProductController.GetProductCategory(null);
            ddlCategory.DataSource = result;
            ddlCategory.DataValueField = "product_category_id";
            ddlCategory.DataTextField = "title";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem(UnSelected, ""));


        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                string resultValidate = Onvalidate();
                if (string.IsNullOrEmpty(resultValidate))
                {
                    addProduct();
                }
                else
                    ShowMessage(Page, resultValidate);
            }
            catch (Exception ex)
            {
                ShowMessage(Page, "เกิดข้อผิดพลาดในระบบ");
            }
        }

        private void addProduct()
        {
            ProductInfo pro = new ProductInfo();
            pro.title = txtTitle.Text;
            pro.description = txtDesciption.Text;
            pro.price = float.Parse(txtPrice.Text);
            pro.amount = int.Parse(txtAmount.Text);
            pro.product_category_id = ddlCategory.SelectedValue;
            pro.create_by = (user_info == null) ? "No Login" : user_info.user_name;
            var result = ProductController.AddProduct(pro);

            if (result == null)
            {
                ShowMessage(Page, "ชื่อสินค้าในหมวดหมู่นี้มีอยู่ในระบบแล้ว");
            }
            else
            {

                foreach (var current in fileImage.PostedFiles)
                {
                    string exttension = System.IO.Path.GetExtension(current.FileName);
                    string newNameImage = Guid.NewGuid().ToString();
                    current.SaveAs(System.IO.Path.Combine(Server.MapPath("~/Images/"), newNameImage+ exttension));
                    listofuploadedfiles.Text += String.Format("{0}<br />", newNameImage + exttension);
                    
                    ProductController.AddProductImage(result.product_id, newNameImage+ exttension, result.create_by);
                }
                ShowMessage(Page, "เพิ่มหมวดหมู่สำเร็จ");
            }

        }

        private string Onvalidate()
        {
            string errMsg = "";
            if (string.IsNullOrEmpty(txtTitle.Text)) { errMsg = "กรุณาระบุ ชื่อหมวดหมู่"; return errMsg; }
            if (string.IsNullOrEmpty(txtDesciption.Text)) { errMsg = "กรุณาระบุ คำอธิบาย"; return errMsg; }
            if (string.IsNullOrEmpty(txtPrice.Text)) { errMsg = "กรุณาระบุ ราคา"; return errMsg; }
            if (string.IsNullOrEmpty(txtAmount.Text)) { errMsg = "กรุณาระบุ จำนวน"; return errMsg; }

            return errMsg;
        }
    }

}