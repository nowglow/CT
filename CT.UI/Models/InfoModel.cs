using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CT.Model;

namespace CT.UI.Models
{
    public class InfoModel
    {
        ////一级分类
        //public List<InfoClass> InfoClasses { get; set; }

        ////二级分类
        //public List<ICC> ICC { get; set; }

        ////新闻信息
        //public List<Info> Infos { get; set; }

        public int Info_ID { get; set; }
        public string Info_Title { get; set; }
        public string Info_Content { get; set; }
        public string Info_Img { get; set; }
        public System.DateTime Info_Time { get; set; }
        public int InfoClass_ID { get; set; }
        public Nullable<int> ICC_ID { get; set; }

        //一级分类名
        public string Info_Class { get; set; }
        //二级分类名
        public string ICC_Name { get; set; }
    }
}