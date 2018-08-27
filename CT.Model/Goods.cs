//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace CT.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Goods
    {
        public Goods()
        {
            this.Collection = new HashSet<Collection>();
            this.GoodsComment = new HashSet<GoodsComment>();
            this.GoodsSave = new HashSet<GoodsSave>();
            this.Order = new HashSet<Order>();
        }
    
        public int Goods_ID { get; set; }
        public int Type_ID { get; set; }
        public int Border_ID { get; set; }
        public string Goods_Name { get; set; }
        public string Goods_Content { get; set; }
        public string Goods_Img { get; set; }
        public decimal Goods_Price { get; set; }
    
        public virtual Border Border { get; set; }
        public virtual ICollection<Collection> Collection { get; set; }
        public virtual GoodsType GoodsType { get; set; }
        public virtual ICollection<GoodsComment> GoodsComment { get; set; }
        public virtual ICollection<GoodsSave> GoodsSave { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}