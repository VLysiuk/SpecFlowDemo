using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SpecFlowDemo;

namespace BlackJack.Tests
{
    [TestFixture]
    public class PlayerTest
    {
        [Test]
        public void ShouldKeepCardsInHandWhenTakeFromDeck()
        {
            var player = new Player();
            var card1 = new Card(CardRank.Queen,CardSuit.Heart);
            var card2 = new Card(CardRank.Two,CardSuit.Spade);
            
            player.TakeCard(card1);
            player.TakeCard(card2);

            Assert.AreEqual(2,player.CardsInHand);
        }

        [Test]
        public void ShouldIndicateBlackJackWhenHaveItInHand()
        {
            var player = new Player();

            player.TakeCard(new Card(CardRank.Ace, CardSuit.Heart));
            player.TakeCard(new Card(CardRank.Queen, CardSuit.Spade));

            Assert.IsTrue(player.HasBlackJack);
        }

        [Test]
        public void ShouldBeBustedWhenScoresCountIsMoreThenMax()
        {
            var player = new Player();

            player.TakeCard(new Card(CardRank.King, CardSuit.Heart));
            player.TakeCard(new Card(CardRank.Queen, CardSuit.Spade));
            player.TakeCard(new Card(CardRank.Queen, CardSuit.Club));

            Assert.IsTrue(player.IsBusted);
        }
    }
}
