using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPartB_B2
{
	public class PlayingCard:IComparable<PlayingCard>, IPlayingCard
	{
		public PlayingCardColor Color { get; init; }
		public PlayingCardValue Value { get; init; }

		#region IComparable Implementation
		//Need compare value and color in poker. If values are equal, color determines highest card
		public int CompareTo(PlayingCard card1)
        {
            if (card1.Value.CompareTo(card1.Value) != 0)
            {
			return card1.CompareTo(card1);
            }
			else 
				return card1.Color.CompareTo(card1.Color);
        }
		#endregion

        #region ToString() related
		string ShortDescription
		{
			//Use switch statment or switch expression
			//https://en.wikipedia.org/wiki/Playing_cards_in_Unicode
			get
			{
				char c = Color switch
				{
					PlayingCardColor.Clubs => '\u2663',
					PlayingCardColor.Spades => '\u2660',
					PlayingCardColor.Hearts => '\u2665',
					PlayingCardColor.Diamonds => '\u2666'
				};
				return $"{c} {Value.ToString()}";
			}
		}

		public override string ToString() => ShortDescription;
        #endregion
    }
}
