﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nungning.BLL.Info
{
    [Serializable()]
    public class ProductImageInfo
    {
        public string image_id { get; set; }
        public string product_id { get; set; }
        public string image { get; set; }
        public int display_sort { get; set; }
        public DateTime create_date { get; set; }
        public string create_by { get; set; }
        public DateTime lastupdate_date { get; set; }
        public string lastupdate_by { get; set; }
        public bool is_del { get; set; }
    }
}
