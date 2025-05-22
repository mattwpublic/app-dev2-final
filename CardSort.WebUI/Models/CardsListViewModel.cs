using System.Collections.Generic;
using CardSort.Domain.Entities;

namespace CardSort.WebUI.Models
{
    public class CardsListViewModel
    {
        public IEnumerable<Card> Cards { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}