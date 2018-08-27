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
    public class VideoCommentBackDal : BaseDal<VideoCommentBack>, IVideoCommentBack
    {
        public override Expression<Func<VideoCommentBack, bool>> GetByIdKey(int id)
        {
            return u => u.VCB_ID == id;
        }

        public override Expression<Func<VideoCommentBack, string>> GetKey()
        {
            return u => u.VCB_ID.ToString();
        }
    }
}
