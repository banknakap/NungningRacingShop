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
    public class NoticeController
    {
        public static List<NoticeInfo> GetNotice(string notice_id)
        {
            return CBO.FillCollection<NoticeInfo>(DataProvider.Instance().GetNotice(notice_id));
        }
        public static List<NoticeInfo> AddNotice(NoticeInfo notice)
        {
            return CBO.FillCollection<NoticeInfo>(DataProvider.Instance().AddNotice(notice));
        }
        public static List<NoticeInfo> SetNotice(NoticeInfo notice)
        {
            return CBO.FillCollection<NoticeInfo>(DataProvider.Instance().SetNotice(notice));
        }

        public static List<NoticeInfo> SearchNotice(string notice_id , string title)
        {
            return CBO.FillCollection<NoticeInfo>(DataProvider.Instance().SearchNotice(notice_id , title));
        }


        public static NoticeInfo DelNotice(string notice_id, bool is_del)
        {
            var result = GetNotice(notice_id);
            if (result.Count == 1)
            {
                result[0].is_del = is_del;
                return CBO.FillObject<NoticeInfo>(DataProvider.Instance().SetNotice(result[0]));
            }
            else
                return null;
        }
    }
}
