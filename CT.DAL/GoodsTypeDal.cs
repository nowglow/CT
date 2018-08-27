using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CT.IDAL;
using CT.Model;
using System.Linq.Expressions;
namespace CT.DAL
{
    public class GoodsTypeDal : BaseDal<GoodsType>, IGoodsType
    {
        public override Expression<Func<GoodsType, bool>> GetByIdKey(int id)
        {
            return u => u.Type_ID == id;
        }

        public override Expression<Func<GoodsType, string>> GetKey()
        {
            return u => u.Type_Name;
        }
    }
}
