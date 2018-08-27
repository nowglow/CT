using CT.IDAL;
using CT.Model;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace CT.DAL
{
    public class UserInfoDal : BaseDal<UserInfo>, IUserInfo
    {
        DbContext dbContext = DbContextFactory.CreateDbContext();
        public override Expression<Func<UserInfo, bool>> GetByIdKey(int id)
        {
           
            return u => u.UserInfo_ID==id;
        }

        public override Expression<Func<UserInfo, string>> GetKey()
        {
            return u => u.UserInfo_ID.ToString();
        }
        public UserInfo GetUserInfoModel(string userName, string userPwd)
        {
            var userInfo = dbContext.Set<UserInfo>().Where(u => u.UserInfo_Name == userName && u.UserInfo_Password == userPwd).FirstOrDefault();
            return userInfo;
        }
        //public int AddUser(UserInfo userInfo)
        //{
        //    dbContext.Set<UserInfo>().Add(userInfo);
        //    return dbContext.SaveChanges();
        //}
    }
}
