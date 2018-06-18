using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheeseMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace CheeseMVC.ViewModels
{
    public class AddMenuItemViewModel
    {
        public int CheeseID { get; set; }
        public int MenuID { get; set; }
        public Menu Menu { get; set; }
        public List<SelectListItem> Cheez { get; set; }
        public AddMenuItemViewModel() { }
        public AddMenuItemViewModel(Menu menu, IEnumerable<Cheese> cheeses)
        {
            Cheez = new List<SelectListItem>();

            foreach (var cheese in cheeses)
            {
                Cheez.Add(new SelectListItem
                { Value = cheese.ID.ToString(), Text = cheese.Name });
            }
            Menu = menu;
        }
    }
}
