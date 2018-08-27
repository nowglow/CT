using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CT.BLL;
using CT.Common;
using CT.Model;
using CT.UI.Models;

namespace CT.UI.Controllers
{
    public class ICCController : Controller
    {
        InfoClassBll InfoClassBll = new InfoClassBll();
        ICCBll ICCBll = new ICCBll();


        #region 二级分类后台管理


        #region 添加二级分类

        public ActionResult Create()
        {
            ViewBag.infoClass = new SelectList(InfoClassBll.GetAll(), "InfoClass_ID", "Info_Class");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ICC iCC)
        {
            ICC @class = new ICC
            {
                ICC_Name = iCC.ICC_Name,
                InfoClass_ID=iCC.InfoClass_ID
            };
            var temp = ICCBll.Add(@class);
            if (temp == true)
            {
                return RedirectToAction("Index","InfoClass");
            }
            ViewBag.infoClass = new SelectList(InfoClassBll.GetAll(), "InfoClass_ID", "Info_Class",iCC.ICC_ID);
            return View(iCC);
        }
        #endregion

        #region 修改二级分类
        public ActionResult Edit(int id)
        {
            ICC iCC = ICCBll.GetById(id);
            ViewBag.infoClass = new SelectList(InfoClassBll.GetAll(), "InfoClass_ID", "Info_Class",iCC.InfoClass_ID);
            return View(iCC);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ICC iCC)
        {
            ICCBll.Edit(iCC);
            return RedirectToAction("Index", "InfoClass");
        }
        #endregion

        #region 删除一级分类
        public ActionResult Delete(int id)
        {
            ICCBll.Remove(id);
            return RedirectToAction("Index", "InfoClass");
        }
        #endregion 
        #endregion 
    }
}