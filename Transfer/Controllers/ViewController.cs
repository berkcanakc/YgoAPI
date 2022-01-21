using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Transfer.Controllers
{
    public class ViewController : Controller
    {
        public IActionResult CardView()
        {
            return View();
        }
    }
}
