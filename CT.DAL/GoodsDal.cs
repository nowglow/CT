using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CT.Model;
using CT.IDAL;
using System.Linq.Expressions;

namespace CT.DAL
{
    public class GoodsDal : BaseDal<Goods>, IGoods
    {
        public override Expression<Func<Goods, bool>> GetByIdKey(int id)
        {
            return u => u.Goods_ID == id;
        }

        public override Expression<Func<Goods, string>> GetKey()
        {
            return u => u.Goods_Name;
        }
    }
}
