using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
