using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.ViewComponents
{
    public class CurrentDateViewComponent : ViewComponent
    {
        public CurrentDateViewComponent()
        {

        }
        public IViewComponentResult Invoke(DateTime curentDate)
        {
            var outp = curentDate.ToUniversalTime();
            return View(outp);
        }
    }
}
