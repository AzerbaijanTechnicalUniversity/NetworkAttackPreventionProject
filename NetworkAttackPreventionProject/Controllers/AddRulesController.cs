using Microsoft.AspNetCore.Mvc;
using NetworkAttackPreventionProject.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            ViewBag.result = ExecuteCmd.ExecuteCommandSync(cmd);
            return View();


            //Process proc = new Process();
            //proc.StartInfo.FileName = "cmd.exe";
            //proc.StartInfo.UseShellExecute = true;
            //proc.StartInfo.Verb = "runas";
            //proc.Start();
            //return View();


            //Process firewall = new Process();
            //firewall.StartInfo.FileName = "cmd.exe";
            //firewall.StartInfo.WorkingDirectory = @"\windows\system32\";
            //firewall.StartInfo.Verb = "runas";
            //firewall.StartInfo.Arguments = "ping " +command;
            //firewall.Start();
            //return View();
        }
    }
}
