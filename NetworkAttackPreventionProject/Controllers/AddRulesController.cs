using Microsoft.AspNetCore.Mvc;
using NetworkAttackPreventionProject.Models;
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
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Index(string command)
        {
            string cmd = "ping " + command;
            //string cmd = "ipconfig";
            ViewBag.result = ExecuteCmd.ExecuteCommandSync(cmd);
            return View();
        }
    }
}
