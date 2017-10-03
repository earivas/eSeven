
using Seven.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//namespace Seven.Controllers
////{

////    public class OrderMasterController : Controller
////    {
////        SevenContext db = new SevenContext();

////        // GET: OrderMaster
////        public ActionResult Index()
////        {
////            return View();
////        }


////        public JsonResult getProductCategories()
////        {
////            List<Category> categories = new List<Category>();
////            using (SevenContext db = new SevenContext())
////            {
////                return new JsonResult { Data = categories, JsonRequestBehavior = JsonRequestBehavior.AlloGet };
////            }
////        }

////        public JsonResult getProducts(int categoryID)
////        {
////            List<Product> products = new List<Product>();
////            using (SevenContext db = new SevenContext())
////            {
////                products = db.Products.where(a => a.CategoryID.Equals(categoryID)).OrderBy(a => a.ProductName).ToList();
////            }
////            return new JsonResult { Data = categories, JsonRequestBehavior = JsonRequestBehavior.AlloGet };
////        }

////        public JsonResult save(OrderMaster order)
////        {
////            bool status = false;
////            DateTime dateOrg;
////            var IsValidDate = DateTime.TryParseExact(order.OrderDateString, "mm.dd-yyyy",
////                  null, System.Globalization.DateTimeStyles.None, out dateOrg);

////            if (IsValidDate)
////            {
////                order.OrderDateString = dateOrg;
////            }

////            var isValidModel = TryUpdateModel(order);
////            if (isValidModel)
////            {
////                using (SevenContext db = new SevenContext())
////                {
////                    db.OrderMaster.Add(order);
////                    db.SaveChanges();
////                    status = true;
////                }
////                return new JsonResult { Data = new { status = status } };
////            }

////        }
////    }
////}