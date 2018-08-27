using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CT.BLL;
using CT.Common;
using CT.Model;
using CT.UI.Models;


namespace CT.UI.Controllers
{
    public class InfoController : Controller
    {
        UserInfoBll UserInfoBll = new UserInfoBll();
        InfoClassBll InfoClassBll = new InfoClassBll();
        ICCBll ICCBll = new ICCBll();
        InfoBll InfoBll = new InfoBll();
        InfoCommentSupportBll InfoCommentSupportBll = new InfoCommentSupportBll();
        InfoCommentAgainstBll InfoCommentAgainstBll = new InfoCommentAgainstBll();
        InfoCommentBackBll InfoCommentBackBll = new InfoCommentBackBll();
        InfoCommentBll InfoCommentBll = new InfoCommentBll();
        private CTEntities db = new CTEntities();

        VideoBll videoBll = new VideoBll();
        #region 前台展示信息
        #region 展示首页信息
        public ActionResult Info_Index()
        {
            ViewBag.infos = InfoBll.GetAll().OrderBy(u => u.Info_ID).Take(4);
            ViewBag.videos = videoBll.GetAll().OrderBy(u => u.Video_ID).Take(3);
            ViewBag.info1 = InfoBll.GetAll().OrderBy(u => u.Info_ID).FirstOrDefault();
            ViewBag.info2 = InfoBll.GetAll().OrderBy(u => u.Info_ID).Take(5);
            ViewBag.comment = InfoCommentBll.GetAll().OrderBy(u => u.Info_ID).Take(3);
            foreach(var item in ViewBag.comment)
            {
                int id = Convert.ToInt32(item.UserInfo_ID);
                ViewBag.userinfo = UserInfoBll.GetAll().Where(u => u.UserInfo_ID == id).FirstOrDefault();
            }
            return View();
        }
        #endregion
        #region 展示分类资讯
        public ActionResult InfoContent(int? id, string hasicc, int pageIndex = 1)
        {
            ViewBag.InfoSupport1 = (from a in db.Info
                                   select new InfoCommentSupportModel
                                   {
                                       Info_ID = a.Info_ID,
                                       Info_Title = a.Info_Title,
                                       InfoSupportNum = db.InfoCommentSupport.Where(u => u.Info_ID == a.Info_ID).Count()
                                   }).OrderBy(u => u.InfoSupportNum).Take(5);
            ViewBag.infocomment1 = InfoCommentBll.GetAll().OrderBy(u => u.Info_ID).Take(5);
            foreach(var we in ViewBag.infocomment1)
            {
                int id2 = Convert.ToInt32(we.UserInfo_ID);
                ViewBag.userinfo1 = db.UserInfo.Where(u => u.UserInfo_ID== id2);
            }
            ViewBag.infolatest = InfoBll.GetAll().OrderByDescending(u => u.Info_Time).Take(5);
            var infoModel = from a in InfoBll.GetAll()
                            join b in InfoClassBll.GetAll() on a.InfoClass_ID equals b.InfoClass_ID
                            join c in ICCBll.GetAll() on a.ICC_ID equals c.ICC_ID
                            select new InfoModel
                            {
                                Info_ID = a.Info_ID,
                                Info_Title = a.Info_Title,
                                Info_Content = a.Info_Content,
                                Info_Img = a.Info_Img,
                                Info_Time = a.Info_Time,
                                Info_Class = b.Info_Class,
                                InfoClass_ID = a.InfoClass_ID,
                                ICC_Name = c.ICC_Name,
                                ICC_ID = c.ICC_ID

                            };

            if (id != null)
            {
                infoModel = infoModel.Where(u => u.InfoClass_ID == id);

            }
           
            ViewBag.InfoModel = infoModel;
            PagingHelper<InfoModel> StudentPaging = new PagingHelper<InfoModel>(7, infoModel);//初始化分页器
            StudentPaging.PageIndex = pageIndex;//指定当前页
            return View(StudentPaging);//返回分页器实例到视图
        }
        #endregion
        #region 信息详情页
        public ActionResult Info_Details(int infoid,string support,string against)
        {
            ViewBag.infolatest = InfoBll.GetAll().OrderByDescending(u => u.Info_Time).Take(5);
            ViewBag.InfoSupport1 = (from a in db.Info
                                    select new InfoCommentSupportModel
                                    {
                                        Info_ID = a.Info_ID,
                                        Info_Title = a.Info_Title,
                                        InfoSupportNum = db.InfoCommentSupport.Where(u => u.Info_ID == a.Info_ID).Count()
                                    }).OrderBy(u => u.InfoSupportNum).Take(5);
            ViewBag.InfoClassModel = InfoClassBll.GetAll();
            Session["infoid"] = infoid;
            var infoModel1 = (from a in InfoBll.GetAll()
                              join b in InfoClassBll.GetAll() on a.InfoClass_ID equals b.InfoClass_ID
                              join c in ICCBll.GetAll() on a.ICC_ID equals c.ICC_ID
                              select new InfoModel
                              {
                                  Info_ID = a.Info_ID,
                                  Info_Title = a.Info_Title,
                                  Info_Content = a.Info_Content,
                                  Info_Img = a.Info_Img,
                                  Info_Time = a.Info_Time,
                                  ICC_Name = c.ICC_Name,
                                  ICC_ID = c.ICC_ID

                              }).Where(u => u.Info_ID == infoid).FirstOrDefault();

            #region 点赞
            ViewBag.infosupportnum = db.InfoCommentSupport.Where(u => u.Info_ID == infoid).Count();
    
            InfoCommentSupport supportModel = new InfoCommentSupport();
            if (Session["user_ID"] != null)
            {
                int id = Convert.ToInt32(Session["user_ID"]);
                //查询用户是否点过赞
                ViewBag.infosupport = db.InfoCommentSupport.Where(u => u.UserInfo_ID == id && u.Info_ID == infoid).FirstOrDefault();

                if (ViewBag.infosupport == null)
                {
                    if (support == "yes")
                    {
                        supportModel.Info_ID = infoid;
                        supportModel.UserInfo_ID = int.Parse(Session["user_ID"].ToString());
                        var addSupport = InfoCommentSupportBll.Add(supportModel);
                        if (addSupport == true)

                            return Content("<script>;alert('点赞成功!');window.location.href='/Info/Info_Details?infoid=" + infoid + "' </script>");
                    }

                }
                else
                {
                    if (support == "no")
                    {

                        var deleteSupport = InfoCommentSupportBll.Remove(ViewBag.infosupport.ICS_ID);
                        return Content("<script>;alert('取消点赞成功!');window.location.href='/Info/Info_Details?infoid=" + infoid + "' </script>");
                        //return Content("<script>;alert('取消点赞成功!');window.location.href("Info_Details.cshtml? code = "+string1+" & name = "+string2+" & detail = "+string3+" & count = ");</script>");
                    }
                }
            }

            #endregion
            #region 反对
            ViewBag.infoagainstnum = db.InfoCommentAgainst.Where(u => u.Info_ID == infoid).Count();
            InfoCommentAgainst againstModel = new InfoCommentAgainst();
            if (Session["user_ID"] != null)
            {
                int id = Convert.ToInt32(Session["user_ID"]);
                //查询用户是否踩过
                ViewBag.infoagainst = db.InfoCommentAgainst.Where(u => u.UserInfo_ID == id && u.Info_ID == infoid).FirstOrDefault();

                if (ViewBag.infoagainst == null)
                {
                    if (against == "yes")
                    {
                        againstModel.Info_ID = infoid;
                        againstModel.UserInfo_ID = int.Parse(Session["user_ID"].ToString());
                        var addAgainst = InfoCommentAgainstBll.Add(againstModel);
                        if (addAgainst == true)

                            return Content("<script>;alert('反对成功!');window.location.href='/Info/Info_Details?infoid=" + infoid + "' </script>");
                    }

                }
                else
                {
                    if (against == "no")
                    {

                        var deleteAgainst = InfoCommentAgainstBll.Remove(ViewBag.infoagainst.ICA_ID);
                        return Content("<script>;alert('取消反对成功!');window.location.href='/Info/Info_Details?infoid=" + infoid + "' </script>");
                        //return Content("<script>;alert('取消点赞成功!');window.location.href("Info_Details.cshtml? code = "+string1+" & name = "+string2+" & detail = "+string3+" & count = ");</script>");
                    }
                }
            }

            #endregion
            return View(infoModel1);
        }


