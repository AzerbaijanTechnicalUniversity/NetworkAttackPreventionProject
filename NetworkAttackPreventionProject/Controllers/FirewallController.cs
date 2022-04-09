using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using NetworkAttackPreventionProject.Models;

namespace NetworkAttackPreventionProject.Controllers
{
    public class FirewallController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RunCMD(string argument)
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.FileName = @"C:WindowsSystem32cmd.exe";
            startInfo.Arguments = argument;
            process.StartInfo = startInfo;
            process.Start();
            return View();
        }

        public IActionResult Connect()
        {
            RunCMD(@"/C netsh advfirewall firewall set rule name=""RULENAME"" new enable=yes");
            return View();
        }

        public IActionResult Disconnect()
        {
            RunCMD(@"/C netsh advfirewall firewall set rule name=""RULENAME"" new enable=no");
            return View();
        }
        [HttpPost]
        public IActionResult ActiveFirewall()
        {
            string cmd = "netsh Advfirewall set allprofiles state on";
            ViewBag.result = ExecuteCmd.ExecuteCommandSync(cmd);
            return View();
        }  
        [HttpPost]
        public IActionResult DeActiveFirewall()
        {
            string cmd = "netsh Advfirewall set allprofiles state off";
            ViewBag.result = ExecuteCmd.ExecuteCommandSync(cmd);
            return View();
        }
    }
}
