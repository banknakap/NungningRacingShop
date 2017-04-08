using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nungning.BLL.Info
{
    [Serializable()]
    public class UserInfo
    {
        public string user_infoid { get; set; }
        public string user_name { get; set; }
        public string password { get; set; }
        public string user_type { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string gender { get; set; }
        public string address { get; set; }
        public string create_date { get; set; }
        public string create_by { get; set; }
        public string lastupdate_date { get; set; }

    }
}
