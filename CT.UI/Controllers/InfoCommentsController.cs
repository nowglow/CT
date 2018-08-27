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
    public class InfoCommentsController : Controller
    {
        private CTEntities db = new CTEntities();
        InfoCommentBll InfoCommentBll = new InfoCommentBll();
        #region 评论
        
        [HttpPost]
        public ActionResult InfoComment()
        {

            if (ModelState.IsValid)
            {
                string commentcontent = Request.Form["comment-text"];
                int infoid = Convert.ToInt32(Session["infoid"]);
                InfoComment infocommentmodel = new InfoComment();
                infocommentmodel.UserInfo_ID = Convert.ToInt32(Session["user_ID"]);
                infocommentmodel.Info_ID = infoid;
                infocommentmodel.IC_Time = System.DateTime.Now;
                infocommentmodel.IC_Content = commentcontent;
                var have = InfoCommentBll.Add(infocommentmodel);
                if (have == true)
                {
                    return Content("<script>;alert('评论成功!');history.go(-1)</script>");
                }

            }
            return RedirectToAction("Info_Details", "Info");
        }
        #endregion
        // GET: InfoComments
        public ActionResult Index()
        {
            var infoComment = db.InfoComment.Include(i => i.Info).Include(i => i.UserInfo);
            return View(infoComment.ToList());
        }

        // GET: InfoComments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InfoComment infoComment = db.InfoComment.Find(id);
            if (infoComment == null)
            {
                return HttpNotFound();
            }
            return View(infoComment);
        }

        // GET: InfoComments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InfoComment infoComment = db.InfoComment.Find(id);
            if (infoComment == null)
            {
                return HttpNotFound();
            }
            return View(infoComment);
        }

        // POST: InfoComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InfoComment infoComment = db.InfoComment.Find(id);
            db.InfoComment.Remove(infoComment);
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
