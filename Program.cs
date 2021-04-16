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
    class Program
    {
        static void Main(string[] args)
        {
            var faces = new List<string>() { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };
            var suits = new List<string>() { "Hearts", "Spades", "Clubs", "Diamonds" };
            var deck = new List<Card>();

            foreach (var suit in suits)
            {
                foreach (var face in faces)
                {
                    deck.Add(new Card()
                    {
                        Face = face,
                        Suit = suit
                    });
                }
            }
            for (var rightIndex = deck.Count - 1; rightIndex >= 0; rightIndex--)
            {
                var leftIndex = new Random().Next(0, rightIndex);
                var rightNum = deck[rightIndex];
                deck[rightIndex] = deck[leftIndex];
                deck[leftIndex] = rightNum;
            }

            var playerHand = new List<Card>();
            var dealerHand = new List<Card>();

            // Drawing for the Player
            playerHand.Add(deck[0]);
            deck.RemoveAt(0);
            playerHand.Add(deck[0]);
            deck.RemoveAt(0);

            var playerHandTotal = 0;

            foreach (var drawnCard in playerHand)
            {
                Console.WriteLine($"{drawnCard.Face} of {drawnCard.Suit}");
                playerHandTotal += drawnCard.CardValue();
            }
            Console.WriteLine($"{playerHandTotal}");

            // Drawing for the Player
            dealerHand.Add(deck[0]);
            deck.RemoveAt(0);
            dealerHand.Add(deck[0]);
            deck.RemoveAt(0);
            var dealerHandTotal = 0;
            foreach (var drawnCard in dealerHand)
            {
                dealerHandTotal += drawnCard.CardValue();
            }
            Console.WriteLine($"{dealerHandTotal}");


        }
    }
}


