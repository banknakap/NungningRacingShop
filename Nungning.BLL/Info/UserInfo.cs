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
        public string email { get; set; }
        public int gender { get; set; }
        public string address { get; set; }
        public DateTime create_date { get; set; }
        public string create_by { get; set; }
        public DateTime lastupdate_date { get; set; }
        public string lastupdate_by { get; set; }
        public bool is_del { get; set; }

    }

    public enum UserType
    {
        Admin,
        General,
        Staff
    }
}
