using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SpecFlowDemo;

namespace BlackJack.Tests
{
    [TestFixture]
    public class SimpleDeckFillerTest
    {
        [Test]
        public void ShouldReturnStandardDeckBasedOnAllRanksAndSuits()
        {
            var simpleDeckFiller = new SimpleDeckFiller();
            var deck = simpleDeckFiller.Fill();

            Assert.AreEqual(52,deck.Count);
        }
    }
}
