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
    public partial class InfoCommentSupportDal : BaseDal<InfoCommentSupport>, IInfoCommentSupport
    {
        public override Expression<Func<InfoCommentSupport, bool>> GetByIdKey(int id)
        {
            return u => u.ICS_ID == id;
        }

        public override Expression<Func<InfoCommentSupport, string>> GetKey()
        {
            return u => u.ICS_ID.ToString();
        }
    }
}
