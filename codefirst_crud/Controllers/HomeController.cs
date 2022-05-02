using codefirst_crud.datafolder;
using codefirst_crud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace codefirst_crud.Controllers
{
    public class HomeController : Controller
    {

        private readonly dataClass _db;
        public HomeController(dataClass db)
        {
            _db = db;
        }
        empClass mobj = new empClass();


        public IActionResult Index()
        {


            return View();
        }

        public IActionResult show()
        {
           var res= _db.emptable.ToList();
            List<empClass> lobj = new List<empClass>();
            foreach(var i in res)
            {
                lobj.Add(new empClass { 
                id=i.id,
                    name = i.name,
                    age = i.age,
                    sal = i.sal


                });
            }
            return View(lobj);
        }
        [HttpGet]
        public IActionResult add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult add(empClass mobj1)
        {
            mobj.id = mobj1.id;
            mobj.name = mobj1.name;
            mobj.age = mobj1.age;

            mobj.sal = mobj1.sal;


            if(mobj1.id==0)
            {
                _db.emptable.Add(mobj1);
                _db.SaveChanges();
            }
            else
            {
                _db.Entry(mobj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _db.SaveChanges();
            }
            return RedirectToAction("show");
        }

        public IActionResult edit(int id)
        {
            var ed = _db.emptable.Where(m => m.id == id).First();
            mobj.id = ed.id;
            mobj.name = ed.name;
            mobj.sal = ed.sal;
            mobj.age = ed.age;
            return View("add",mobj);
        }

        public IActionResult delete(int id)
        {
            var del = _db.emptable.Where(m => m.id == id).First();
            _db.emptable.Remove(del);
            _db.SaveChanges();
            return RedirectToAction("show");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
