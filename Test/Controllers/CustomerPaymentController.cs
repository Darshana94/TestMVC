using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Test.Models;

namespace ERP.Controllers
{
    public class CustomerPaymentController : Controller
    {
        // GET: CustomerPayment
        
        public ActionResult CustomerPayment()
        {
            DemoEntities en = new DemoEntities();
            return View(en.Bills);
        }

        [HttpPost]
        public ActionResult CustomerPayment(String SearchCus)
        {
            DemoEntities en = new DemoEntities();
            List<Bill> bill;
            if (string.IsNullOrEmpty(SearchCus))
            {
                bill = null;
            }
            else
            {
                bill = en.Bills
                    .Where(s => s.Customer.Cus_Name.StartsWith(SearchCus)).ToList();
            }
            return View(bill);
            
        }

        public JsonResult GetCustomers(string term)
        {
            DemoEntities en = new DemoEntities();
            List<string> Bill = en.Bills.Where(s => s.Customer.Cus_Name.StartsWith(term))
                                        .Select(x => x.Customer.Cus_Name)
                                        .ToList();
            return Json(Bill, JsonRequestBehavior.AllowGet);
        }


        
    }
}