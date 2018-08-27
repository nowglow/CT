using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CT.Model;
using CT.BLL;
namespace CT.UI.Controllers
{
    public class VideoCommentBacksController : Controller
    {
        VideoCommentBackBll VideoCommentBackBll = new VideoCommentBackBll();
        private CTEntities db = new CTEntities();
        #region 评论回复
        [HttpPost]
        public ActionResult ReplyComments(int vcid)
        {

            if (ModelState.IsValid)
            {
                string replytext = Request.Form["textarea1"];
                VideoCommentBack vcbmodel = new VideoCommentBack();
                if (replytext == null)
                {
                    return Content("<script>;alert('回复内容不为空');</script>");
                }
                else
                {
                    vcbmodel.VCB_Content = replytext;
                    vcbmodel.VCB_Time = System.DateTime.Now;
                    vcbmodel.VC_ID = vcid;
                    vcbmodel.UserInfo_ID = Convert.ToInt32(Session["user_ID"]);
                    var success = VideoCommentBackBll.Add(vcbmodel);
                    if (success == true)
                        return Content("<script>;alert('回复成功！');</script>");


                }
            }
            return View();
        }
        #endregion
        // GET: VideoCommentBacks
        public ActionResult Index()
        {
            var videoCommentBack = db.VideoCommentBack.Include(v => v.UserInfo);
            return View(videoCommentBack.ToList());
        }

        // GET: VideoCommentBacks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoCommentBack videoCommentBack = db.VideoCommentBack.Find(id);
            if (videoCommentBack == null)
            {
                return HttpNotFound();
            }
            return View(videoCommentBack);
        }

       

        // GET: VideoCommentBacks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoCommentBack videoCommentBack = db.VideoCommentBack.Find(id);
            if (videoCommentBack == null)
            {
                return HttpNotFound();
            }
            return View(videoCommentBack);
        }

        // POST: VideoCommentBacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VideoCommentBack videoCommentBack = db.VideoCommentBack.Find(id);
            db.VideoCommentBack.Remove(videoCommentBack);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
