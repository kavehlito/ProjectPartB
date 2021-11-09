using System;

namespace ProjectPartB_B2
{
    class Program
    {
        static void Main(string[] args)
        {
            DeckOfCards myDeck = new DeckOfCards();
            myDeck.CreateFreshDeck();
            Console.WriteLine($"\nA freshly created deck with {myDeck.Count} cards:");
            Console.WriteLine(myDeck);

            Console.WriteLine($"\nA sorted deck with {myDeck.Count} cards:");
            myDeck.Sort();
            Console.WriteLine(myDeck);

            Console.WriteLine($"\nA shuffled deck with {myDeck.Count} cards:");
            // myDeck.Shuffle();
            Console.WriteLine(myDeck);

            PokerHand Player = new PokerHand();
            myDeck.Reverse();
            while (myDeck.Count >= 5)
            {
                //Your code to Give 5 cards to the player and determine the rank
                //Continue for as long as the deck has at least 5 cards 
                for (int i = 0; i < 5; i++)
                {
                    Player.Add(myDeck.RemoveTopCard());
                }
                Console.WriteLine($"Player Hand: {Player}");
                Player.DetermineRank();
                Console.WriteLine($"Rank is {Player.Rank} with the rank-high-card {Player.Highest}");
                Console.WriteLine($"The Deck has {myDeck.Count} cards left\n");
                Player.Clear();
            }
        }
    }
}
