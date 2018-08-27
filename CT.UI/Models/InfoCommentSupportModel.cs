using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CT.UI.Models
{
    public class InfoCommentSupportModel
    {
        public int Info_ID { get; set; }
        public string Info_Title { get; set; }
        public int ICS_ID { get; set; }
        //新闻资讯支持的数量
        public int InfoSupportNum { get; set; }
    }
}