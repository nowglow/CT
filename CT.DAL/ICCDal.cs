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
    public class ICCDal : BaseDal<ICC>, IICC
    {
        public override Expression<Func<ICC, bool>> GetByIdKey(int id)
        {
            return u => u.ICC_ID == id;
        }

        public override Expression<Func<ICC, string>> GetKey()
        {
            return u => u.ICC_Name;
        }
    }
}
