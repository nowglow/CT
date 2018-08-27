using CT.IDAL;
using CT.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CT.DAL
{
    public class VideoDal : BaseDal<Video>, IVideo
    {
        public override Expression<Func<Video, bool>> GetByIdKey(int id)
        {

            return u => u.Video_ID == id;
        }

        public override Expression<Func<Video, string>> GetKey()
        {
            return u => u.Video_Title;
        }
        //DbContext dbContext = DbContextFactory.CreateDbContext();

        //public int Delete(Video model)
        //{
        //    dbContext.Set<Video>().Add(model);
        //    return dbContext.SaveChanges();
        //}
    }
}
