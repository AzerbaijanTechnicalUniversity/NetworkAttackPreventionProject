using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetworkAttackPreventionProject.Controllers
{
    public class SendPingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddRules(string rule,string inout, string allow, string protocol)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/c netsh advfirewall firewall add rule name = " + @rule  + " " + "dir =" +@inout+ " "+ "action = "+@allow+ " " +" protocol =" +@protocol+ " "+ " localip = any remoteip = any";
            startInfo.Verb = "runas";
            process.StartInfo = startInfo;
            process.Start();
            return RedirectToAction(nameof(Index));
        }
    }
}
