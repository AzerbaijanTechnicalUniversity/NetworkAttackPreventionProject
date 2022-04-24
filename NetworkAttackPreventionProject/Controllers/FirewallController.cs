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
        [HttpPost]
        public IActionResult RunCMD(string argument)
        {
            Process p = new Process();
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.StartInfo.FileName = @"\System32\cmd.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.Verb = "runas";
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
        //public IActionResult ActiveFirewall()
        //{
        //    return View();
        //}
        //public IActionResult DeActiveFirewall()
        //{
        //    return View();
        //}
        public IActionResult ActiveFirewall()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/c netsh Advfirewall set allprofiles state on";
            startInfo.Verb = "runas";
            process.StartInfo = startInfo;
            process.Start();
            ViewData["status"] = "Actived";
            //string result = process.StandardOutput.ReadToEnd();
            //string cmd = "netsh Advfirewall set allprofiles state off";
            //ViewBag.resultActive = ExecuteCmd.ExecuteCommandSync(cmd);
            return RedirectToAction(nameof(Index));
        }
        //[AutoValidateAntiforgeryToken]
        public IActionResult DeActiveFirewall()
        {

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/c netsh Advfirewall set allprofiles state off";
            startInfo.Verb = "runas";
            process.StartInfo = startInfo;
            process.Start();
            ViewData["status"] = "Deactived";
            //string result = process.StandardOutput.ReadToEnd();
            //string cmd = "netsh Advfirewall set allprofiles state off";
            //ViewBag.resultActive = ExecuteCmd.ExecuteCommandSync(cmd);
            return RedirectToAction(nameof(Index));


            //System.Diagnostics.ProcessStartInfo myProcessInfo = new System.Diagnostics.ProcessStartInfo();
            //myProcessInfo.FileName = Environment.ExpandEnvironmentVariables("%SystemRoot%") + @"\System32\cmd.exe";
            //myProcessInfo.UseShellExecute = true;
            //myProcessInfo.Verb = "runas";
            //myProcessInfo.Arguments = "netsh Advfirewall set allprofiles state off";
            //myProcessInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            //System.Diagnostics.Process.Start(myProcessInfo);
            //return View();


            //Process proc = new Process("cmd","/c netsh Advfirewall set allprofiles state off");
            //proc.StartInfo.FileName = "cmd.exe";
            //proc.StartInfo.UseShellExecute = true;
            //proc.StartInfo.Verb = "runas";
            //proc.Start();
            //return View();




            //Process firewall = new Process();
            //firewall.StartInfo.FileName = "cmd.exe"; 
            //firewall.StartInfo.WorkingDirectory = @"\windows\system32\";
            //firewall.StartInfo.Verb = "runas";
            //firewall.StartInfo.Arguments = "/c netsh advfirewall set currentprofile state off";
            //firewall.Start();
            //return View();
        }
    }
}
