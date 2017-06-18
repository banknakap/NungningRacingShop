using Nungning.BLL.Controller;
using NungningRacingShop.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NungningRacingShop.Notice
{
    public partial class NoticeDetail : PageControl
    {

        public override bool requirelogin()
        {
            return false;
        }
        public override bool requireAdmin()
        {
            return false;
        }

        private string notice_id
        {
            set
            {
                ViewState["notice_id"] = value;
            }
            get
            {
                return (string)ViewState["notice_id"];
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            notice_id = Request.QueryString["notice_id"];
            if (!IsPostBack)
            {
                

                bindNotice();
            }

        }
        private const string UnSelected = "------- กรุณาเลือก ---------";
       
        


        private void bindNotice()
        {
            var current = NoticeController.GetNotice(notice_id);
            if (current.Count > 0)
            {
                lblTitle.Text = current[0].title;
                lblDesciption.InnerText = current[0].description;
                imgNotice.ImageUrl = getImage(current[0].image);

                navItem.InnerText = current[0].title;
                navItem.HRef = HttpContext.Current.Request.Url.PathAndQuery;
            }

        }
        public string getImage(string image_name)
        {
            return NungningRacingShop.Utility.Utility.getImage(image_name);
        }

       
    }
}