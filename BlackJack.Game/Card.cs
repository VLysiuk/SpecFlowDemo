using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpecFlowDemo
{
    public enum CardSuit
    {
        Spade,
        Diamond,
        Heart,
        Club
    }

    public enum CardRank
    {
        Two=2,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }

    public class Card
    {
        public Card(CardRank rank,CardSuit suit)
        {
            Rank = rank;
            Suit = suit;
        }

        public CardRank Rank { get; private set; }

        public CardSuit Suit { get; private set; }
    }
}
