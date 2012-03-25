using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using NUnit.Framework;
using SpecFlowDemo;

namespace BlackJack.Tests
{
    [TestFixture]
    public class DeckTest
    {
        private Mock<IDeckFiller> _deckFiller;

        [SetUp]
        public void SetUp()
        {
            _deckFiller=new Mock<IDeckFiller>();
        }

        [Test] 
        public void ShouldFillDeckWhenCreate()
        {
            var deck = new Deck(_deckFiller.Object);
            _deckFiller.Verify(_=>_.Fill());
        }

        [Test]
        public void ShouldReturnCardWhenDraw()
        {
            _deckFiller.Setup(_ => _.Fill()).Returns(new List<Card> 
                                                             {
                                                                 new Card(CardRank.Three, CardSuit.Spade)
                                                             }
                                                     );
            var deck = new Deck(_deckFiller.Object);
            var card = deck.DrawCard();

            Assert.IsNotNull(card);
        }

        [Test]
        public void ShouldReturnNullWhenNoCardsInDeck()
        {
            _deckFiller.Setup(_ => _.Fill()).Returns(new List<Card>());
            var deck = new Deck(_deckFiller.Object);

            var card = deck.DrawCard();

            Assert.IsNull(card);
        }
    }
}
