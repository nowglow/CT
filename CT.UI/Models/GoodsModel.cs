using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CT.Model;
namespace CT.UI.Models
{
    public class GoodsModel
    {
       
        public int Goods_ID { get; set; }
        public string Goods_Name { get; set; }
        public string Goods_Content { get; set; }
        public string Goods_Img { get; set; }
        public decimal Goods_Price { get; set; }
        public int Type_ID { get; set; }
        public Nullable<int> Border_ID { get; set; }
        //一级分类名
        public string Type_Name { get; set; }
        //二级分类名
        public string Border_Name { get; set; }
    }
}