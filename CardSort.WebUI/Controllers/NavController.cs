using CardSort.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CardSort.WebUI.Controllers
{
    public class NavController : Controller
    {
        private ICardRepository repository;

        public NavController (ICardRepository repo)
        {
            repository = repo;
        }

        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;

            IEnumerable<string> categories = repository.Cards.Select(c => c.CardType).Distinct().OrderBy(c => c);

            return PartialView(categories);
        }
    }
}