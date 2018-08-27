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
    public class AdminHomeController : Controller
    {
        AdminBll AdminService = new AdminBll();
        private CTEntities db = new CTEntities();

        public ActionResult Index()
        {
            ViewBag.InfoSupport = (from a in db.Info
                                  select new InfoCommentSupportModel
                                  {
                                      Info_ID = a.Info_ID,
                                      Info_Title = a.Info_Title,
                                      InfoSupportNum = db.InfoCommentSupport.Where(u => u.Info_ID == a.Info_ID).Count()
                                  }).OrderBy(u => u.InfoSupportNum).Take(5);
            ViewBag.InfoAgainst= (from a in db.Info
                                 select new InfoCommentAgainstModel
                                 {
                                     Info_ID = a.Info_ID,
                                     Info_Title = a.Info_Title,
                                     InfoAgainstNum = db.InfoCommentAgainst.Where(u => u.Info_ID == a.Info_ID).Count()
                                 }).OrderBy(u => u.InfoAgainstNum).Take(5);

            ViewBag.VideoSupport =( from a in db.Video
                                  select new VideoCommentSupportModel
                                  {
                                      Video_ID = a.Video_ID,
                                      Video_Title = a.Video_Title,
                                      VideoSupportNum = db.VideoCommentSupport.Where(u => u.Video_ID == a.Video_ID).Count()
                                  }).OrderBy(u=>u.VideoSupportNum).Take(5);
            ViewBag.VideoAgainst = (from a in db.Video
                                   select new VideoCommentAgainstModel
                                   {
                                       Video_ID = a.Video_ID,
                                       Video_Title = a.Video_Title,
                                       VideoAgainsttNum = db.VideoCommentSupport.Where(u => u.Video_ID == a.Video_ID).Count()
                                   }).OrderBy(u => u.VideoAgainsttNum).Take(5);
            return View();
        }
       
    }
}