using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationFPIS.Models;

namespace WebApplicationFPIS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetEmployees()
        {
            using (BazaParkGateEntities db = new BazaParkGateEntities())
            {

               

                var kvarovi = db.Kvar.OrderBy(a => a.DatumKvara).ToList();
                foreach (var item in kvarovi)
                {

                    string formatted = item.DatumKvara.ToString("yyyy-MM-dd");
                    item.Datum=formatted;
                   
                }
                return Json(new { data = kvarovi }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult Save(int id)
        {
            using (BazaParkGateEntities dc = new BazaParkGateEntities())
            {
                var v = dc.Kvar.Where(a => a.KvarID == id).FirstOrDefault();
                return View(v);
            }
        }

        [HttpPost]
        public ActionResult Save(Kvar emp)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                using (BazaParkGateEntities dc = new BazaParkGateEntities())
                {
                    if (emp.KvarID > 0)
                    {
                        //Edit 
                        var v = dc.Kvar.Where(a => a.KvarID == emp.KvarID).FirstOrDefault();
                        if (v != null)
                        {
                           v.DatumKvara = emp.DatumKvara;
                            v.OpisKvara = emp.OpisKvara;
                            v.IDZaposlenog = emp.IDZaposlenog;
                            v.GostID = emp.GostID;
                            v.BrojSobe = emp.BrojSobe;
                            
                        }
                    }
                    else
                    {
                        //Save
                        dc.Kvar.Add(emp);
                    }
                    dc.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (BazaParkGateEntities dc = new BazaParkGateEntities())
            {
                var v = dc.Kvar.Where(a => a.KvarID == id).FirstOrDefault();
                if (v != null)
                {
                    return View(v);
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteEmployee(int id)
        {
            bool status = false;
            using (BazaParkGateEntities dc = new BazaParkGateEntities())
            {
                var v = dc.Kvar.Where(a => a.KvarID == id).FirstOrDefault();
                if (v != null)
                {
                    dc.Kvar.Remove(v);
                    dc.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }
    }
}