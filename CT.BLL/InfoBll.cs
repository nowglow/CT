using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CT.DALFactory;
using CT.IDAL;
using CT.Model;

namespace CT.BLL
{
    public class InfoBll:BaseBll<Info>
    {
        public override IBase<Info> GetDal()
        {
            return DataAccess.CreateInfo();
        }
       
    }
}
