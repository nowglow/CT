using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CT.IDAL;
using CT.Model;
using CT.DALFactory;
namespace CT.BLL
{
    public class GoodsTypeBll : BaseBll<GoodsType>
    {
        public override IBase<GoodsType> GetDal()
        {
            return DataAccess.CreateGoodsType();
        }
    }
}
