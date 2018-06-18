using CheeseMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.ViewModels
{
    public class AddCheeseViewModel
    {
        [Required]
        [Display(Name = "Cheese Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please describe your cheese!")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryID { get; set; }

        public List<SelectListItem> Categorees { get; set; }

        public AddCheeseViewModel(IEnumerable<CheeseCategory> categories)
        {
            Categorees = new List<SelectListItem>();

            foreach (CheeseCategory category in categories)
            {
                Categorees.Add(new SelectListItem
                {
                    Value = category.ID.ToString(),
                    Text = category.Name.ToString()
                });
            }
        }

        public AddCheeseViewModel()
        {
            Categorees = new List<SelectListItem>();
        }


        

        
    }
}
