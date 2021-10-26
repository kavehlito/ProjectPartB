using System.Linq;

namespace ProjectPartB_B1
{
    class HandOfCards : DeckOfCards, IHandOfCards
    {
        #region Pick and Add related
        public void Add(PlayingCard card) => cards.Add(card);
        #endregion

        #region Highest Card related
        public PlayingCard Highest => cards.Max();

        public PlayingCard Lowest => cards.Min();

        #endregion
    }
}
