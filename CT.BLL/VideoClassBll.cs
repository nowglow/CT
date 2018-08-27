using CT.DALFactory;
using CT.IDAL;
using CT.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CT.BLL
{
    public class VideoClassBll : BaseBll<VideoClass>
    {
        public override IBase<VideoClass> GetDal()
        {
            return DataAccess.CreateVideoClass();
        }
        public VideoClass SelectID(int id)
        {
            return DataAccess.CreateVideoClass().SelectID(id);
        }
        public bool DeleteID(int id)
        {
            return DataAccess.CreateVideoClass().DeleteID(id) > 0;
        }
    }
}
