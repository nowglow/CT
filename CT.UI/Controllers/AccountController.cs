using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CT.BLL;
using CT.UI.Models;
using CT.Model;

namespace CT.UI.Controllers
{
    public class AccountController : Controller
    {
        UserInfoBll UserInfoService = new UserInfoBll();

        #region 用户头像和用户名
        public PartialViewResult Userinfo()
        {

            return PartialView();
        }
        #endregion
        #region 登录
        // 登录
        public ActionResult Login()
        {
            return View();
        }
        //登录验证
        public ActionResult CheckLogin()
        {
            string validateCode = Session["validateCode"] == null ? string.Empty : Session["validateCode"].ToString();
            if (string.IsNullOrEmpty(validateCode))
            {
                return Content("no:验证码错误!");
            }
            Session["validateCode"] = null;
            string requestCode = Request["vCode"];
            if (!requestCode.Equals(validateCode, StringComparison.InvariantCultureIgnoreCase))
            {
                return Content("no:验证码错误!!");
            }
            string userName = Request["LoginCode"];
            string userPwd = Request["LoginPwd"];

            var userInfo = UserInfoService.GetUserInfoModel(userName, userPwd);
            if (userInfo != null)
            {
                Session["user_ID"] = userInfo.UserInfo_ID;
                Session["user_Name"] = userInfo.UserInfo_Name;
                Session["user_Img"] = userInfo.UserInfo_Img;
                
                //return View("~/Views/Home/Index.cshtml",new { name=userName});
                return Content("ok:用户名密码错误");
            }
            else
            {
                return Content("no:用户名密码错误");
            }
        }
      
        #endregion

        #region 注册
        //注册
        public ActionResult Register()
        {
            return View();
        }
        //注册验证      
        public ActionResult CheckRegister(RegisterModel registerModel)
        {
            string validateCode = Session["validateCode"] == null ? string.Empty : Session["validateCode"].ToString();
            if (string.IsNullOrEmpty(validateCode))
            {
                return Content("no:验证码错误!");
            }
            Session["validateCode"] = null;
            string requestCode = Request["vCode"];
            if (!requestCode.Equals(validateCode, StringComparison.InvariantCultureIgnoreCase))
            {
                return Content("no:验证码错误!!");
            }           
            CT.Model.UserInfo userInfo = new Model.UserInfo
            {
                UserInfo_Name = registerModel.User_Name,
                UserInfo_Password = registerModel.User_Password,
                UserInfo_Email = registerModel.User_Email,
                UserInfo_Phone = registerModel.User_Phone,
                UserInfo_Img = registerModel.User_Img
            };        
            var adduser = UserInfoService.Add(userInfo);
            if (adduser == true)
            {
                return Content("ok:注册成功");
            }
            else
            {
                return Content("no:注册失败");
            }
        }
        #endregion

        #region 上传图片
        public ActionResult FileUpload()
        {
            HttpPostedFileBase file = Request.Files["MenuIcon"];
            if (file == null)
            {
                return Content("no:上传文件不能为空!");
            }
            else
            {
                string fileName = Path.GetFileName(file.FileName);
                string fileExt = Path.GetExtension(fileName);
                if (fileExt == ".jpg"|| fileExt==".png")
                {
                    string dir = "/FileUploadImage/" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day + "/";
                    Directory.CreateDirectory(Path.GetDirectoryName(Request.MapPath(dir)));
                    string newfileName = Guid.NewGuid().ToString();
                    string fullDir = dir + newfileName + fileExt;
                    file.SaveAs(Request.MapPath(fullDir));
                    return Content("ok:" + fullDir);
                }
                else
                {
                    return Content("no:上传文件格式错误!!");
                }
            }
        }
        #endregion

        // 验证码
        public ActionResult ValidateCode()
        {
            Common.ValidateCode validateCode = new Common.ValidateCode();
            string code = validateCode.CreateValidateCode(4);
            Session["validateCode"] = code;
            byte[] buffer = validateCode.CreateValidateGraphic(code);
            return File(buffer, "image/jpeg");
        }
    }
}