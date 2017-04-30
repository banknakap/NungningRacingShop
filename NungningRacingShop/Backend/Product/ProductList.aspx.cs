using Nungning.BLL.Controller;
using NungningRacingShop.Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NungningRacingShop.Backend.Product
{
    public partial class ProductList : PageControl
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
                bindProductList();

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
        private void bindProductList()
        {
            var result = ProductController.GetProduct(null, null);
            rptProducts.DataSource = result;
            rptProducts.DataBind();
        }

        protected void rptProducts_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                string product_id = (string)e.CommandArgument;
                switch (e.CommandName)
                {
                    case "PRODUCT_EDIT":
                        RedirectTo("~/Backend/Product/ProductEdit.aspx" + "?product_id=" + product_id);
                        break;
                    case "PRODUCT_DEL":
                        ProductController.DelProduct(product_id, true);
                        break;
                    default:
                        break;
                }
                bindProductList();
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
          
                    searchProduct();
              
     
            }
            catch (Exception ex)
            {
                ShowMessage(Page, "เกิดข้อผิดพลาดในระบบ");
            }
        }
        private void searchProduct()
        {
            var result = ProductController.SearchProduct(null, ddlCategory.SelectedValue, txtTitle.Text);
            rptProducts.DataSource = result;
            rptProducts.DataBind();
        }


    }


}