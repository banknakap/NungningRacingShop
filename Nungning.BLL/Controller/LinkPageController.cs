using Nungning.BLL.Info;
using Nungning.BLL.Provider;
using NungningUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nungning.BLL.Controller
{
    public class LinkPageController
    {
        public static List<LinkPageInfo> GetLinkPage(string link_page)
        {
            return CBO.FillCollection<LinkPageInfo>(DataProvider.Instance().GetLinkPage(link_page));
        }
    }
}
