using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CT.BLL;
using CT.Model;

namespace CT.UI.Controllers
{
    public class InfoCommentBacksController : Controller
    {
        private CTEntities db = new CTEntities();
      
        InfoCommentBackBll InfoCommentBackBll = new InfoCommentBackBll();
        // GET: InfoCommentBack
        #region 评论回复
        [HttpPost]
        public ActionResult ReplyComments(int icid)
        {

            if (ModelState.IsValid)
            {
                string replytext = Request.Form["textarea1"];
                InfoCommentBack icbmodel = new InfoCommentBack();
                if (replytext == null)
                {
                    return Content("<script>;alert('回复内容不为空');</script>");
                }
                else
                {
                    icbmodel.ICB_Content = replytext;
                    icbmodel.ICB_Time = System.DateTime.Now;
                    icbmodel.IC_ID = icid;
                    icbmodel.UserInfo_ID = Convert.ToInt32(Session["user_ID"]);
                    var success = InfoCommentBackBll.Add(icbmodel);
                    if (success == true)
                        return Content("<script>;alert('回复成功！');</script>");


                }
            }
            return View();
        }
        #endregion
        // GET: InfoCommentBacks
        public ActionResult Index()
        {
            var infoCommentBack = db.InfoCommentBack.Include(i => i.UserInfo);
            return View(infoCommentBack.ToList());
        }

        // GET: InfoCommentBacks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InfoCommentBack infoCommentBack = db.InfoCommentBack.Find(id);
            if (infoCommentBack == null)
            {
                return HttpNotFound();
            }
            return View(infoCommentBack);
        }

      


        // GET: InfoCommentBacks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InfoCommentBack infoCommentBack = db.InfoCommentBack.Find(id);
            if (infoCommentBack == null)
            {
                return HttpNotFound();
            }
            return View(infoCommentBack);
        }

        // POST: InfoCommentBacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InfoCommentBack infoCommentBack = db.InfoCommentBack.Find(id);
            db.InfoCommentBack.Remove(infoCommentBack);
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
