using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CT.Model;
using CT.IDAL;
using CT.DALFactory;
namespace CT.BLL
{
    public partial class VideoCommentSupportBll : BaseBll<VideoCommentSupport>
    {
        public override IBase<VideoCommentSupport> GetDal()
        {
            return DataAccess.CreateVideoCommentSupport();
        }
    }
}
