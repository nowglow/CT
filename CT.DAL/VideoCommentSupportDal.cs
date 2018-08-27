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
    public partial class VideoCommentSupportDal : BaseDal<VideoCommentSupport>, IVideoCommentSupport
    {
        public override Expression<Func<VideoCommentSupport, bool>> GetByIdKey(int id)
        {
            return u => u.VCS_ID == id;
        }

        public override Expression<Func<VideoCommentSupport, string>> GetKey()
        {
            return u => u.VCS_ID.ToString();
        }
    }
}
