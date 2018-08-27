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
    public class InfoCommentBackDal : BaseDal<InfoCommentBack>, IInfoCommentBack
    {
        public override Expression<Func<InfoCommentBack, bool>> GetByIdKey(int id)
        {
            return u => u.ICB_ID == id;
        }

        public override Expression<Func<InfoCommentBack, string>> GetKey()
        {
            return u => u.ICB_ID.ToString();
        }
    }
}
