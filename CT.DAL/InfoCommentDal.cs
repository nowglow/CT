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
    public class InfoCommentDal : BaseDal<InfoComment>, IInfoComment
    {
        public override Expression<Func<InfoComment, bool>> GetByIdKey(int id)
        {
            return u => u.IC_ID == id;
        }

        public override Expression<Func<InfoComment, string>> GetKey()
        {
            return u => u.IC_ID.ToString();
        }
    }
}
