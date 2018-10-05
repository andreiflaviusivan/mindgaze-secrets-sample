using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Mindgaze.Tools.Secrets;
using Secrets.Sample.Models;

namespace Secrets.Sample.Controllers
{
    public class HomeController : Controller
    {
        private readonly string EnvironmentName;
        private readonly string ConnectionString;

        public HomeController(AppSecrets appSecrets, IHostingEnvironment hostingEnvironment, IConfiguration configuration)
        {
            EnvironmentName = hostingEnvironment.EnvironmentName;
            ConnectionString = appSecrets.Decrypt(configuration["ConnectionString"]);
        }

        public IActionResult Index()
        {
            ViewData["EnvironmentName"] = EnvironmentName;
            ViewData["ConnectionString"] = ConnectionString;
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
