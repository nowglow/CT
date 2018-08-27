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
    public class InfoClassController : Controller
    {
        InfoClassBll InfoClassBll = new InfoClassBll();
        ICCBll ICCBll = new ICCBll();
        #region 前台资讯分类菜单
        //导航一二级分类
        public ActionResult InfoMenu()
        {
            var infoClassModel = new InfoClassModel
            {
                InfoClasses = InfoClassBll.GetAll().AsEnumerable().ToList(),
                ICC = ICCBll.GetAll().AsEnumerable().ToList()
            };

            return View(infoClassModel);
        }
        
        #endregion
        #region 资讯信息后台管理

        //后台分类主页
        public ActionResult Index(int ? id)
        {
            var infoClass = InfoClassBll.GetAll();
            //全部的一级分类和二级分类
            var viewModel = new InfoClassModel
            {
                InfoClasses = infoClass.AsEnumerable().ToList(),

            };
            if (id != null)
            {
                viewModel.ICC = (from a in ICCBll.GetAll()
                                 where a.InfoClass_ID == id
                                 select a).ToList();
                //viewModel.ICC = (ICCBll.GetAll().Single(u => u.ICC_ID == id));
            }
            return View(viewModel);
        }

        #region 添加一级分类

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InfoClass infoClass)
        {
            InfoClass @class = new InfoClass
            {
                Info_Class = infoClass.Info_Class
            };
            var temp = InfoClassBll.Add(@class);
            if (temp == true)
            {
                return RedirectToAction("Index");
            }
            return View(infoClass);
        }
        #endregion

        #region 修改一级分类
        public ActionResult Edit(int id)
        {
            InfoClass infoClass = InfoClassBll.GetById(id);
            return View(infoClass);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(InfoClass  infoClass)
        {
            InfoClassBll.Edit(infoClass);
            return RedirectToAction("Index");
        }
        #endregion

        #region 删除一级分类
        public ActionResult Delete(int id)
        {
            InfoClassBll.Remove(id);
            return RedirectToAction("Index");
        }
        #endregion 
        #endregion
    }
}