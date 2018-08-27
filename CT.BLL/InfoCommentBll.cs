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
    public class InfoCommentBll : BaseBll<InfoComment>
    {
        public override IBase<InfoComment> GetDal()
        {
            return DataAccess.CreateInfoComment();
        }
    } 
}
