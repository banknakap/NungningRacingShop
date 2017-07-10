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
                navCart.HRef = HttpContext.Current.Request.Url.PathAndQuery;


            }
        }
        private void bindAddress()
        {
            if (SessionApp.user_info != null)
            {
                txtAddress.Text = SessionApp.user_info.address;
            }
        }

        public static List<ProductInfo> currentCart;
        public static float total_price = 0;
        private void bindCartProductList()
        {
            currentCart = new List<ProductInfo>();
            total_price = 0;
            foreach (var c in SessionApp.cart_session)
            {
                ProductInfo item = ProductController.GetProduct(c.product_id, null).FirstOrDefault();
                item.cart_amount = c.amount;
                item.sum_price = (c.amount * item.price);
                total_price += item.sum_price;
                currentCart.Add(item);
            }

            if (currentCart.Count == 0)
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
                    if (SessionApp.user_info == null)
                    {
                        string path = Request.Url.PathAndQuery.ToString();
                        string return_path = path.Replace("/default", "");
                        RedirectTo("~/Authentication/Login.aspx?return_page=" + return_path);
                        return;
                    }
                    else
                    {
                        buyProduct();
                    }
                }
                else
                    ShowMessage(Page, resultValidate);
            }
            catch (Exception ex)
            {
                ShowMessage(Page, ex.Message);
            }
        }
        private void buyProduct()
        {
            string user_infoid = (SessionApp.user_info == null) ? "No Login" : SessionApp.user_info.user_infoid;
            string user_name = (SessionApp.user_info == null) ? "No Login" : SessionApp.user_info.user_name;

            var promotion = PromotionController.GetPromotionByPromotionCode(txtPromotionCode.Text);
            if (promotion == null)
            {
                ShowMessage(Page, "ไม่พบโปรโมชั่นนี้");
                return;
            }
            float discount = 0;
            if (promotion.promotion_type == 1)
            {
                discount = (total_price / 100) * promotion.discount_percent;
            }
            if (promotion.promotion_type == 2)
            {
                discount = promotion.discount_value;
            }

            var bill = BillController.AddBill(user_infoid, total_price - discount, txtAddress.Text, promotion.promotion_id, total_price, user_name);
            List<BillDetailInfo> bills = new List<BillDetailInfo>();
            foreach (var c in currentCart)
            {
                var resultbill = BillController.AddBillDetail(bill.bill_id, c.product_id, c.cart_amount, (c.cart_amount * c.price), user_name);
                bills.Add(resultbill);
            }



            if (promotion.promotion_type == 3)
            {
                var product = ProductController.GetProduct(promotion.free_product_id, null);

                if (product == null)
                {
                    ShowMessage(Page, "ไม่พบรายการของแถม");
                    return;
                }
                var currentPro = product[0];
                var resultBill = BillController.AddBillDetail(bill.bill_id, currentPro.product_id, promotion.free_amount, 0, user_name); ;
                bills.Add(resultBill);
            }

            var billInfo = BillController.GetBill(bill.bill_id, user_infoid);
            if (bill != null && billInfo.Count > 0)
            {
                var currentBill = billInfo[0];
                string contentMail = "ท่านได้มีรายการสั่งซื้อ";
                contentMail += "<br/> หมายเลขใบเสร็จที่ : " + currentBill.bill_code.ToString("000000#");
                contentMail += "<br/> ท่านสามารถเข้าดูรายการซื้อขายได้ที่ : <a href='http://www.nungningracingshop.com/Bill/BillDetail?bill_id=" + currentBill.bill_id + "'> คลิกที่นี่ </a>";
                contentMail += "<br/><br/> ขอขอบพระคุณท่านลูกค้าที่อุดหนุนร้าน NungNingRacingShop";
                MailController.sendEmail(SessionApp.user_info.email, "รายการสั่งซื้อ", contentMail);
                RedirectTo("~/Bill/BillDetail?bill_id=" + currentBill.bill_id);
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