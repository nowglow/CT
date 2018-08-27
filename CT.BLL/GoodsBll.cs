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
    public class GoodsBll : BaseBll<Goods>
    {
        public override IBase<Goods> GetDal()
        {
            return DataAccess.CreateGoods();
        }
    }
}
