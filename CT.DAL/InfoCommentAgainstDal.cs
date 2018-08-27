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
    public partial class InfoCommentAgainstDal : BaseDal<InfoCommentAgainst>, IInfoCommentAgainst
    {
        public override Expression<Func<InfoCommentAgainst, bool>> GetByIdKey(int id)
        {
            return u=>u.ICA_ID==id;
        }

        public override Expression<Func<InfoCommentAgainst, string>> GetKey()
        {
            return u => u.ICA_ID.ToString();
        }
    }
}
