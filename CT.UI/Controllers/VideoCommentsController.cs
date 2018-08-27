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
    public class VideoCommentsController : Controller
    {
        private CTEntities db = new CTEntities();
        VideoCommentBll videoCommentBll = new VideoCommentBll();
        #region 评论

        [HttpPost]
        public ActionResult VideoComment()
        {

            if (ModelState.IsValid)
            {
                string commentcontent = Request.Form["comment-text"];
                int videoid = Convert.ToInt32(Session["videoid"]);
                VideoComment videocommentmodel = new VideoComment();
                videocommentmodel.UserInfo_ID = Convert.ToInt32(Session["user_ID"]);
                videocommentmodel.Video_ID = videoid;
                videocommentmodel.VC_Time = System.DateTime.Now;
                videocommentmodel.VC_Content = commentcontent;
                var have = videoCommentBll.Add(videocommentmodel);
                if (have == true)
                {
                    return Content("<script>;alert('评论成功!');history.go(-1)</script>");
                }

            }
            return RedirectToAction("Video_Details", "Video");
        }
        #endregion
        // GET: VideoComments
        public ActionResult Index()
        {
            var videoComment = db.VideoComment.Include(v => v.UserInfo).Include(v => v.Video);
            return View(videoComment.ToList());
        }

        // GET: VideoComments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoComment videoComment = db.VideoComment.Find(id);
            if (videoComment == null)
            {
                return HttpNotFound();
            }
            return View(videoComment);
        }

        // GET: VideoComments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoComment videoComment = db.VideoComment.Find(id);
            if (videoComment == null)
            {
                return HttpNotFound();
            }
            return View(videoComment);
        }

        // POST: VideoComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VideoComment videoComment = db.VideoComment.Find(id);
            db.VideoComment.Remove(videoComment);
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
