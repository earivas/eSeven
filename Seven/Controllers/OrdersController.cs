using Seven.Models;
using Seven.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Seven.Controllers
{
    public class OrdersController : Controller
    {
        // GET: Orders
        SevenContext db = new SevenContext();
        public ActionResult NewOrder()
        {
            var OrderView = new OrderView();
            //  var fecha


            OrderView.ModelPerson = new ModelPerson();
            OrderView.Pages = new List<PageOrder>();
            Session["orderView"] = OrderView;


            var list = db.ModelPersons.ToList();
            list.Add(new ModelPerson { ModelID = 0, FirstName = "[Select Model...]" });
            list = list.OrderBy(s => s.FullName).ToList();
            ViewBag.ModelID = new SelectList(list, "ModelID", "FullName");



            return View(OrderView);
        }
        //POST
        [HttpPost]
        public ActionResult NewOrder(OrderView orderView)
        {
            orderView = Session["orderView"] as OrderView;

            //Request camnpos formulario
            var oDate = DateTime.Parse(Request["Order.OrderDate"]);
            var modelID = int.Parse(Request["ModelID"]);
       


            if (modelID == 0)
            {
                var listM = db.ModelPersons.ToList();
                listM.Add(new ModelPerson { ModelID = 0, FirstName = "[Select Model...]" });
                listM = listM.OrderBy(s => s.FullName).ToList();
                ViewBag.ModelID = new SelectList(listM, "ModelID", "FullName");
                ViewBag.Error = "Debe seleccionar una Modelo";
                return View(orderView);

            }

            var modelPerson = db.ModelPersons.Find(modelID);

            if (modelPerson == null)
            {
                var listM = db.ModelPersons.ToList();
                listM.Add(new ModelPerson { ModelID = 0, FirstName = "[Select Model...]" });
                listM = listM.OrderBy(s => s.FullName).ToList();
                ViewBag.ModelID = new SelectList(listM, "ModelID", "FullName");
                ViewBag.Error = "Cliente no Existe";
                return View(orderView);
            }
            // var list = db.ModelPersons.ToList();
            // list.Add(new ModelPerson { ModelID = 0, FirstName = "[Select Model...]" });
            // list = list.OrderBy(s => s.FullName).ToList();
            // ViewBag.ModelID = new SelectList(list, "ModelID", "FullName");

            if (orderView.Pages.Count == 0)
            {
                var listM = db.ModelPersons.ToList();
                listM.Add(new ModelPerson { ModelID = 0, FirstName = "[Select Model...]" });
                listM = listM.OrderBy(s => s.FullName).ToList();
                ViewBag.ModelID = new SelectList(listM, "ModelID", "FullName");
                ViewBag.Error = "Debe ingresar detalle";
                return View(orderView);
            }

            int orderID = 0;
          

            using (var transaction = db.Database.BeginTransaction())
            {

                try
                {
                    var order = new Order
                  

                    {
                       
                        ModelID = modelID,
                        OrderDate = oDate,// DateTime.Now,
                        OrderStatus = OrderStatus.Created,
                       
                        
                    };

                    db.Orders.Add(order);
                    db.SaveChanges();

                    orderID = db.Orders.ToList().Select(o => o.OrderID).Max();

                    foreach (var item in orderView.Pages)
                    {
                        var orderDetail = new OrderDetail
                        {
                            
                            PageID = item.PageID,
                            TimeStart = item.TimeStart,//  DateTime.Parse(Request["TimeStart"]),// item.TimeStart,  //FORMATO DE TIEMPO FALLA
                            TimeEnd = item.TimeEnd, //DateTime.Parse(Request["TimeEnd"]),     //item.TimeEnd,   //   FORMATO DE TIEMPO FALLA
                            CreationDate = DateTime.Now,
                            PageName = item.PageName,
                            TipValue = item.TipValue,
                            QtyTokens = item.QtyTokens,
                            Value = item.Value,
                            OrderID = orderID

                        };

                        db.OrderDetails.Add(orderDetail);
                        db.SaveChanges();

                       
               
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {

                    transaction.Rollback();
                    ViewBag.Error = "ERROR:  " + ex.Message;

                    //verificar qu este codigo funcione
                    var listM = db.ModelPersons.ToList();
                    listM.Add(new ModelPerson { ModelID = 0, FirstName = "[Select Model...]" });
                    listM = listM.OrderBy(s => s.FullName).ToList();
                    ViewBag.ModelID = new SelectList(listM, "ModelID", "FullName");
                    return View(orderView);
                }

              
            }

            ViewBag.Message = string.Format("La orden: {0}, grabada correctamente", orderID);

             var list = db.ModelPersons.ToList();
             list.Add(new ModelPerson { ModelID = 0, FirstName = "[Select Model...]" });
             list = list.OrderBy(s => s.FullName).ToList();
             ViewBag.ModelID = new SelectList(list, "ModelID", "FullName");
            // return View(orderView);

            var OrderView = new OrderView();
            OrderView.ModelPerson = new ModelPerson();
            OrderView.Pages = new List<PageOrder>();
            Session["orderView"] = OrderView;
            return View(OrderView);


    }
        

        public ActionResult AddDetail() 
        {

            //ModelPersonOrder modelPersonOrder
            var list = db.Pages.ToList();
            list.Add(new Page { PageID = 0, PageName = "[Select Page...]" });
            list = list.OrderBy(s => s.PageName).ToList();
            ViewBag.PageID = new SelectList(list, "PageID", "PageName");

            return View();
        }

        [HttpPost]
        public ActionResult AddDetail(PageOrder pageOrder)
        {

         //   Session["_ModelID"] = int.Parse(Request["ModelID"]);
         //   Session["orderDate"] = DateTime.Parse(Request["Order_OrderDate"]);
         //   var modelIDCurrent = Session["_ModelID"];
         //   var dateOrderCurrent = Session["orderDate"];
            var orderView = Session["orderView"] as OrderView;
 
            var pageID =int.Parse( Request["PageID"]);

            if (pageID == 0)
            {
                var list = db.Pages.ToList();
                list.Add(new Page { PageID = 0, PageName = "[Select Page...]" });
                list = list.OrderBy(s => s.PageName).ToList();
                ViewBag.ModelID = new SelectList(list, "PageID", "PageName");
                ViewBag.Error = "Debe seleccionar una Page";
                return View(pageOrder);
            }


            var page = db.Pages.Find(pageID);

            if (page == null)
            {
                var list = db.Pages.ToList();
                list.Add(new Page { PageID = 0, PageName = "[Select Pagina...]" });
                list = list.OrderBy(s => s.PageName).ToList();
                ViewBag.PageID = new SelectList(list, "PageID", "PageName");
                ViewBag.Error = "Pagina no existe";

                return View(pageOrder);
            }


            // pageOrder = orderView.PageOrders.Find(p => p.PageID == pageID);
            pageOrder = orderView.Pages.Find(p => p.PageID == pageID);

            if (pageOrder == null)
            {

                pageOrder = new PageOrder

                {
                    PageName = page.PageName,
                    PageID = page.PageID,
                    QtyTokens = int.Parse(Request["QtyTokens"]),
                    TipValue = page.TipValue,
                };

                orderView.Pages.Add(pageOrder);
            }
            else
            {
                pageOrder.QtyTokens +=  int.Parse(Request["QtyTokens"]);
            }



              var listM = db.ModelPersons.ToList();
             // *  listM.Add(new ModelPerson { ModelID = 0, FirstName = "[Select Page...]" });
              listM = listM.OrderBy(s => s.FullName).ToList();
               ViewBag.ModelID = new SelectList(listM, "ModelID", "FullName");



            return View("NewOrder",orderView); 
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