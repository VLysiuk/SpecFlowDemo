using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SpecFlowDemo;

namespace BlackJack.Tests
{
    [TestFixture]
    public class DealerTest
    {
        [Test]
        public void ShouldNotAddCardsToHandWhenReachedScoreLimit()
        {
            var dealer = new Dealer();
            dealer.TakeCard(new Card(CardRank.Queen,CardSuit.Club));
            dealer.TakeCard(new Card(CardRank.Eight, CardSuit.Heart));

            var currentScore = dealer.TotalScore;
            dealer.TakeCard(new Card(CardRank.Two,CardSuit.Spade));
            
            Assert.AreEqual(currentScore,dealer.TotalScore);
        }
    }
}
