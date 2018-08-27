using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CT.BLL;
using CT.Model;
using CT.UI.Models;
namespace CT.UI.Controllers
{
    public class AdminLoginController : Controller
    {
        AdminBll adminService = new AdminBll();
        // GET: AdminLogin
        //登录
        public ActionResult Login()
        {
            return View();
        }
        //登录验证
        [HttpPost]
        public ActionResult Login(string adminName,string adminPwd)
        {
            adminName = Request["LoginName"];
            adminPwd = Request["LoginPwd"];
            if (ModelState.IsValid)
            {
                var adminInfo = adminService.GetAll().Where(m => m.Admin_Name == adminName && m.Admin_Password == adminPwd).FirstOrDefault();
                //var adminInfo = from a in adminService.GetAll().AsEnumerable()
                //                 where a.Admin_Name == adminName && a.Admin_Password == adminPwd
                //                 select new Admin
                //                 {
                //                     Admin_Name = a.Admin_Name,
                //                     Admin_Password = a.Admin_Password,
                //                     Admin_ID = a.Admin_ID
                //                 };
                if (adminInfo != null)
                {
                    Session["Admin_Name"] = adminInfo.Admin_Name;
                    
                    return Content("<script>;alert('登录成功!返回首页!');window.location.href='/AdminHome/Index'</script>");
                }
                else
                {
                    return Content("<script>;alert('登录失败！用户名或密码错误!');window.location.href='/AdminLogin/Login'</script>");
                }
            }
            else
            {
                return View("Admin_Add");
            }
            
            
        }
    }
}