using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrademeApp.Models;

namespace TrademeApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var package = new Package(0, 0, 0, 0);
            return View(package);
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

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult Shipping(int Height, int Length, int Breadth, int Weight) {
            var package = new Package(Length, Breadth, Height, Weight);


            var tooHeavySpec = new Specification<Package>(x => x.Weight > 25 || x.Weight < 0 || x.Length < 1 || x.Breadth < 1 || x.Height < 1 || x.Length > 400 || x.Breadth > 600 || x.Height > 250);
            var smallSpec = new Specification<Package>(x => x.Length <= 200 && x.Breadth <= 300 && x.Height <= 150);
            var mediumSpec = new Specification<Package>(x => x.Length <= 300 && x.Breadth <= 400 && x.Height <= 200);
            var largeSpec = new Specification<Package>(x => x.Length <= 400 && x.Breadth <= 600 && x.Height <= 250);
            var moreThanLargeSpec = new Specification<Package>(x => x.Length > 400 && x.Breadth > 600 && x.Height > 250);

            //create the types of shipping

            var notPackingSolution = new Shipping<Package>("Package Not Support", 0);
            var small = new Shipping<Package>("Small", 5);
            var medium = new Shipping<Package>("Medium", 7.5);
            var large = new Shipping<Package>("Large", 8.5);

            //insert rules for business logic

            notPackingSolution.SetSpecification(tooHeavySpec);
            small.SetSpecification(smallSpec);
            medium.SetSpecification(mediumSpec);
            large.SetSpecification(largeSpec);

            //first check if its aproved to shipping 

            //then start the chain of responsability for package
            notPackingSolution.SetSuccessor(small);
            small.SetSuccessor(medium);
            medium.SetSuccessor(large);

            notPackingSolution.ProcessShipping(ref package);
            //algo falta aca... para poder entregar el objeto shipping
            return View(package);
        }
    }
}
