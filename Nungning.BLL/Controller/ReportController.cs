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
    public class ReportController
    {
        public static List<ReportHistoryInfo> GetReportHistory(DateTime start_date,DateTime end_date)
        {
            return CBO.FillCollection<ReportHistoryInfo>(DataProvider.Instance().GetReportHistory(start_date, end_date));
        }
    }
}
