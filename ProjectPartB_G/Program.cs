using System;

namespace ProjectPartB_B1
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
            myDeck.Shuffle();
            Console.WriteLine(myDeck);

            HandOfCards player1 = new HandOfCards();
            HandOfCards player2 = new HandOfCards();

            //Your code to play the game comes here
            int NrOfCards;
            int NrOfRounds;
            TryReadNrOfCards(out NrOfCards);
            TryReadNrOfRounds(out NrOfRounds);
            for (int i = 1; i <= NrOfRounds; i++)
            {
                Console.WriteLine($"\nPlaying Round nr #{i}\n_ _ _ _ _ _ _ _ _ _");
                Console.WriteLine();
                Deal(myDeck, NrOfCards, player1, player2);
                Console.WriteLine();
                DetermineWinner(player1, player2);
                player1.Clear();
                player2.Clear();
                Console.WriteLine("___________________\n");
            }
        }

        /// <summary>
        /// Asking a user to give how many cards should be given to players.
        /// User enters an integer value between 1 and 5. 
        /// </summary>
        /// <param name="NrOfCards">Number of cards given by user</param>
        /// <returns>true - if value could be read and converted. Otherwise false</returns>
        private static bool TryReadNrOfCards(out int NrOfCards)
        {
            while (true)
            {
                Console.WriteLine("How many cards do you want to deal to each player? (1-5 or Q to Quit)");
                string userNrCardsInput = Console.ReadLine();
                int.TryParse(userNrCardsInput, out NrOfCards);
                if (userNrCardsInput == "q" || userNrCardsInput == "Q")
                {
                    Environment.Exit(0);
                }
                if (NrOfCards < 1 || NrOfCards > 5)
                {
                    Console.WriteLine("Wrong input, please enter a NUMBER between 1-5");
                }
                else break;
            }
            return true;
        }

        /// <summary>
        /// Asking a user to give how many round should be played.
        /// User enters an integer value between 1 and 5. 
        /// </summary>
        /// <param name="NrOfRounds">Number of rounds given by user</param>
        /// <returns>true - if value could be read and converted. Otherwise false</returns>
        private static bool TryReadNrOfRounds(out int NrOfRounds)
        {
            while (true)
            {
                Console.WriteLine("How many rounds do you want to play? (1-5 or Q to Quit)");
                string userNrRoundsInput = Console.ReadLine();
                int.TryParse(userNrRoundsInput, out NrOfRounds);
                if (userNrRoundsInput == "q" || userNrRoundsInput == "Q")
                {
                    Environment.Exit(0);
                }
                if (NrOfRounds < 1 || NrOfRounds > 5)
                {
                    Console.WriteLine("Wrong input, please enter a number between 1-5");
                }
                else break;
            }
            return true;
        }


        /// <summary>
        /// Removes from myDeck one card at the time and gives it to player1 and player2. 
        /// Repeated until players have recieved nrCardsToPlayer 
        /// </summary>
        /// <param name="myDeck">Deck to remove cards from</param>
        /// <param name="nrCardsToPlayer">Number of cards each player should recieve</param>
        /// <param name="player1">Player 1</param>
        /// <param name="player2">Player 2</param>
        private static void Deal(DeckOfCards myDeck, int nrCardsToPlayer, HandOfCards player1, HandOfCards player2)
        {
            for (int i = 0; i < nrCardsToPlayer; i++)
            {
                player1.Add(myDeck.RemoveTopCard());
                player2.Add(myDeck.RemoveTopCard());
            }
            Console.WriteLine($"Gave {nrCardsToPlayer} card(s) to each player from the top of the deck." +
                $" The deck has {myDeck.Count} cards remaining.\n");
            Console.WriteLine($"Player1's hand with {nrCardsToPlayer} cards.");
            Console.WriteLine($"Lowest card in the hand is [{player1.Lowest}] and the highest is [{player1.Lowest}]");
            Console.WriteLine(player1);
            Console.WriteLine();
            Console.WriteLine($"Player2's hand with {nrCardsToPlayer} cards.");
            Console.WriteLine($"Lowest card in the hand is [{player2.Lowest}] and the highest is [{player2.Lowest}]");
            Console.WriteLine(player2);
        }

        /// <summary>
        /// Determines and writes to Console the winner of player1 and player2. 
        /// Player with higest card wins. If both cards have equal value it is a tie.
        /// </summary>
        /// <param name="player1">Player 1</param>
        /// <param name="player2">Player 2</param>
        private static void DetermineWinner(HandOfCards player1, HandOfCards player2)
        {
            if (player1.Highest.CompareTo(player2.Highest) > 0)
            {
                Console.WriteLine("Player 1 wins!");
            }
            else if (player1.Highest.CompareTo(player2.Highest) < 0)
            {
                Console.WriteLine("Player 2 Wins!");
            }
            else if (player1.Highest.CompareTo(player2.Highest) == 0)
            {
                Console.WriteLine("Its a tie!");
            }
        }
    }
}
