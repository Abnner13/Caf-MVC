using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MvcMovie.Models
{
    public class CoffeHowToTakeViewModel
    {
        public List<Coffe> Coffes { get; set; }
        public SelectList HowToTakes { get; set; }
        public string CoffeHTT { get; set; }
        public string SearchString { get; set; }

    }
}
