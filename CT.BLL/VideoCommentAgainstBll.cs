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
    public partial class VideoCommentAgainstBll : BaseBll<VideoCommentAgainst>
    {
        public override IBase<VideoCommentAgainst> GetDal()
        {
            return DataAccess.CreateVideoCommentAgainst();
        }
    }
}