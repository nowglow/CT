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
    public class InfoDal : BaseDal<Info>, IInfo
    {
        DbContext dbContext = DbContextFactory.CreateDbContext();
        public override Expression<Func<Info, bool>> GetByIdKey(int id)
        {
            return u => u.Info_ID == id;
        }

        public override Expression<Func<Info, string>> GetKey()
        {
            return u => u.Info_Title;
        }
        
    }
}
