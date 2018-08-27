using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CT.UI.Models
{
    public class InfoCommentAgainstModel
    {
        public int Info_ID { get; set; }
        public string Info_Title { get; set; }
     
        //新闻资讯反对的数量
        public int InfoAgainstNum { get; set; }

    }
}