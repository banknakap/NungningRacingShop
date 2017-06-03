using Nungning.BLL.Controller;
using NungningRacingShop.Controller;
using NungningRacingShop.Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NungningRacingShop
{
    public partial class ProductDetail : PageControl
    {
        public override bool requirelogin()
        {
            return false;
        }
        public override bool requireAdmin()
        {
            return false;
        }
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
                if (string.IsNullOrEmpty(product_id))
                    return;
                bindProduct();
                bindProductImage();
            }
        }
        private void bindProduct()
        {
            var result = ProductController.GetProduct(product_id, null);
            if (result.Count == 1)
            {
                lblProductName.InnerText = result[0].title;
                divDescription.InnerText = result[0].description;
                lblPrice.InnerText = NungningRacingShop.Utility.Utility.formatMoney(result[0].price)+ " ฿";
                txtAmount.Text = "1";

                navCate.InnerText = result[0].catetitle;
                navCate.HRef = "~/Product/ProductCategory.aspx?product_category_id=" + result[0].product_category_id;
                navProduct.InnerText = result[0].title;
                navProduct.HRef = HttpContext.Current.Request.Url.PathAndQuery;

                if (result[0].create_date != null || result[0].create_date != DateTime.MinValue)
                {
                    if ((DateTime.Now - result[0].create_date).TotalHours < 24)
                        lblProductName.InnerHtml = result[0].title + "  <span class='label label-danger' style='background-color:#d9534f;'>New</span>";
                }
            }

        }

        private void bindProductImage()
        {
            var result = ProductController.GetProductImage(null, product_id);

            if (result.Count > 0)
            {
                xzoom_magnific.Attributes["src"] = getImage(result[0].image);
                xzoom_magnific.Attributes["xoriginal"] = getImage(result[0].image);


            }
            rptProductImages.DataSource = result;
            rptProductImages.DataBind();
        }
        public string getImage(string image_name)
        {
            return NungningRacingShop.Utility.Utility.getImage(image_name);
        }

        protected void btnBuy_Click(object sender, EventArgs e)
        {
            CartInfo cart = new CartInfo();
            cart.product_id = product_id;
            cart.amount = (int)float.Parse(txtAmount.Text);
            if (!CartController.addCart(cart))
            {
                ShowMessage(Page, "สินค้าเกินจำนวนจำกัดแล้ว");
            }

            if (SessionApp.user_info != null)
            {
                CallJS(Page, "$('#badge_cart').html('" + SessionApp.cart_session.Count + "')");
            }
            else
            {
                CallJS(Page, "$('#badge_cart2').html('" + SessionApp.cart_session.Count + "')");
            }
        }
    }
}