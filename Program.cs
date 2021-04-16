using System;
using System.Collections.Generic;

namespace valuePicking
{
    public class Card
    {
        public string Face { get; set; }
        public string Suit { get; set; }
        public int CardValue()
        {
            switch (Face)
            {
                case "Ace":
                    return 11;
                case "King":
                    return 10;
                case "Queen":
                    return 10;
                case "Jack":
                    return 10;
                default:
                    return int.Parse(Face);
            }

        }
    }
    public class Deck
    {
        public List<Card> Cards { get; set; } = new List<Card>();

        public void CreateDeck()
        {
            var faces = new List<string>() { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };
            var suits = new List<string>() { "Hearts", "Spades", "Clubs", "Diamonds" };
            foreach (var suit in suits)
            {
                foreach (var face in faces)
                {
                    var card = new Card()
                    {
                        Face = face,
                        Suit = suit
                    };
                    Cards.Add(card);
                }
            }
        }
        public void ShuffleDeck()
        {
            for (var rightIndex = Cards.Count - 1; rightIndex >= 0; rightIndex--)
            {
                var leftIndex = new Random().Next(0, rightIndex);
                var rightNum = Cards[rightIndex];
                Cards[rightIndex] = Cards[leftIndex];
                Cards[leftIndex] = rightNum;
            }
        }
    }
    class Program
    {
        public static void Greeting()
        {
            Console.WriteLine($"");
            Console.WriteLine($"------------------------------");
            Console.WriteLine($"Welcome to Blackjack!");
            Console.WriteLine($"------------------------------");
            Console.WriteLine($"");
            Console.WriteLine("Would you like to play BlackJack? Yes or No?");
            var isNotPlaying = true;
            while (isNotPlaying)
            {
                var playingResponse = Console.ReadLine().ToLower();
                switch (playingResponse[0])
                {
                    case 'y':
                        Console.WriteLine($"Lets Play!");
                        isNotPlaying = false;
                        break;
                    case 'n':
                        Console.WriteLine($"If you'd like to play in future just type 'Yes'. Goodbye!");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine($"Please enter Yes or No...");
                        break;
                }
            }

        }
        // Is Busted method *Likely to refactor later
        public static bool IsBusted(int handTotal)
        {
            if (handTotal > 21)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static void Main(string[] args)
        {
            Greeting();
            // Initialize new Deck
            var deck = new Deck();
            // Use Create method
            Console.WriteLine($"Generating Deck...");
            deck.CreateDeck();
            // Use shuffle method
            Console.WriteLine($"Shuffling Deck...");

            deck.ShuffleDeck();

            var playerHand = new List<Card>();
            var dealerHand = new List<Card>();

            // Drawing for the Player
            Console.WriteLine($"Player Hand");
            Console.WriteLine($"------------------------------");
            playerHand.Add(deck.Cards[0]);
            deck.Cards.RemoveAt(0);
            playerHand.Add(deck.Cards[0]);
            deck.Cards.RemoveAt(0);

            var playerHandTotal = 0;

            foreach (var drawnCard in playerHand)
            {
                Console.WriteLine($"{drawnCard.Face} of {drawnCard.Suit}");
                playerHandTotal += drawnCard.CardValue();
            }
            Console.WriteLine($"Player Total: {playerHandTotal}");
            Console.WriteLine($"------------------------------");
            IsBusted(playerHandTotal);


            // Drawing for the Dealer
            dealerHand.Add(deck.Cards[0]);
            deck.Cards.RemoveAt(0);
            dealerHand.Add(deck.Cards[0]);
            deck.Cards.RemoveAt(0);
            var dealerHandTotal = 0;

            foreach (var drawnCard in dealerHand)
            {
                dealerHandTotal += drawnCard.CardValue();
            }
            Console.WriteLine($"Dealer Total: {dealerHandTotal} **To be Removed**");
            IsBusted(dealerHandTotal);
            var isGameRunning = true;
            // Starting Game logic
            while (isGameRunning)
            {
                Console.WriteLine($"Your current score: {playerHandTotal}. Would you like to 'hit' or 'stay'?");
                var playerResponse = Console.ReadLine().ToLower();
                if (playerResponse[0] == 'h')
                {
                    playerHand.Add(deck.Cards[0]);
                    playerHandTotal += deck.Cards[0].CardValue();
                    deck.Cards.RemoveAt(0);
                }
                if (playerResponse[0] == 's')
                {
                    if (dealerHandTotal < 17)
                    {
                        dealerHand.Add(deck.Cards);
                        deck.Cards.RemoveAt(0);
                    }
                }
                foreach (var drawnCard in playerHand)
                {
                    Console.WriteLine($"{drawnCard.Face} of {drawnCard.Suit}");
                }
                if (IsBusted(playerHandTotal) && IsBusted(dealerHandTotal))
                {
                    Console.WriteLine($"No one wins!");
                }
                if (IsBusted(playerHandTotal) && !IsBusted(dealerHandTotal))
                {
                    Console.WriteLine($"Dealer Wins");
                }
            }


        }
    }
}