        #endregion
        #region 展示评论回复
        public ActionResult InfoComment(int infoid, string support, string against)
        {
            
            int id = Convert.ToInt32(Session["infoid"]);
            var infoCommnetModel = new InfoCommentModel()
            {
                InfoComment = InfoCommentBll.GetAll().Where(u => u.Info_ID == id).AsEnumerable().ToList(),
                InfoCommentBack = InfoCommentBackBll.GetAll().AsEnumerable().ToList()
            };
            return View(infoCommnetModel);
        }
        #endregion
        #endregion
        #region 资讯信息后台管理
        //主页
        public ActionResult Index(int pageIndex = 1)
        {
            var infoModel = from a in InfoBll.GetAll()
                            join b in InfoClassBll.GetAll() on a.InfoClass_ID equals b.InfoClass_ID
                            join c in ICCBll.GetAll() on a.ICC_ID equals c.ICC_ID
                            select new InfoModel
                            {
                                Info_ID=a.Info_ID,
                                Info_Title =a.Info_Title,
                                //Info_Content=a.Info_Content,
                                //Info_Img=a.Info_Img,
                                Info_Time=a.Info_Time,
                                Info_Class=b.Info_Class,
                                ICC_Name=c.ICC_Name
                            };
            PagingHelper<InfoModel> StudentPaging = new PagingHelper<InfoModel>(5, infoModel);//初始化分页器,及每页显示数量
            StudentPaging.PageIndex = pageIndex;//指定当前页
            return View(StudentPaging);//返回分页器实例到视图
        }

