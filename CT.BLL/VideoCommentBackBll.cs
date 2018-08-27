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
    public class VideoCommentBackBll : BaseBll<VideoCommentBack>
    {
        public override IBase<VideoCommentBack> GetDal()
        {
            return DataAccess.CreateVideoCommentBack();
        }
    }
}
