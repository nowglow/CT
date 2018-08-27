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
    public partial class VideoCommentAgainstDal : BaseDal<VideoCommentAgainst>, IVideoCommentAgainst
    {
        public override Expression<Func<VideoCommentAgainst, bool>> GetByIdKey(int id)
        {

            return u => u.VCA_ID == id;
        }

        public override Expression<Func<VideoCommentAgainst, string>> GetKey()
        {
            return u => u.VCA_ID.ToString();
        }
    }
}
