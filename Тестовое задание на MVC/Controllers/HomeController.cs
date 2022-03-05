using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Тестовое_задание_на_MVC.Models;

namespace Тестовое_задание_на_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Sum()
        {
            return View(-1);
        }
        [HttpPost]
        public IActionResult Sum(string stringNumbers)
        {
            string[] masString = stringNumbers.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int[] masNumbers = new int[masString.Length];
            for (int i = 0; i < masString.Length; i++)
            {
                masNumbers[i] = int.Parse(masString[i]);
            }
            var result = 0;
            var count = 0;
            foreach (var number in masNumbers)
            {
                if (number % 2 != 0)
                {
                    count++;
                    if (count % 2 == 0)
                    {
                        result += number;
                    }
                }
            }
            if (result < 0)
            {
                int positiveResult = -result;
                return View(positiveResult);
            }
            return View(result);
        }
        [HttpGet]
        public IActionResult JoinLinkedList()
        {
            return View();
        }
        [HttpPost]
        public LinkedList<string> JoinLinkedList(string list1, string list2)
        {
            var linkedList1 = new LinkedList<string>();
            var linkedList2 = new LinkedList<string>();
            var linkedList3 = new LinkedList<string>();

            string[] masString1 = list1.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] masString2 = list2.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var i in masString1)
            {
                linkedList1.AddFirst(i);
            }
            foreach (var i in masString2)
            {
                linkedList2.AddFirst(i);
            }

            var linkedListMetods = new LinkedListMetods();
            linkedListMetods.Mes(0, linkedList1, linkedList2, linkedList3);

            return linkedList3;
        }       
        [HttpGet]
        public IActionResult VerifyPolindrom()
        {
            return View();
        }
        [HttpPost]
        public string VerifyPolindrom(string word)
        {
            var brokenWordReversed = word.Reverse();
            var wordReversed = string.Concat(brokenWordReversed);
            if (wordReversed == word)
            {
                return "Строка полиндром";
            }
            return "Строка не полиндром";
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
