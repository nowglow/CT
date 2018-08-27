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
    public class BorderController : Controller
    {
        GoodsTypeBll GoodsTypeBll = new GoodsTypeBll();
        BorderBll BorderBll = new BorderBll();


        #region 二级分类后台管理


        #region 添加二级分类

        public ActionResult Create()
        {
            ViewBag.goodsType = new SelectList(GoodsTypeBll.GetAll(), "Type_ID", "Type_Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Border border)
        {
            Border @class = new Border
            {
                Border_Name = border.Border_Name,
                Type_ID = border.Type_ID
            };
            var temp = BorderBll.Add(@class);
            if (temp == true)
            {
                return RedirectToAction("Index", "GoodsClass");
            }
            ViewBag.goodsType = new SelectList(GoodsTypeBll.GetAll(), "Type_ID", "Type_Name", border.Border_ID);
            return View(border);
        }
        #endregion

        #region 修改二级分类
        public ActionResult Edit(int id)
        {
            Border border = BorderBll.GetById(id);
            ViewBag.goodsType = new SelectList(GoodsTypeBll.GetAll(), "Type_ID", "Type_Name", border.Type_ID);
            return View(border);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Border border)
        {
            BorderBll.Edit(border);
            return RedirectToAction("Index", "GoodsClass");
        }
        #endregion

        #region 删除二级级分类
        public ActionResult Delete(int id)
        {
            BorderBll.Remove(id);
            return RedirectToAction("Index", "GoodsClass");
        }
        #endregion 
        #endregion 
    }
}