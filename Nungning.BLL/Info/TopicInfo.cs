using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nungning.BLL.Info
{
    public class TopicInfo
    {
        public string topic_id { get; set; }
        public string title { get; set; }
        public int display_sort { get; set; }
        public bool is_top { get; set; }
        public long read_count { get; set; }
        public string description { get; set; }
        public DateTime create_date { get; set; }
        public string create_by { get; set; }
        public DateTime lastupdate_date { get; set; }
        public string lastupdate_by { get; set; }
        public bool is_del { get; set; }

        //extra
        public int comment_count { get; set; }
    }
}
