using System;

namespace ProjectPartB_B2
{
    class PokerHand : HandOfCards
    {
        #region Clear
        public override void Clear() => cards.Clear();
        #endregion

        #region Remove and Add related
        public override void Add(PlayingCard card) => cards.Add(card);
        #endregion

        #region Poker Rank related
        //https://www.poker.org/poker-hands-ranking-chart/

        //Hint: using backing fields
        private PokerRank _rank = PokerRank.Unknown;
        private PlayingCard _rankHigh = null;
        private PlayingCard _rankHighPair1 = null;
        private PlayingCard _rankHighPair2 = null;

        public PokerRank Rank => _rank;
        public PlayingCard RankHiCard => _rankHigh;
        public PlayingCard RankHiCardPair1 => _rankHighPair1;
        public PlayingCard RankHiCardPair2 => _rankHighPair2;

        //Hint: Worker Methods to examine a sorted hand
        private int NrSameValue(int firstValueIdx, out int lastValueIdx, out PlayingCard HighCard) 
        {
            lastValueIdx = 0;
            HighCard = null;
            return HighCard.Value.CompareTo(HighCard.Value); 
        }
        private bool IsSameColor(out PlayingCard HighCard)
        {
            HighCard = null;
            return HighCard.Color == HighCard.Color;
        }
        private bool IsConsecutive(out PlayingCard HighCard)
        {
            HighCard = null;
            var prevDice = HighCard.Value;
            for (int i = 1; i < Count; i++)
            {
                if (HighCard.Value == prevDice + 1)
                    prevDice = HighCard.Value;
                else
                    return false;
            }
            return true;
        }

        //Hint: Worker Properties to examine each rank
        private bool IsRoyalFlush => false;
        private bool IsStraightFlush => false;
        private bool IsFourOfAKind => false;
        private bool IsFullHouse => false;
        private bool IsFlush => false;
        private bool IsStraight => false;
        private bool IsThreeOfAKind => false;
        private bool IsTwoPair
        {
            get
            {
                return false;
            }
        }
        private bool IsPair => NrSameValue();

        public PokerRank DetermineRank()
        {
            return PokerRank.Unknown;
        }

        //Hint: Clear rank
        private void ClearRank()
        {
            _rankHigh = null;
            _rankHighPair1 = null;
            _rankHighPair2 = null;
            _rank = PokerRank.Unknown;
        }
        #endregion
    }
}
