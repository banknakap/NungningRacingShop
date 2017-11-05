using Nungning.BLL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NungningRacingShop.Backend.Product
{
    public partial class ProductCategoryList : PageControl
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
                bindProductCategoryList();

            }
        }
        private void bindProductCategoryList()
        {
            var result = ProductController.GetProductCategory(null);
            rptProductCategory.DataSource = result;
            rptProductCategory.DataBind();
        }

        protected void rptProductCategory_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                string product_category_id = (string)e.CommandArgument;
                switch (e.CommandName)
                {
                    case "PRODUCT_CATE_EDIT":
                        RedirectTo("~/Backend/Product/ProductCategoryEdit.aspx" + "?product_category_id=" + product_category_id);
                        break;
                    case "PRODUCT_CATE_DEL":
                        ProductController.DelProductCategory(product_category_id, true);
                        break;
                    default:
                        break;
                }

                bindProductCategoryList();
            }
            catch (Exception exc)
            {

            }
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
            var result = ProductController.SearchProductCategory(null, txtTitle.Text);
            rptProductCategory.DataSource = result;
            rptProductCategory.DataBind();
        }
    }
}