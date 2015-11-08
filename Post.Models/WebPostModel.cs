using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post.Models
{
    public class WebPostModel
    {
        public string PTitle { get; set; }

        public string PText { get; set; }

        public string PLink { get; set; }

        public string PImage { get; set; }

        public string PDate { get; set; }

        public decimal PPrice { get; set; }
    }
}
