using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardSort.Domain.Abstract;
using CardSort.Domain.Entities;

namespace CardSort.Domain.Concrete
{
    public class EFCardRepository : ICardRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Card> Cards
        {
            get { return context.Cards; }
        }

        void ICardRepository.SaveCard(Card card)
        {
            if (card.CardID == 0)
            {
                context.Cards.Add(card);
            }
            else
            {
                Card dbEntry = context.Cards.Find(card.CardID);

                if (dbEntry != null)
                {
                    dbEntry.Name = card.Name;
                    dbEntry.Colors = card.Colors;
                    dbEntry.CardType = card.CardType;
                    dbEntry.SetCode = card.SetCode;
                    dbEntry.CollectorNumber = card.CollectorNumber;
                    dbEntry.ArtistName = card.ArtistName;

                    dbEntry.ImageData = card.ImageData;
                    dbEntry.ImageMimeType = card.ImageMimeType;
                }
            }
            context.SaveChanges();
        }

        public Card DeleteCard(int cardID)
        {
            Card dbEntry = context.Cards.Find(cardID);
            if (dbEntry != null)
            {
                context.Cards.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
