using CT.Common;
using CT.Model;
using CT.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CT.UI.Controllers
{
    public class VideoClassController : Controller
    {
        BLL.VideoClassBll videoClassBll = new BLL.VideoClassBll();

        #region 前台展示

        public PartialViewResult VideoMenu()
        {

           //ViewBag.videoClassModel = videoClassBll.GetAll();
            return PartialView();
        }

        #endregion
        #region 视频评测分类后台管理
        // 评测分类列表主页
        public ActionResult Index(int pageIndex = 1)
        {           
            var videoClasses = videoClassBll.GetAll();
            PagingHelper<VideoClass> StudentPaging = new PagingHelper<VideoClass>(3, videoClasses);//初始化分页器
            StudentPaging.PageIndex = pageIndex;//指定当前页
            return View(StudentPaging);//返回分页器实例到视图
        }

        #region 添加分类

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VideoClassModel videoClass)
        {
            VideoClass @class = new VideoClass
            {
                Video_Class = videoClass.Video_Class
            };
            var temp = videoClassBll.Add(@class);
            if (temp == true)
            {
                return RedirectToAction("Index");
            }
            return View(videoClass);
        }
        #endregion

        #region 修改
        public ActionResult Edit(int id)
        {
            VideoClass videoClass= videoClassBll.SelectID(id);
            return View(videoClass);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VideoClass videoClass)
        {
            videoClassBll.Edit(videoClass);
            return RedirectToAction("Index");
        }
        #endregion

        #region 删除
        public ActionResult Delete(int id)
        {
            videoClassBll.DeleteID(id);
            return RedirectToAction("Index");
        }
        #endregion 

        #endregion
    }
}