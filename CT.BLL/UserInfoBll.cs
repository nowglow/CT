using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CT.Model;
using CT.IDAL;
using CT.DALFactory;
namespace CT.BLL
{
    public class UserInfoBll : BaseBll<UserInfo>
    {
        public override IBase<UserInfo> GetDal()
        {
            return DataAccess.CreateUser();
        }
        //登录
        public UserInfo GetUserInfoModel(string userName, string userPwd)
        {
            var userinfo = DataAccess.CreateUser().GetUserInfoModel(userName, userPwd);
            return userinfo;
        }

        //public bool AddUser(UserInfo userInfo)
        //{
        //    int temp = DataAccess.CreateUser().AddUser(userInfo);
        //    return temp > 0;
        //}
    }
}
