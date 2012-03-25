using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpecFlowDemo
{
    public class Hand
    {
        private readonly List<Card> _cards;
        public const int BlackJackScore = 21;

        public Hand()
        {
            _cards = new List<Card>();
        }

        public int CardsCount
        {
            get { return _cards.Count; }
        }

        public int TotalScore
        {
            get { return CalculateCurrentTotalScore(); }
        }

        public void Add(Card card)
        {
            _cards.Add(card);
        }

        public void Clear()
        {
            _cards.Clear();
        }

        private int CalculateCurrentTotalScore()
        {
            int noAceSum = _cards.Where(c => c.Rank != CardRank.Ace).Sum(c => (int) c.Rank > 10 ? 10 : (int) c.Rank);
            int scoreDiff = BlackJackScore - noAceSum;

            var aceCount = _cards.Where(c => c.Rank == CardRank.Ace).Count();

            var totalScore = noAceSum;

            for(var i=0;i<aceCount;i++)
            {
                var aceValue = scoreDiff < 11 ? 1 : 11;

                totalScore += aceValue;
                scoreDiff = BlackJackScore - totalScore;
            }

            return totalScore;
        }

    }
}
