using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CardSort.Domain.Entities
{
    public class Card
    {
        [HiddenInput (DisplayValue = false)]
        public int CardID { get; set; }

        [Required(ErrorMessage = "Please enter a card name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the card's colors. For example: W,U,B,R,G,C")]
        public string Colors { get; set; }

        [Required(ErrorMessage = "Please enter the card's type(s). For example: instant, sorcery, enchantment, creature, etc.")]
        public string CardType { get; set; }

        [Required(ErrorMessage = "Please enter the card's three-letter set code such as m21, m19, etc.")]
        public string SetCode { get; set; }

        [Required(ErrorMessage = "Please enter the card's collector number for the set that it was printed in.")]
        public int CollectorNumber { get; set; }

        [Required(ErrorMessage = "Please enter the card's artist's name.")]
        public string ArtistName { get; set; }

        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }

    }
}
