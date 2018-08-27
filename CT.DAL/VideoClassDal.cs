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
    public class VideoClassDal:BaseDal<VideoClass>, IVideoClass
    {
        public override Expression<Func<VideoClass, bool>> GetByIdKey(int id)
        {

            return u => u.VideoClass_ID == id;
        }

        public override Expression<Func<VideoClass, string>> GetKey()
        {
            return u => u.VideoClass_ID.ToString();
        }
        DbContext dbContext = DbContextFactory.CreateDbContext();
        public VideoClass SelectID(int id)
        {
            return dbContext.Set<VideoClass>().Where(u=>u.VideoClass_ID==id).FirstOrDefault();
        }
        public int DeleteID(int id)
        {
            VideoClass model = dbContext.Set<VideoClass>().Where(u => u.VideoClass_ID == id).FirstOrDefault();
            dbContext.Set<VideoClass>().Remove(model);
            return dbContext.SaveChanges();
        }
    }
}
