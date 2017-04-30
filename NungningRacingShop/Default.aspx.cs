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
    public partial class _Default : PageControl
    {


        public override bool requirelogin()
        {
            return false;
        }
        public override bool requireAdmin()
        {
            return false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindProductList();

            }
        }

        private void bindProductList()
        {
            var result = ProductController.GetProduct(null, null);
            rptProducts.DataSource = result;
            rptProducts.DataBind();
        }
        public string getImage(string image_name)
        {
            return NungningRacingShop.Utility.Utility.getImage(image_name);
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