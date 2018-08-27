using CT.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CT.DAL
{
    public abstract class BaseDal<T> where T:class
    {
        DbContext dbContext = DbContextFactory.CreateDbContext();

        //companyEntities db = new companyEntities();

        //获取全部数据
        public IQueryable<T> GetAll()
        {
            return dbContext.Set<T>();
        }
        public IQueryable<T> GetList(int pageSize, int pageIndex)
        {
            return dbContext.Set<T>().OrderBy(GetKey()).Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }
        //获取某条数据具体信息
        public T GetById(int id)
        {
            return dbContext.Set<T>().Where(GetByIdKey(id)).FirstOrDefault();
        }
        public int Add(T model)
        {
            dbContext.Set<T>().Add(model);
            return dbContext.SaveChanges();
        }
        public int Edit(T model)
        {
            dbContext.Set<T>().Attach(model);
            dbContext.Entry(model).State = EntityState.Modified;
            return dbContext.SaveChanges();
        }
        public int Remove(int id)
        {
            T model = dbContext.Set<T>().Where(GetByIdKey(id)).FirstOrDefault();
            dbContext.Set<T>().Remove(model);
            return dbContext.SaveChanges();
        }
        public abstract Expression<Func<T, string>> GetKey();
        public abstract Expression<Func<T, bool>> GetByIdKey(int id);

        public int GetCount()
        {
            return dbContext.Set<T>().Count();
        }

       
    }
}
