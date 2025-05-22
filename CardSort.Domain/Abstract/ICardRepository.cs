using System;
using System.Collections.Generic;
using CardSort.Domain.Entities;

namespace CardSort.Domain.Abstract
{
    public interface ICardRepository
    {
        IEnumerable<Card> Cards { get; }

        void SaveCard(Card card);

        Card DeleteCard(int cardID);
    }
}
