using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nungning.BLL.Info
{
    public class CommentInfo
    {
        public string comment_id { get; set; }
        public string topic_id { get; set; }
        public string description { get; set; }
        public DateTime create_date { get; set; }
        public string create_by { get; set; }
        public DateTime lastupdate_date { get; set; }
        public string lastupdate_by { get; set; }
        public bool is_del { get; set; }
    }
}
