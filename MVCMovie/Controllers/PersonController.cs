using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MVCMovie.Models;
namespace MVCMovie.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person

        #region Views

        public ActionResult Index()
        {
            List<Person> persons = new List<Person>();
            if (Session["Persons"] == null)
            {

                persons.Add(
                    new Person
                    {
                        ID = 1,
                        FirstName = "Juan",
                        LastName = "Vilchez",
                        BirthDay = DateTime.Today,
                        IsTecsup = true
                    }
                    );
                persons.Add(
                    new Person
                    {
                        ID = 2,
                        FirstName = "Salomé",
                        LastName = "Herdia",
                        BirthDay = DateTime.Today,
                        IsTecsup = false
                    }
                    );

                Session["Persons"] = persons;
            }
            else
            {
                persons = (List<Person>)Session["Persons"];
            }
            //Go to Datasource

            return View(persons);
        }


        // GET: Person/Create
        public ActionResult Create()
        {
            return View();
        }



        // POST: Person/Create
        [HttpPost]
        public ActionResult Create(Person model)
        {
            try
            {

                ((List<Person>)Session["Persons"]).Add(model);

                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Movie/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult List()
        {

            ViewBag.Title = "List of People";
            ViewBag.Message = "Please, don't slepp!";
            return View();
        }

        public ActionResult Insert()
        {
            return View();
        }

        public ActionResult Update()
        {
            return View();
        }

        #endregion

        // GET: Person/Edit/5
        public ActionResult Edit(int id)
        {

            var model = ((List<Person>)Session["Persons"]).
                Where(x => x.ID == id).FirstOrDefault();

            return View(model);
        }

        // POST: person/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Person model)
        {
            try
            {
                //Objeto a modificar


                foreach (var item in ((List<Person>)Session["Persons"]))
                {
                    if (item.ID == model.ID)
                    {
                        item.FirstName = model.FirstName;
                        break;
                    }
                }


                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

            // GET: Person/Delete/5
            public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Person/Delete/5
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



        public string GetFullName(string firstname, string lastname)
        {
            return string.Concat(firstname, " ", lastname);
        }




    }
}