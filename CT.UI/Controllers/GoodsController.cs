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
    public class GoodsController : Controller
    {
        GoodsBll GoodsBll = new GoodsBll();
        GoodsTypeBll GoodsTypeBll = new GoodsTypeBll();
        BorderBll BorderBll = new BorderBll();
        #region 商品前台展示
        public ActionResult Goods_Index()
        {
            ViewBag.goods = GoodsBll.GetAll().OrderBy(u => u.Goods_ID).Take(4);
            ViewBag.type = GoodsTypeBll.GetAll().Where(u=>u.Type_Name.Contains("手机")).FirstOrDefault();
            ViewBag.type1= GoodsTypeBll.GetAll().Where(u => u.Type_Name.Contains("平板")).FirstOrDefault();
            ViewBag.type2=GoodsTypeBll.GetAll().Where(u => u.Type_Name.Contains("笔记本")).FirstOrDefault();
            int id = ViewBag.type.Type_ID;
            int id1 = ViewBag.type1.Type_ID;
            int id2 = ViewBag.type2.Type_ID;
            
            ViewBag.phone = GoodsBll.GetAll().OrderByDescending(u=>u.Goods_ID).Where(u => u.Type_ID == id).Take(5);
            ViewBag.phone1 = GoodsBll.GetAll().OrderByDescending(u => u.Goods_ID).Where(u => u.Type_ID == id).Take(3);
            ViewBag.tablet = GoodsBll.GetAll().OrderByDescending(u => u.Goods_ID).Where(u => u.Type_ID == id1).Take(3);
            ViewBag.laptop = GoodsBll.GetAll().OrderByDescending(u => u.Goods_ID).Where(u => u.Type_ID == id2).Take(3);
          
            return View();
        }
        public ActionResult Goods_Details(int goodsid)
        {
            ViewBag.goodsphone = GoodsBll.GetAll().OrderByDescending(u => u.Goods_ID).Where(u => u.Type_ID == 1).Take(4);
            ViewBag.goodsother = GoodsBll.GetAll().OrderByDescending(u => u.Goods_ID).Where(u => u.Type_ID == 2).Take(3);
            var goodsModel = (from a in GoodsBll.GetAll()
                              join b in GoodsTypeBll.GetAll() on a.Type_ID equals b.Type_ID
                              join c in BorderBll.GetAll() on a.Border_ID equals c.Border_ID
                              select new GoodsModel
                              {
                                  Goods_ID=a.Goods_ID,
                                  Goods_Content=a.Goods_Content,
                                  Goods_Img=a.Goods_Img,
                                  Goods_Price=a.Goods_Price,
                                  Goods_Name=a.Goods_Name,
                                  Type_Name=b.Type_Name,
                                  Border_Name=c.Border_Name
                                  

                              }).Where(u => u.Goods_ID == goodsid).FirstOrDefault();
            return View(goodsModel);
        }
        public ActionResult Goods_Content(int id,int pageIndex = 1)
        {
            var goodsModel= from a in GoodsBll.GetAll()
                            join b in GoodsTypeBll.GetAll() on a.Type_ID equals b.Type_ID
                            join c in BorderBll.GetAll() on a.Border_ID equals c.Border_ID
                            select new GoodsModel
                            {
                                Goods_ID=a.Goods_ID,
                                Goods_Img=a.Goods_Img,
                                Goods_Name=a.Goods_Name,
                                Goods_Content=a.Goods_Content,
                                Goods_Price=a.Goods_Price,
                                Type_ID=a.Type_ID,
                                Type_Name=b.Type_Name,
                                Border_ID=a.Border_ID,
                                Border_Name=c.Border_Name

                            };
            PagingHelper<GoodsModel> StudentPaging = new PagingHelper<GoodsModel>(12, goodsModel);//初始化分页器
            StudentPaging.PageIndex = pageIndex;//指定当前页
            return View(StudentPaging);//返回分页器实例到视图
        }
        #endregion
        #region 货品信息后台管理
        // GET: Goods
        public ActionResult Index(int pageIndex = 1)
        {
            var goodsModel = from a in GoodsBll.GetAll()
                             join b in GoodsTypeBll.GetAll() on a.Type_ID equals b.Type_ID
                             join c in BorderBll.GetAll() on a.Border_ID equals c.Border_ID
                             select new GoodsModel
                             {
                                 Goods_ID = a.Goods_ID,
                                 Goods_Name = a.Goods_Name,
                                 Goods_Img = a.Goods_Img,
                                 Goods_Price = a.Goods_Price,
                                 Goods_Content = a.Goods_Content,
                                 Type_Name=b.Type_Name,
                                 Border_Name=c.Border_Name

                                
                            };
            PagingHelper<GoodsModel> StudentPaging = new PagingHelper<GoodsModel>(5, goodsModel);//初始化分页器,及每页显示数量
            StudentPaging.PageIndex = pageIndex;//指定当前页
            return View(StudentPaging);//返回分页器实例到视图
        }
        #region 添加新闻资讯
        public ActionResult Create(int? id)
        {
            ViewBag.GoodsClass = new SelectList(GoodsTypeBll.GetAll(), "Type_ID", "Type_Name");
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AfterCreate(Goods goods)
        {
            if (goods != null)
            {
               
                var temp = GoodsBll.Add(goods);
                if (temp == true)
                    return Content("ok:成功");
                else
                    return Content("no: 失败");
            }
            ViewBag.goodstype = new SelectList(GoodsTypeBll.GetAll(), "Type_ID", "Type_Name", goods.Type_ID);
            ViewBag.goodsborder = new SelectList(BorderBll.GetAll(), "Border_ID", "Border_Name", goods.Border_ID);
            return View(goods);
        }
        #endregion
        #region 商品详情
        public ActionResult Details(int id)
        {
            var goodsModel = (from a in GoodsBll.GetAll()
                             join b in GoodsTypeBll.GetAll() on a.Type_ID equals b.Type_ID
                             join c in BorderBll.GetAll() on a.Border_ID equals c.Border_ID
                             select new GoodsModel
                             {
                                 Goods_ID = a.Goods_ID,
                                 Goods_Name = a.Goods_Name,
                                 Goods_Img = a.Goods_Img,
                                 Goods_Price = a.Goods_Price,
                                 Goods_Content = a.Goods_Content,
                                 Type_Name = b.Type_Name,
                                 Border_Name = c.Border_Name


                             }).Where(u => u.Goods_ID == id).FirstOrDefault();

            return View(goodsModel);
        }
        #endregion
        #region 修改资讯
        public ActionResult Edit(int id)
        {
            ViewBag.goodtype = new SelectList(GoodsTypeBll.GetAll(), "Type_ID", "Type_Name");
            ViewBag.goodborder = new SelectList(BorderBll.GetAll(), "Border_ID", "Border_Name");
            Goods goods = GoodsBll.GetById(id);
            GoodsModel goodsModel = new GoodsModel
            {
                Goods_ID=goods.Goods_ID,
                Goods_Content=goods.Goods_Content,
                Goods_Img=goods.Goods_Img,
                Goods_Price=goods.Goods_Price,
                Goods_Name=goods.Goods_Name,
                Type_ID=goods.Type_ID,
                Border_ID=goods.Border_ID,
                
            };
            return View(goodsModel);
        }
        
        public ActionResult AfterEdit(Goods goods)
        {
            if (goods != null)
            {
                
                var temp = GoodsBll.Edit(goods);
                if (temp == true)
                    return Content("ok:成功");
                else
                    return Content("no: 失败");

            }
            ViewBag.goodtype = new SelectList(GoodsTypeBll.GetAll(), "Type_ID", "Type_Name", goods.Type_ID);
            ViewBag.goodborder = new SelectList(BorderBll.GetAll(), "Border_ID", "Border_Name", goods.Border_ID);
            return View();
        }
        #endregion
        #region 删除商品
        public ActionResult Delete(int id)
        {
            var temp = GoodsBll.Remove(id);
            if (temp == true)
                return RedirectToAction("Index");
            else
                return View();


        }
        #endregion
        #region 获取二级分类
        public JsonResult GetCitylist(int pid)
        {
            var  borders = BorderBll.GetAll().Where(m => m.Type_ID == pid).ToList();

            List<SelectListItem> item = new List<SelectListItem>();

            foreach (var bor in borders)
            {
                item.Add(new SelectListItem { Text = bor.Border_Name, Value = bor.Border_ID.ToString() });
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
                    string dir = "/UploadGoodsImg/" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/";
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

    }
}