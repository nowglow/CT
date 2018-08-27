using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CT.BLL;
using CT.UI.Models;
namespace CT.UI.Controllers
{
    public class InfoCommentSupportController : Controller
    {
        InfoCommentSupportBll InfoCommentSupportBll = new InfoCommentSupportBll();

        // GET: InfoCommentSupport
        public PartialViewResult Index()
        {
            ////点赞功能
            //CT.Model.InfoCommentSupport supportModel = new Model.InfoCommentSupport
            //{
                
            //    Info_ID = infoid,
            //    UserInfo_ID = Convert.ToInt32(Session["user_ID"])
            //};


            ////资讯点赞数
            //ViewBag.InfoSupportNum = InfoCommentSupportBll.GetAll().Where(u => u.Info_ID == infoid).Count();

            ////查询用户是否点过赞
            //ViewBag.infosupport = InfoCommentSupportBll.GetAll().Where(u => u.Info_ID == infoid && u.UserInfo_ID ==Convert.ToInt32(Session["user_ID"])).FirstOrDefault();
            
            ////如果点过赞，则取消点赞
            //if (ViewBag.infosupport != null)
            //{

            //    ViewBag.InfoSupportNum = InfoCommentSupportBll.GetAll().Where(u => u.Info_ID == infoid).Count() - 1;
                
            //    InfoCommentSupportBll.Remove(ViewBag.infosupport.ICS_ID);

            //}
            ////如果没点过赞，则点赞数加1
            //else
            //{
            //    InfoCommentSupportBll.Add(supportModel);
            //    ViewBag.InfoSupportNum = InfoCommentSupportBll.GetAll().Where(u => u.Info_ID == infoid).Count() + 1;
            //}
            return PartialView();
        }
    }
}