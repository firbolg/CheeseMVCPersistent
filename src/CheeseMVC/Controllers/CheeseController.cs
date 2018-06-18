using Microsoft.AspNetCore.Mvc;
using CheeseMVC.Models;
using System.Collections.Generic;
using CheeseMVC.ViewModels;
using CheeseMVC.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {
        private CheeseDbContext context;

        public CheeseController(CheeseDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            //List<Cheese> cheeses = context.Cheez.ToList();
            //IList<Cheese> cheeses = context.Cheez.Include(c => c.Category).ToList();
            IList<Cheese> cheeses = context.Cheez.Include(c => c.Category).ToList();

            return View(cheeses);
        }

        public IActionResult Add()
        {
            AddCheeseViewModel addCheeseViewModel = new AddCheeseViewModel(context.Categorees.ToList());
            return View(addCheeseViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddCheeseViewModel addCheeseViewModel)
        {
            if (ModelState.IsValid)
            {
                // Add the new cheese to my existing cheeses
                CheeseCategory newCheeseCategory = context.Categorees.Single(c => c.ID == addCheeseViewModel.CategoryID);
                Cheese newCheese = new Cheese
                {
                    Name = addCheeseViewModel.Name,
                    Description = addCheeseViewModel.Description,
                    Category = newCheeseCategory,
                    CategoryID = addCheeseViewModel.CategoryID
                };

                context.Cheez.Add(newCheese);
                context.SaveChanges();

                return Redirect("/Cheese");
            }

            return View(addCheeseViewModel);
        }

        public IActionResult Remove()
        {
            ViewBag.title = "Remove Cheeses";
            ViewBag.cheeses = context.Cheez.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Remove(int[] cheeseIds)
        {
            foreach (int cheeseId in cheeseIds)
            {
                Cheese theCheese = context.Cheez.Single(c => c.ID == cheeseId);
                context.Cheez.Remove(theCheese);
            }

            context.SaveChanges();

            return Redirect("/");
        }
        //prep vid option
        public IActionResult Category(int id)
        {
            if (id == 0)
            {
                return Redirect("/Category");
            }

            CheeseCategory theCategory = context.Categorees
                .Include(cg => cg.Cheez)
                .Single(cg => cg.ID == id);
            ViewBag.title = "Cheeses in category: " + theCategory.Name;
            return View("Index", theCategory.Cheez);
        }
    }
}
