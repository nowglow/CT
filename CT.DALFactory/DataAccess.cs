using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CT.IDAL;
using CT.DAL;
namespace CT.DALFactory
{
    public class DataAccess
    {
        private static string AssemblyName = ConfigurationManager.AppSettings["Path"].ToString();
        private static string db = ConfigurationManager.AppSettings["DB"].ToString();
        //添加每个表单的会话状态


        public static IUserInfo CreateUser()
        {
            string className = AssemblyName + "." + db + "UserInfoDal";
            return (IUserInfo)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static IAdmin CreateAdmin()
        {
            string className = AssemblyName + "." + db + "AdminDal";
            return (IAdmin)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static IICC CreateICC()
        {
            string className = AssemblyName + "." + db + "ICCDal";
            return (IICC)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static IInfo CreateInfo()
        {
            string className = AssemblyName + "." + db + "InfoDal";
            return (IInfo)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static IInfoClass CreateInfoClass()
        {
            string className = AssemblyName + "." + db + "InfoClassDal";
            return (IInfoClass)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static IInfoComment CreateInfoComment()
        {
            string className = AssemblyName + "." + db + "InfoCommentDal";
            return (IInfoComment)Assembly.Load(AssemblyName).CreateInstance(className);

        }
        public static IInfoCommentAgainst CreateInfoCommentAgainst()
        {
            string className = AssemblyName + "." + db + "InfoCommentAgainstDal";
            return (IInfoCommentAgainst)Assembly.Load(AssemblyName).CreateInstance(className);

        }
        public static IInfoCommentBack CreateInfoCommentBack()
        {
            string className = AssemblyName + "." + db + "InfoCommentBackDal";
            return (IInfoCommentBack)Assembly.Load(AssemblyName).CreateInstance(className);

        }
        public static IInfoCommentSupport CreateInfoCommentSupport()
        {
            string className = AssemblyName + "." + db + "InfoCommentSupportDal";
            return (IInfoCommentSupport)Assembly.Load(AssemblyName).CreateInstance(className);

        }
        public static IVideo CreateVideo()
        {
            string className = AssemblyName + "." + db + "VideoDal";
            return (IVideo)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static IVideoClass CreateVideoClass()
        {
            string className = AssemblyName + "." + db + "VideoClassDal";
            return (IVideoClass)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static IVideoComment CreateVideoComment()
        {
            string className = AssemblyName + "." + db + "VideoCommentDal";
            return (IVideoComment)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static IVideoCommentAgainst CreateVideoCommentAgainst()
        {
            string className = AssemblyName + "." + db + "VideoCommentAgainstDal";
            return (IVideoCommentAgainst)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static IVideoCommentBack CreateVideoCommentBack()
        {
            string className = AssemblyName + "." + db + "VideoCommentBackDal";
            return (IVideoCommentBack)Assembly.Load(AssemblyName).CreateInstance(className);
        }

        public static IVideoCommentSupport CreateVideoCommentSupport()
        {
            string className = AssemblyName + "." + db + "VideoCommentSupportDal";
            return (IVideoCommentSupport)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static IGoods CreateGoods()
        {
            string className = AssemblyName + "." + db + "GoodsDal";
            return (IGoods)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static IGoodsType CreateGoodsType()
        {
            string className = AssemblyName + "." + db + "GoodsTypeDal";
            return (IGoodsType)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static IBorder CreateBorder()
        {
            string className = AssemblyName + "." + db + "BorderDal";
            return (IBorder)Assembly.Load(AssemblyName).CreateInstance(className);
        }
    }
}
