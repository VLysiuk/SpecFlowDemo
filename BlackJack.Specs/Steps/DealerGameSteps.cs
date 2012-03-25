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
    public class DealerGameSteps
    {
        private readonly GameContext _gameContext;

        public DealerGameSteps(GameContext gameContext)
        {
            _gameContext = gameContext;
        }

        [When(@"dealer has total score more then 17")]
        public void WhenDealerHasTotalScoreMoreThen17()
        {
            Assert.IsTrue(_gameContext.Dealer.TotalScore>=17);
        }

        [Then(@"he cannot take a card")]
        public void ThenHeCannotTakeACard()
        {
            Assert.IsFalse(_gameContext.Dealer.CanTakeAnotherCard);
        }

        [Given(@"player has finished drawing")]
        public void GivenPlayerHasFinishedDrawing()
        {
            _gameContext.BlackJackGame.PlayerHasFinished = true;
        }

        [When(@"dealer has total score less then 17")]
        public void WhenDealerHasTotalScoreLessThen17()
        {
            _gameContext.Dealer.TakeCard(new Card(CardRank.Two,CardSuit.Diamond));
            _gameContext.Dealer.TakeCard(new Card(CardRank.Three,CardSuit.Spade));

            Assert.Less(_gameContext.Dealer.TotalScore, 17);
        }

        [Then(@"he should take a card while his total score less then 17")]
        public void ThenHeShouldTakeACardWhileHisTotalScoreLessThen17()
        {
            _gameContext.BlackJackGame.DealerMove();

            Assert.IsTrue(_gameContext.Dealer.TotalScore>=17);
        }

        [Given(@"player has not finished drawing")]
        public void GivenPlayerHasNotFinishedDrawing()
        {
            _gameContext.BlackJackGame.PlayerHasFinished = false;
        }

        [Then(@"he should take a card")]
        public void ThenHeShouldTakeACard()
        {
            var currentScore = _gameContext.Dealer.TotalScore;
            _gameContext.BlackJackGame.DealerMove();

            Assert.Less(currentScore,_gameContext.Dealer.TotalScore);
        }
    }
}
