using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CT.Model;

namespace CT.UI.Models
{
    public class InfoClassModel
    {
        //一级分类
        public List<InfoClass> InfoClasses { get; set; }

        //二级分类
        public List<ICC> ICC { get; set; }
    }
}