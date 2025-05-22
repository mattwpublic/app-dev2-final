using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CardSort.Domain.Abstract;
using CardSort.WebUI.Models;
using CardSort.Domain.Entities;

namespace CardSort.WebUI.Controllers
{
    public class CardController : Controller
    {
       private ICardRepository myrepository;

        public CardController (ICardRepository myrepository)
        {
            this.myrepository = myrepository;
        }

        public int PageSize = 4;
        public ViewResult List(string category, int page = 1)
        {
            CardsListViewModel model = new CardsListViewModel
            {
                Cards = myrepository.Cards.Where(c => category == null || c.CardType == category).OrderBy(c => c.CardID).Skip((page - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    //TotalItems = myrepository.Cards.Count()
                    TotalItems = category == null? myrepository.Cards.Count() : myrepository.Cards.Where(e => e.CardType == category).Count()
                },
                CurrentCategory = category
            };
            return View(model);
        }

        public FileContentResult GetImage(int cardId)
        {
            Card card = myrepository.Cards.FirstOrDefault(c => c.CardID == cardId);

            if (card != null)
            {
                return File(card.ImageData, card.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
    }
}