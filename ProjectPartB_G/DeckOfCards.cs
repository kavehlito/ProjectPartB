﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectPartB_B1
{
    class DeckOfCards : IDeckOfCards
    {
        #region cards List related
        protected const int MaxNrOfCards = 52;
        protected List<PlayingCard> cards = new List<PlayingCard>(MaxNrOfCards);

        public PlayingCard this[int idx] => cards[idx];
        public int Count => cards.Count;
        #endregion

        #region ToString() related
        public override string ToString()
        {
            string sRet = "";
            for (int i = 0; i < Count; i++)
            {
                sRet += $"{cards[i].ToString(),-9}";
                if ((i + 1) % 13 == 0)
                    sRet += "\n";
               
            }
            return sRet;
        }
        #endregion

        #region Shuffle and Sorting
        public void Shuffle()
        {
            var rnd = new Random(); //rnd is now a random generator - see .NET documentation
            cards = cards.OrderBy(x => rnd.Next()).ToList();
        }
        public void Sort()
        {
            cards.OrderBy(v => v.Color).ThenBy(c => c.Value).ToList();
        }
        #endregion

        #region Creating a fresh Deck
        public void Clear()
        {
            cards.Clear();
        }
        public void CreateFreshDeck()
        {
            for (PlayingCardColor c = PlayingCardColor.Clubs; c <= PlayingCardColor.Spades; c++)
            {
                for (PlayingCardValue v = PlayingCardValue.Two; v <= PlayingCardValue.Ace; v++)
                {
                    cards.Add(new PlayingCard { Color = c, Value = v });
                }
            }
        }
        #endregion

        #region Dealing
        public PlayingCard RemoveTopCard()
        {
            PlayingCard card = cards.First();
            cards = cards.Skip(1).ToList();
            return card;
        }
        #endregion
    }
}