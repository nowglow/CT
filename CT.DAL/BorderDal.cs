using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CT.IDAL;
using CT.Model;
namespace CT.DAL
{
    public class BorderDal : BaseDal<Border>, IBorder
    {
        public override Expression<Func<Border, bool>> GetByIdKey(int id)
        {
            return u => u.Border_ID == id;
        }

        public override Expression<Func<Border, string>> GetKey()
        {
            return u => u.Border_Name;
        }
    }
}
