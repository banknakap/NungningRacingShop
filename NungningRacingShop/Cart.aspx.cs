using Nungning.BLL.Controller;
using Nungning.BLL.Info;
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
    public partial class Cart : PageControl
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
                bindCartProductList();
                bindAddress();


            }
        }
        private void bindAddress()
        {
            if (SessionApp.user_info != null)
            {
                txtAddress.Text = SessionApp.user_info.address;
            }
        }


        private void bindCartProductList()
        {
            List<ProductInfo> currentCart = new List<ProductInfo>();

            foreach (var c in SessionApp.cart_session)
            {
                ProductInfo item = ProductController.GetProduct(c.product_id, null).FirstOrDefault();
                item.cart_amount = c.amount;
                currentCart.Add(item);
            }

            if ( currentCart.Count==0)
            {
                lbl_message.InnerText = "ไม่พบสินค้าในรถเข็น";
                submit_div.Visible = false;
            }
            else
            {
                lbl_message.Visible = false;
            }
            rptProducts.DataSource = currentCart;
            rptProducts.DataBind();
        }



        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                string resultValidate = Onvalidate();
                if (string.IsNullOrEmpty(resultValidate))
                {
                    //register();
                }
                else
                    ShowMessage(Page, resultValidate);
            }
            catch (Exception ex)
            {

            }
        }

        private string Onvalidate()
        {
            string errMsg = "";
            if (string.IsNullOrEmpty(txtAddress.Text)) { errMsg = "กรุณาระบุ ที่อยู่"; return errMsg; }
            return errMsg;
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
                    case "EDIT_CART":
                        CartInfo cart = new CartInfo();
                        cart.product_id = product_id;
                        cart.amount = 1;
                        if (!CartController.addCart(cart))
                        {
                            ShowMessage(Page, "สินค้าเกินจำนวนจำกัดแล้ว");
                        }
                        break;
                    case "DEL_CART":
                        CartController.delCartItem(CartController.getCartInfo(product_id));
                        break;

                    default:
                        break;
                }
                bindCartProductList();
            }
            catch (Exception exc)
            {

            }
        }
    }
}