using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChequeAmount.Models;

namespace ChequeAmount.Controllers
{
    public class HomeController : Controller
    {
        private INumberToWordConvertor _convertor;
        public HomeController(INumberToWordConvertor convertor)
        {
            _convertor = convertor;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        //public IActionResult Contact()
        //{
        //    ViewData["Message"] = "Your contact page.";

        //    return View();
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult ConvertNumberToWords(string givenNumber)
        {
            try
            {
                string result = _convertor.NumberToWords(givenNumber);
                return Json(new { errorNumber = 0, message = "", result = result });
            }
            catch
            {
                return Json(new { errorNumber = 1, message = "The given value is not convertable" });
            }
        }
    }
}
