using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MVCMovie.Models;
namespace MVCMovie.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Index()
        {
            List<Movie> movies = new List<Movie>();
            if (Session["Movies"] ==null)
            {
                
                movies.Add(
                    new Movie
                    {
                        ID = 1,
                        Genre = "Terror",
                        Title = "Viernes 13",
                        Price = 20,
                        ReleaseDate = DateTime.Today
                    }
                    );
                movies.Add(
                    new Movie
                    {
                        ID = 2,
                        Genre = "Comedia Romática",
                        Title = "Programador por una noche",
                        Price = 50,
                        ReleaseDate = DateTime.Today
                    }
                    );

                Session["Movies"] = movies;
            }
            else
            {
                movies =(List<Movie>)Session["Movies"];
            }
            
            

            //Go to Datasource
           
            return View(movies);
        }


        // GET: Movie/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        
        // GET: Movie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movie/Create
        [HttpPost]
        public ActionResult Create(Movie model)
        {
            try
            {

                ((List<Movie>)Session["Movies"]).Add(model);

                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Movie/Edit/5
        public ActionResult Edit(int id)
        {

            var model = ((List<Movie>)Session["Movies"]).
                Where(x => x.ID == id).FirstOrDefault();

            return View(model);
        }

        // POST: Movie/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Movie model)
        {
            try
            {
                //Objeto a modificar
               

                foreach (var item in ((List<Movie>)Session["Movies"]))
                {
                    if (item.ID==model.ID)
                    {
                        item.Title = model.Title;
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

        // GET: Movie/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Movie/Delete/5
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
