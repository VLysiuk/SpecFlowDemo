using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SpecFlowDemo;
using TechTalk.SpecFlow;

namespace BlackJack.Specs.Steps
{
    [Binding]
    public class UsingAceSteps
    {
        private readonly GameContext _gameContext;

        public UsingAceSteps(GameContext gameContext)
        {
            _gameContext = gameContext;
        }

        [When(@"I take 10 and Ace")]
        public void WhenITake10AndAce()
        {
            _gameContext.Player.TakeCard(new Card(CardRank.Ten, CardSuit.Diamond));
            _gameContext.Player.TakeCard(new Card(CardRank.Ace, CardSuit.Spade));
        }

        [Then(@"I have Black Jack")]
        public void ThenIHaveBlackJack()
        {
            Assert.IsTrue(_gameContext.Player.HasBlackJack);
        }

        [When(@"I take 10 and Queen and Ace")]
        public void WhenITake10AndQueenAndAce()
        {
            _gameContext.Player.TakeCard(new Card(CardRank.Ten, CardSuit.Diamond));
            _gameContext.Player.TakeCard(new Card(CardRank.Queen, CardSuit.Club));
            _gameContext.Player.TakeCard(new Card(CardRank.Ace, CardSuit.Spade));
        }
    }
}
