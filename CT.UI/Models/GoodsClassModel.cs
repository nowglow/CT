using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CT.Model;
namespace CT.UI.Models
{
    public class GoodsClassModel
    {
        //一级分类
        public List<GoodsType> GoodsTypes{ get; set; }

        //二级分类
        public List<Border> Border { get; set; }
    }
}