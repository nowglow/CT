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
    public class VideoCommentDal : BaseDal<VideoComment>, IVideoComment
    {
        public override Expression<Func<VideoComment, bool>> GetByIdKey(int id)
        {
            return u => u.VC_ID == id;
        }

        public override Expression<Func<VideoComment, string>> GetKey()
        {
            return u => u.VC_ID.ToString();
        }
    }
}
