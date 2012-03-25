using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SpecFlowDemo;

namespace BlackJack.Tests
{
    [TestFixture]
    public class HandTest
    {
        [Test]
        public void ShoudAddCardsToHand()
        {
            var hand = new Hand();
            hand.Add(new Card(CardRank.Ten, CardSuit.Diamond));
            hand.Add(new Card(CardRank.Ten, CardSuit.Heart));

            Assert.AreEqual(2,hand.CardsCount);
        }

        [Test]
        public void ShouldRemoveAllCardsWhenClearHand()
        {
            var hand = new Hand();
            hand.Add(new Card(CardRank.Ten, CardSuit.Diamond));
            hand.Add(new Card(CardRank.Ten, CardSuit.Heart));

            hand.Clear();

            Assert.AreEqual(0, hand.CardsCount);
        }

        [Test]
        public void ShouldCalculateTotalScoreAccordingToCardsRanks()
        {
            var hand = new Hand();
            hand.Add(new Card(CardRank.Ten, CardSuit.Diamond));
            hand.Add(new Card(CardRank.Seven, CardSuit.Heart));

            Assert.AreEqual(17,hand.TotalScore);
        }

        [Test]
        public void ShouldUseAceAsOneWhenNeeded()
        {
            var hand = new Hand();
            hand.Add(new Card(CardRank.Ace, CardSuit.Diamond));
            hand.Add(new Card(CardRank.Ten, CardSuit.Heart));
            hand.Add(new Card(CardRank.Ten, CardSuit.Club));

            Assert.AreEqual(21, hand.TotalScore);
        }

        [Test]
        public void ShouldUseAceAsElevenWhenNeeded()
        {
            var hand = new Hand();
            hand.Add(new Card(CardRank.Ace, CardSuit.Diamond));
            hand.Add(new Card(CardRank.Ten, CardSuit.Heart));

            Assert.AreEqual(21, hand.TotalScore);
        }
    }
}
