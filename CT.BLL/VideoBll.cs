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
    public class VideoBll : BaseBll<Video>
    {
        public override IBase<Video> GetDal()
        {
            return DataAccess.CreateVideo();
        }
        //public bool Addvideo(Video video)
        //{
        //    return DataAccess.CreateVideo().Addvideo(video) > 0;
        //}
    }
}
