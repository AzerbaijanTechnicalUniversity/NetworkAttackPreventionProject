using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetworkAttackPreventionProject.Controllers
{
    public class AddRulesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
