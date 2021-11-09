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
        private int NrSameValue(int firstValueIdx, out int lastValueIdx, out int counter, out PlayingCard HighCard)
        {
            lastValueIdx = 0;
            counter = 0;
            for (int i = firstValueIdx; i < 5; i++)
            {
                if (this[i].Value == this[4].Value)
                {
                    lastValueIdx = i;
                    counter++;
                }
            }
            HighCard = Highest;
            return lastValueIdx;
        }
        private bool IsSameColor(out PlayingCard HighCard)
        {
            int counter = 0;
            HighCard = Highest;
            for (int i = 0; i < 5; i++)
            {
                if (this[i] == this[4])
                {
                    counter++;
                }
            }
            if (counter == 4) return true;
            else return false;

        }
        private bool IsConsecutive(out PlayingCard HighCard)
        {
            HighCard = Highest;
            var prevValue = HighCard;
            for (int i = 1; i < 5; i++)
            {
                if (HighCard.Value == prevValue.Value + 1)
                    prevValue = HighCard;
                else
                    return false;
            }
            return true;
        }

        //Hint: Worker Properties to examine each rank
        private bool IsRoyalFlush => IsSameColor(out _) && IsConsecutive(out _rankHigh) && _rankHigh.Value == PlayingCardValue.Ace;
        private bool IsStraightFlush => IsSameColor(out _) && IsConsecutive(out _rankHigh);
        private bool IsFourOfAKind
        {
            get
            {
                int lastValueIdx;
                int counter;
                NrSameValue(0, out lastValueIdx, out counter, out _rankHigh);
                if (counter == 3)
                {
                    return true;
                }
                return false;
            }
        }
        private bool IsFullHouse => false;
        private bool IsFlush => IsSameColor(out _rankHigh);
        private bool IsStraight => IsConsecutive(out _rankHigh);
        private bool IsThreeOfAKind
        {
            get
            {
                int lastValueIdx;
                int counter;
                NrSameValue(0, out lastValueIdx, out counter, out _rankHigh);
                if (counter == 2)
                {
                    return true;
                }
                return false;
            }
        }
        private bool IsTwoPair
        {
            get
            {
                int lastValueIdx;
                int lastValueIdx2;
                int counter;
                int counter2;
                NrSameValue(0, out lastValueIdx, out counter, out _rankHighPair2);
                NrSameValue(lastValueIdx + 1, out lastValueIdx2, out counter2, out _rankHighPair2);
                if (counter == 1 && counter2 == 1)
                {
                    return true;
                }
                return false;
            }

        }
        private bool IsPair
        {
            get
            {
                int lastValueIdx;
                int counter;
                NrSameValue(0, out lastValueIdx, out counter, out _rankHighPair1);
                if (counter == 1)
                {
                    return true;
                }
                return false;
            }
        }

        public PokerRank DetermineRank()
        {
            ClearRank();
            if (IsRoyalFlush) return PokerRank.RoyalFlush;
            if (IsStraightFlush) return PokerRank.StraightFlush;
            if (IsFourOfAKind) return PokerRank.FourOfAKind;
            if (IsFullHouse) return PokerRank.FullHouse;
            if (IsFlush) return PokerRank.Flush;
            if (IsStraight) return PokerRank.Straight;
            if (IsThreeOfAKind) return PokerRank.ThreeOfAKind;
            if (IsTwoPair) return PokerRank.TwoPair;
            if (IsPair) return PokerRank.Pair;
            else return PokerRank.Unknown;
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
