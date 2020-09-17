using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPModule3.Database;
using TPPizza.Models;

namespace TPPizza.Controllers
{
    public class PizzaController : Controller
    {
        // GET: Pizza
        public ActionResult Index()
        {
            if (FakeDb.Instance.ListePizzas.Count == 0)
            {
                return RedirectToAction("Create");
            }
            return View(FakeDb.Instance.ListePizzas);
        }

        // GET: Pizza/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Pizza/Create
        public ActionResult Create()
        {
            var fdb = FakeDb.Instance;
            VMPizz vm = new VMPizz();
            vm.Pates = fdb.ListePatesDispo;
            vm.Ingredients = fdb.ListeIngredientsDispo;
            return View(vm);
        }

        // POST: Pizza/Create
        [HttpPost]
        public ActionResult Create(VMPizz vm)
        {
            try
            {
                var fdb = FakeDb.Instance;
                vm.Pizza.Pate = fdb.ListePatesDispo.FirstOrDefault(x => x.Id == vm.IdPate);
                foreach (int ingredient in vm.IdsIngedients)
                {
                    vm.Pizza.Ingredients.Add(fdb.ListeIngredientsDispo.FirstOrDefault(x => x.Id == ingredient));
                }
                fdb.ListePizzas.Add(vm.Pizza);
                

                return RedirectToAction("Index");
            }
            catch(Exception)
            {
                var fdb = FakeDb.Instance;
                vm.Pates = fdb.ListePatesDispo;
                vm.Ingredients = fdb.ListeIngredientsDispo;
                return View(vm);
            }
        }

        // GET: Pizza/Edit/5
        public ActionResult Edit(int id)
        {
            var fdb = FakeDb.Instance;
            var item = fdb.ListePizzas
            return View();
        }

        // POST: Pizza/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pizza/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pizza/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
