using CT.BLL;
using CT.Common;
using CT.Model;
using CT.UI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CT.UI.Controllers
{
    public class VideoController : Controller
    {
        VideoBll videoBll = new VideoBll();
        VideoClassBll videoClassBll = new VideoClassBll();
        VideoCommentBll VideoCommentBll = new VideoCommentBll();
        VideoCommentBackBll VideoCommentBackBll = new VideoCommentBackBll();
        VideoCommentAgainstBll VideoCommentAgainstBll = new VideoCommentAgainstBll();
        VideoCommentSupportBll VideoCommentSupportBll = new VideoCommentSupportBll();
        private CTEntities db = new CTEntities();
        #region 前台展示

        public ActionResult VideoIndex(int ? id,int pageIndex=1)
        {
            ViewBag.videoClassModel = videoClassBll.GetAll();
            ViewBag.videoinfo = videoBll.GetAll().OrderBy(u => u.Video_ID).Take(6);
            var Videos = from a in  videoBll.GetAll()
                             select  new VideoModel {
                                 Video_ID=a.Video_ID,
                                 Video_Title=a.Video_Title,
                                 Video_Img=a.Video_Img,
                                 VideoClass_ID=a.VideoClass_ID,
                                 Video_Url=a.Video_Url
                             };
            if (id != null)
            {

                Videos = Videos.Where(u => u.VideoClass_ID == id);
            }
            ViewBag.Videos = Videos;
            var videoClasses = videoClassBll.GetAll();
            PagingHelper<VideoModel> StudentPaging = new PagingHelper<VideoModel>(3, Videos);//初始化分页器
            StudentPaging.PageIndex = pageIndex;//指定当前页
            return View(StudentPaging);//返回分页器实例到视图
        }
        #region 前台视频详情页
        public ActionResult Video_Details(int videoid,string support,string against)
        {
            ViewBag.videoClassModel = videoClassBll.GetAll();
            ViewBag.videoinfo = videoBll.GetAll().OrderBy(u => u.Video_ID).Take(6);
            ViewBag.videoupdate = videoBll.GetAll().OrderByDescending(u => u.Video_Time).Take(3);
            var Video =(from a in videoBll.GetAll()
                         select new VideoModel
                         {
                             Video_ID=a.Video_ID,
                             Video_Title = a.Video_Title,
                             Video_Img = a.Video_Img,
                             VideoClass_ID = a.VideoClass_ID,
                             Video_Url=a.Video_Url
                             
                         }).Where(u=>u.Video_ID==videoid).FirstOrDefault();
            #region 点赞
            ViewBag.videosupportnum = db.VideoCommentSupport.Where(u => u.Video_ID == videoid).Count();
            VideoCommentSupport supportModel1 = new VideoCommentSupport();
            if (Session["user_ID"] != null)
            {
                int id = Convert.ToInt32(Session["user_ID"]);
                //查询用户是否点过赞
                ViewBag.videosupport = db.VideoCommentSupport.Where(u => u.UserInfo_ID == id && u.Video_ID == videoid).FirstOrDefault();

                if (ViewBag.videosupport == null)
                {
                    if (support == "yes")
                    {
                        
                        supportModel1.Video_ID = videoid;
                        supportModel1.UserInfo_ID = int.Parse(Session["user_ID"].ToString());
                        var addSupport = VideoCommentSupportBll.Add(supportModel1);
                        if (addSupport == true)

                            return Content("<script>;alert('点赞成功!');window.location.href='/Video/Video_Details?videoid=" + videoid + "' </script>");
                    }

                }
                else
                {
                    if (support == "no")
                    {

                        var deleteSupport = VideoCommentSupportBll.Remove(ViewBag.videosupport.VCS_ID);
                        return Content("<script>;alert('取消点赞成功!');window.location.href='/Video/Video_Details?videoid=" + videoid + "' </script>");
                        
                    }
                }
            }

            #endregion
            #region 反对
            ViewBag.videoagainstnum = db.VideoCommentAgainst.Where(u => u.Video_ID == videoid).Count();
            VideoCommentAgainst againstModel = new VideoCommentAgainst();
            if (Session["user_ID"] != null)
            {
                int id = Convert.ToInt32(Session["user_ID"]);
                //查询用户是否踩过
                ViewBag.videoagainst = db.VideoCommentAgainst.Where(u => u.UserInfo_ID == id && u.Video_ID == videoid).FirstOrDefault();

                if (ViewBag.videoagainst == null)
                {
                    if (against == "yes")
                    {
                        
                        againstModel.Video_ID = videoid;
                        againstModel.UserInfo_ID = int.Parse(Session["user_ID"].ToString());
                        var addAgainst = VideoCommentAgainstBll.Add(againstModel);
                        if (addAgainst == true)

                            return Content("<script>;alert('反对成功!');window.location.href='/Video/Video_Details?videoid=" + videoid + "' </script>");
                    }

                }
                else
                {
                    if (against == "no")
                    {

                        var deleteAgainst = VideoCommentAgainstBll.Remove(ViewBag.videoagainst.VCA_ID);
                        return Content("<script>;alert('取消反对成功!');window.location.href='/Video/Video_Details?videoid=" + videoid + "' </script>");
                        
                    }
                }
            }

            #endregion
            return View(Video);
        }
        #endregion
        #region 展示评论回复
        public ActionResult VideoComment(int videoid, string support, string against)
        {
            int id = Convert.ToInt32(Session["videoid"]);
            var videoCommnetModel = new VideoCommentModel()
            {
                VideoComment = VideoCommentBll.GetAll().Where(u => u.Video_ID == id).AsEnumerable().ToList(),
                VideoCommentBack = VideoCommentBackBll.GetAll().AsEnumerable().ToList()
            };
            return View(videoCommnetModel);
        }
        #endregion
        #endregion

        #region 视频评测后台管理
        //主页
        public ActionResult Index(int pageIndex=1)
        {           
            var video= videoBll.GetAll();
            var videoClasses = videoClassBll.GetAll();
            var videoModel = from a in video
                             join b in videoClasses on a.VideoClass_ID equals b.VideoClass_ID
                             select new VideoModel
                             {
                                 Video_ID = a.Video_ID,
                                 Video_Title = a.Video_Title,
                                 Video_Img = a.Video_Img,
                                 Video_Url = a.Video_Url,
                                 Video_Class = b.Video_Class,
                                 Video_Time = a.Video_Time,
                                 VideoClass_ID=a.VideoClass_ID
                             };

            PagingHelper<VideoModel> StudentPaging = new PagingHelper<VideoModel>(5, videoModel);//初始化分页器,及每页显示数量
            StudentPaging.PageIndex =pageIndex;//指定当前页
            return View(StudentPaging);//返回分页器实例到视图
        }

        #region 添加视频评测
        public ActionResult Create(int? id)
        {           
            ViewBag.videoClass = new SelectList(videoClassBll.GetAll(), "VideoClass_ID", "Video_Class");
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AfterCreate(Video video)
        {
            if(video!=null)
            {

                video.Video_Time = DateTime.Now;
                
                var temp= videoBll.Add(video);
                if (temp == true)
                    return Content("ok:成功");
                else
                    return Content("no: 失败");

            }
            ViewBag.videoClass = new SelectList(videoClassBll.GetAll(), "VideoClass_ID", "Video_Class", video.VideoClass_ID);
            return View();
        }
        #endregion

        #region 修改视频评测
        public ActionResult Edit(int id)
        {
            ViewBag.videoClass = new SelectList(videoClassBll.GetAll(), "VideoClass_ID", "Video_Class");
            Video video = videoBll.GetById(id);
            VideoModel videoModel = new VideoModel
            {
                Video_Title = video.Video_Title.Trim(),
                VideoClass_ID=video.VideoClass_ID,
                Video_Img=video.Video_Img,
                Video_Url=video.Video_Url,
                Video_ID=video.Video_ID,
                
            };
            return View(videoModel);
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult AfterEdit(Video video)
        {
            if (video != null)
            {

                video.Video_Time = DateTime.Now;
                //Video updatevideo = new Video
                //{
                //    Video_Img = video.Video_Img,
                //    Video_Time = DateTime.Now,
                //    Video_Title = video.Video_Title,
                //    Video_Url = video.Video_Url,
                //    VideoClass_ID = video.VideoClass_ID,
                //    Video_ID=video.Video_ID
                //};
                var temp = videoBll.Edit(video);
                if (temp == true)
                    return Content("ok:成功");
                else
                    return Content("no: 失败");

            }
            ViewBag.videoClass = new SelectList(videoClassBll.GetAll(), "VideoClass_ID", "Video_Class", video.VideoClass_ID);
            return View();
        }
        #endregion

        #region 删除视频评测
        public ActionResult Delete(int id)
        {
            var temp= videoBll.Remove(id);
            if (temp == true)
                return RedirectToAction("Index");
            else
                return View();


        }
        #endregion
        #endregion


        #region 文件上传及其他辅助
        #region  分类下拉菜单栏

        /// <summary>
        ///     分类的下拉菜单
        /// </summary>
        /// <param name="selectedDepartment"></param>
        private void PopulateDepartmentsDropDownList(object selectedDepartment = null)
        {
            var videoClasses = videoClassBll.GetAll();
            var videoClass = from d in videoClasses orderby d.Video_Class select d;

            ViewBag.videoClass = new SelectList(videoClass.AsNoTracking(), "VideoClass_ID", "Video_Class", selectedDepartment);
        }

        #endregion

        #region 上传封面
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
                if (fileExt == ".jpg" || fileExt == ".png")
                {
                    string dir = "/UploadImg/" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/" /*+ DateTime.Now.Day + "/"*/;
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

        #region 上传视频
        public ActionResult FileUploadVideo()
        {
            HttpPostedFileBase file = Request.Files["MenuIcon1"];
            if (file == null)
            {
                return Content("no:上传文件不能为空!");
            }
            else
            {
                string fileName = Path.GetFileName(file.FileName);
                string fileExt = Path.GetExtension(fileName);
                if (fileExt == ".avi" || fileExt == ".mp4" || fileExt == ".Mp4" || fileExt == ".jpg" || fileExt == ".png" || fileExt == ".flv" || fileExt == ".Flv")
                {
                    string dir = "/UploadVideo/" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/";
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
        #endregion

        public ActionResult Test()
        {
            return View();
        }
    }
}