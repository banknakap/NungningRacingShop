using Nungning.BLL.Controller;
using NungningRacingShop.Controller;
using NungningRacingShop.Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NungningRacingShop.Product
{
    public partial class ProductCategory : PageControl
    {
        public override bool requirelogin()
        {
            return false;
        }
        public override bool requireAdmin()
        {
            return false;
        }

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
            if (!IsPostBack)
            {
                bindProductList();

                

            }
        }

        private void bindProductList()
        {
            var result = ProductController.GetProduct(null, product_category_id);

            if (result != null || result.Count > 0)
            {
                navCate.InnerText = result[0].catetitle;
                navCate.HRef = HttpContext.Current.Request.Url.PathAndQuery;
            }
            rptProducts.DataSource = result;
            rptProducts.DataBind();
        }
        public string getImage(string image_name)
        {
            return NungningRacingShop.Utility.Utility.getImage(image_name);
        }

        public string getFormatMoney(string x)
        {
            return NungningRacingShop.Utility.Utility.formatMoney(float.Parse(x));
        }

        protected void rptProducts_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {


                string product_id = (string)e.CommandArgument;
                switch (e.CommandName)
                {
                    case "ADD_CART":

                        CartInfo cart = new CartInfo();
                        cart.product_id = product_id;
                        cart.amount = 1;
                        if (!CartController.addCart(cart))
                        {
                            ShowMessage(Page, "สินค้าเกินจำนวนจำกัดแล้ว");
                        }
                        break;
                    default:
                        break;
                }
                //bindProductList();
                if (SessionApp.user_info != null)
                {
                    CallJS(Page, "$('#badge_cart').html('" + SessionApp.cart_session.Count + "')");
                }
                else
                {
                    CallJS(Page, "$('#badge_cart2').html('" + SessionApp.cart_session.Count + "')");
                }




            }
            catch (Exception exc)
            {

            }
        }
    }
}