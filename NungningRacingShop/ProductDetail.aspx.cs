using Nungning.BLL.Controller;
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
                bindProduct();
                bindProductImage();
            }
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
            }

        }

        private void bindProductImage()
        {
            var result = ProductController.GetProductImage(null, product_id);
            rptProductImages.DataSource = result;
            rptProductImages.DataBind();
        }
        public string getImage(string image_name)
        {
            return NungningRacingShop.Utility.Utility.getImage(image_name);
        }
    }
}