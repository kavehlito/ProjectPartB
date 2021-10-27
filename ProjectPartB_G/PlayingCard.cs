using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPartB_B1
{
	public class PlayingCard:IComparable<PlayingCard>, IPlayingCard
	{
		public PlayingCardColor Color { get; init; }
		public PlayingCardValue Value { get; init; }

		#region IComparable Implementation
		//Need only to compare value in the project
		public int CompareTo(PlayingCard card1)
        {
			return Value.CompareTo(card1.Value);
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
