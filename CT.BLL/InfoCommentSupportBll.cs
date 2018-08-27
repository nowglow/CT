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
    public class InfoCommentSupportBll : BaseBll<InfoCommentSupport>
    {
        public override IBase<InfoCommentSupport> GetDal()
        {
            return DataAccess.CreateInfoCommentSupport();
        }
    }
}