        #region 添加新闻资讯
        public ActionResult Create(int ? id)
        {
            ViewBag.infoClass = new SelectList(InfoClassBll.GetAll(), "InfoClass_ID", "Info_Class");
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AfterCreate(Info info)
        {
            if (info != null)
            {
                info.Info_Time = DateTime.Now;
                var temp = InfoBll.Add(info);
                if (temp == true)
                    return Content("ok:成功");
                else
                    return Content("no: 失败");
            }
            ViewBag.videoClass = new SelectList(InfoClassBll.GetAll(), "InfoClass_ID", "Info_Class", info.InfoClass_ID);
            ViewBag.icc = new SelectList(ICCBll.GetAll(), "ICC_ID", "ICC_Name",info.ICC_ID);
            return View(info);
        }
        #endregion

        #region 新闻资讯详情
        public ActionResult Details(int id)
        {
            var infoModel = (from a in InfoBll.GetAll()
                             join b in InfoClassBll.GetAll() on a.InfoClass_ID equals b.InfoClass_ID
                             join c in ICCBll.GetAll() on a.ICC_ID equals c.ICC_ID
                             select new InfoModel
                             {
                                 Info_ID = a.Info_ID,
                                 Info_Title = a.Info_Title,
                                 Info_Content = a.Info_Content,
                                 Info_Img = a.Info_Img,
                                 Info_Time = a.Info_Time,
                                 Info_Class = b.Info_Class,
                                 ICC_Name = c.ICC_Name
                             }).Where(u => u.Info_ID == id).FirstOrDefault();
           
            return View(infoModel);
        }
        #endregion
        #region 修改资讯
        public ActionResult Edit(int id)
        {
            ViewBag.infoClass = new SelectList(InfoClassBll.GetAll(), "InfoClass_ID", "Info_Class");
            ViewBag.icc = new SelectList(ICCBll.GetAll(), "ICC_ID", "ICC_Name");
            Info info = InfoBll.GetById(id);
            InfoModel infoModel = new InfoModel
            {
                Info_ID = info.Info_ID,
                Info_Title=info.Info_Title.Trim(),
                Info_Img=info.Info_Img,
                InfoClass_ID=info.InfoClass_ID,
                ICC_ID=info.ICC_ID,
                Info_Content=info.Info_Content
               
            };
            return View(infoModel);
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult AfterEdit(Info info)
        {
            if (info != null)
            {

                info.Info_Time= DateTime.Now;
                //Video updatevideo = new Video
                //{
                //    Video_Img = video.Video_Img,
                //    Video_Time = DateTime.Now,
                //    Video_Title = video.Video_Title,
                //    Video_Url = video.Video_Url,
                //    VideoClass_ID = video.VideoClass_ID,
                //    Video_ID=video.Video_ID
                //};
                var temp = InfoBll.Edit(info);
                if (temp == true)
                    return Content("ok:成功");
                else
                    return Content("no: 失败");

            }
            ViewBag.infoClass = new SelectList(InfoClassBll.GetAll(), "InfoClass_ID", "Info_Class", info.InfoClass_ID);
            ViewBag.icc = new SelectList(ICCBll.GetAll(), "ICC_ID", "ICC_Name", info.ICC_ID);
            return View();
        }
        #endregion
        #region 删除资讯
        public ActionResult Delete(int id)
        {
            var temp = InfoBll.Remove(id);
            if (temp == true)
                return RedirectToAction("Index");
            else
                return View();


        }
        #endregion
        #endregion

        #region 下拉框数据联动
        ///// <summary>
        ///// 获取一级分类
        ///// </summary>
        //public JsonResult GetProvincelist()
        //{
        //    var list = InfoClassBll.GetAll();
        //    return Json(list, JsonRequestBehavior.AllowGet);
        //}

       
        /// 获取二级分类      
        public JsonResult GetCitylist(int pid)
        {
            var iCCs = ICCBll.GetAll().Where(m => m.InfoClass_ID == pid).ToList();

            List<SelectListItem> item = new List<SelectListItem>();

            foreach (var icc in iCCs)
            {
                item.Add(new SelectListItem { Text = icc.ICC_Name, Value = icc.ICC_ID.ToString() });
            }
            return Json(item, JsonRequestBehavior.AllowGet);
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
                if (fileExt == ".jpg" || fileExt == ".png")
                {
                    string dir = "/UploadInfoImg/" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/";
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
       
    }
}