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
    public class GoodsClassController : Controller
    {
        GoodsTypeBll GoodsTypeBll = new GoodsTypeBll();
        BorderBll BorderBll = new BorderBll();
        //#region 前台资讯分类菜单
        //public PartialViewResult InfoMenu()
        //{
        //    ViewBag.InfoClassModel = InfoClassBll.GetAll();
        //    return PartialView();
        //}
        //#endregion
        #region 资讯信息后台管理

        //后台分类主页
        public ActionResult Index(int? id)
        {
            var goodstype = GoodsTypeBll.GetAll();
            //全部的一级分类和二级分类
            var viewModel = new GoodsClassModel
            {
                GoodsTypes = goodstype.AsEnumerable().ToList(),

            };
            if (id != null)
            {
                viewModel.Border = (from a in BorderBll.GetAll()
                                 where a.Type_ID == id
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
        public ActionResult Create(GoodsType goodstype)
        {
            GoodsType @class = new GoodsType
            {
                Type_Name = goodstype.Type_Name
            };
            var temp = GoodsTypeBll.Add(@class);
            if (temp == true)
            {
                return RedirectToAction("Index");
            }
            return View(goodstype);
        }
        #endregion

        #region 修改一级分类
        public ActionResult Edit(int id)
        {
            GoodsType goodsType = GoodsTypeBll.GetById(id);
            return View(goodsType);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GoodsType goodsType)
        {
            GoodsTypeBll.Edit(goodsType);
            return RedirectToAction("Index");
        }
        #endregion

        #region 删除一级分类
        public ActionResult Delete(int id)
        {
            GoodsTypeBll.Remove(id);
            return RedirectToAction("Index");
        }
        #endregion 
        #endregion
    }
}