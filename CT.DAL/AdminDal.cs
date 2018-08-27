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
    public class AdminDal : BaseDal<Admin>, IAdmin
    {
        public override Expression<Func<Admin, bool>> GetByIdKey(int id)
        {
            return u => u.Admin_ID == id;
        }

        public override Expression<Func<Admin, string>> GetKey()
        {
            return u => u.Admin_Name;
        }
    }
}
