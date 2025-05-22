using System.Web.Mvc;
using CardSort.Domain.Abstract;
using System.Linq;
using CardSort.Domain.Entities;
using System.Web;

namespace CardSort.WebUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private ICardRepository repository;

        public AdminController(ICardRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index()
        {
            return View(repository.Cards);
        }

        public ViewResult Edit (int cardID)
        {
            Card card = repository.Cards.FirstOrDefault(c => c.CardID == cardID);
            return View(card);
        }

        [HttpPost]
        public ActionResult Edit(Card card, HttpPostedFileBase image=null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    card.ImageMimeType = image.ContentType;
                    card.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(card.ImageData, 0, image.ContentLength);
                }
                repository.SaveCard(card);
                TempData["message"] = string.Format("{0} has been saved.", card.Name);
                return RedirectToAction("Index");
            }
            else
            {
                return View(card);
            }
        }

        public ViewResult Create()
        {
            ViewBag.operation = "create";
            return View("Edit", new Card());
        }

        [HttpPost]
        public ActionResult Delete(int cardID)
        {
            Card deletedCard = repository.DeleteCard(cardID);
            if (deletedCard != null)
            {
                TempData["message"] = string.Format("{0} was deleted.", deletedCard.Name);
            }
            return RedirectToAction("Index");
        }

    }
}