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
    public class InfoClassDal : BaseDal<InfoClass>, IInfoClass
    {
        public override Expression<Func<InfoClass, bool>> GetByIdKey(int id)
        {
            return u => u.InfoClass_ID == id;
        }

        public override Expression<Func<InfoClass, string>> GetKey()
        {
            return u => u.Info_Class;
        }
    }
}
