using Seven.ExtendedModel;
using Seven.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace SevenOrder.Controllers
{
    public class TransactionController : Controller
    {
        SevenContext db = new SevenContext();
        private static ICollection<Order> orders = new HashSet<Order>();
        //  string BASE_URL = "http://localhost:2768/ServicioProduccion.svc/";
        // GET: Transaction
        public ActionResult Index()
        {
            var modelo = orders.ToArray();
            return View(modelo);
        }

        public ActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Create(Order modelo, string operation = null )
        {
            if (modelo == null)
            {
                modelo = new Order();
            }

            if (operation == null)
            {
                if (CreateOrder(modelo))
                {
                    return RedirectToAction("Index");
                }
            }
            else if (operation == "Add-Detail")
            {
                modelo.OrderDetails.Add(new OrderDetail());
            }

            else if (operation.StartsWith("Delete-Detail-"))
            {
                DeleteDetailByIndex(modelo, operation);
            }

       //     var webCliente = new WebClient();
       //     var json = webCliente.DownloadString(BASE_URL + "seleccionarproductos");
           //string s = json.Replace("Ã³", "ó").Replace("Ã©", "é").Replace("Ã±", "ñ").Replace("Ãº", "ú").Replace("Ã­", "í").Replace("Ã¡", "á").Replace("Í", "Í");
           // json = s;
           // var js = new JavaScriptSerializer();
           // js.Deserialize<List<PagesWS>>(json);
            var listPages = db.Pages.ToList();
           // var listPages = js.Deserialize<List<PagesWS>>(json).ToList();
            ViewBag.Pages = listPages;
            return View();
        }

        private bool CreateOrder(Order order)
        {
            if (ModelState.IsValid)
            {
                if (order.OrderDetails !=null && order.OrderDetails.Count>0)
                {
                    return true;
                }
                else
                {
                    ModelState.AddModelError("", "No se puede guardar la factura sin detalle");

                }
            }
            return false;
        }

        private static void DeleteDetailByIndex(Order order, string operation)
        {
            string indexStr = operation.Replace("Delete-Detail-", "");
            int index = 0;
            if (int.TryParse(indexStr, out index) && index >= 0 && index < order.OrderDetails.Count)
            {
                var item = order.OrderDetails.ToArray()[index];
                order.OrderDetails.Remove(item); 
            }
            //throw new NotImplementedException();
        }
  
    }
}