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
    public partial class ProductEdit : MasterPageControl
    {
        private string product_id
        {
            set
            {
                ViewState["product_id"] = value;
            }
            get
            {
                return (string)ViewState["product_id"];
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            product_id = Request.QueryString["product_id"];
            if (!IsPostBack)
            {
                bindDllCategoryProduct();
                bindProduct();
                bindProductImage();
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
        private void bindProduct()
        {
            var result = ProductController.GetProduct(product_id, null);
            if (result.Count == 1)
            {
                txtTitle.Text = result[0].title;
                txtDesciption.Text = result[0].description;
                txtPrice.Text = result[0].price.ToString();
                txtAmount.Text = result[0].amount.ToString();
                ddlCategory.SelectedValue = result[0].product_category_id;
            }

        }

        private void bindProductImage()
        {
            var result = ProductController.GetProductImage(product_id);
            rptProductImages.DataSource = result;
            rptProductImages.DataBind();
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                string resultValidate = Onvalidate();
                if (string.IsNullOrEmpty(resultValidate))
                {
                    setProduct();
                }
                else
                    ShowMessage(Page, resultValidate);
            }
            catch (Exception ex)
            {
                ShowMessage(Page, "เกิดข้อผิดพลาดในระบบ");
            }
        }

        private void setProduct()
        {
            ProductInfo pro = new ProductInfo();
            pro.product_id = product_id;
            pro.title = txtTitle.Text;
            pro.description = txtDesciption.Text;
            pro.price = float.Parse(txtPrice.Text);
            pro.amount = int.Parse(txtAmount.Text);
            pro.product_category_id = ddlCategory.SelectedValue;
            pro.lastupdate_by = (user_info == null) ? "No Login" : user_info.user_name;

            var result = ProductController.SetProduct(pro);

            if (result == null)
            {
                ShowMessage(Page, "แก้ไขผิดพลาด");
            }
            else
            {

                foreach (RepeaterItem item in rptProductImages.Items)
                {
                    FileUpload file = (FileUpload)item.FindControl("fileItemImage");

                    Literal lit = (Literal)item.FindControl("litImageId"); 
                    if (file.HasFile)
                    {
                        string exttension = System.IO.Path.GetExtension(file.FileName);
                        string newNameImage = Guid.NewGuid().ToString();
                        file.SaveAs(System.IO.Path.Combine(Server.MapPath("~/Images/"), newNameImage + exttension));

                        ProductImageInfo proi = new ProductImageInfo();
                        proi.image_id = lit.Text;
                        proi.product_id = result.product_id;
                        proi.image = newNameImage + exttension;
                        proi.lastupdate_by = result.lastupdate_by;
                        ProductController.SetProductImage(proi);
                    }

                }
                if (fileImage.HasFiles)
                {
                    foreach (var current in fileImage.PostedFiles)
                    {
                        string exttension = System.IO.Path.GetExtension(current.FileName);
                        string newNameImage = Guid.NewGuid().ToString();
                        current.SaveAs(System.IO.Path.Combine(Server.MapPath("~/Images/"), newNameImage + exttension));
                        listofuploadedfiles.Text += String.Format("{0}<br />", newNameImage + exttension);

                        ProductController.AddProductImage(result.product_id, newNameImage + exttension, result.create_by);
                    }
                }
                ShowMessage(Page, "แก้ไขสำเร็จ");
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

        protected void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                var result = ProductController.DelProduct(product_id, true);
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

        protected void rptProductImages_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                string user_infoid = (string)e.CommandArgument;
                switch (e.CommandName)
                {
                   
                }
            }
            catch (Exception exc) 
            {

            }
        }

        public string getImage(string image_name)
        {
            return NungningRacingShop.Utility.Utility.getImage(image_name);
        }

    }
}