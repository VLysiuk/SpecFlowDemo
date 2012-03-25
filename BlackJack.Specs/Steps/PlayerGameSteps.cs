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
    public class PlayerGameSteps
    {
        private readonly GameContext _gameContext;

        public PlayerGameSteps(GameContext gameContext)
        {
            _gameContext = gameContext;
        }

        [Given(@"I have no cards in hand")]
        public void GivenIHaveNoCardsInHand()
        {
            Assert.AreEqual(0, _gameContext.Player.CardsInHand);
        }

        [When(@"I have got Black Jack")]
        public void WhenIHaveGotBlackJack()
        {
           _gameContext.Player.TakeCard(new Card(CardRank.Ten,CardSuit.Diamond));
           _gameContext.Player.TakeCard(new Card(CardRank.Ace, CardSuit.Spade));
            Assert.IsTrue(_gameContext.Player.HasBlackJack);
        }

        [When(@"Diller havent got Black Jack")]
        public void WhenDillerHaventGotBlackJack()
        {
            _gameContext.Dealer.TakeCard(new Card(CardRank.Two,CardSuit.Club));
            _gameContext.Dealer.TakeCard(new Card(CardRank.Three, CardSuit.Club));
            Assert.IsFalse(_gameContext.Dealer.HasBlackJack);
        }

        [Then(@"I should see a message ""(.*)""")]
        public void ThenIShouldSeeAMessage(string message)
        {
            _gameContext.BlackJackGame.Check();
            Assert.AreEqual(message, _gameContext.BlackJackGame.GameMessage);
        }


        [Given(@"I have drawn queen and six and three")]
        public void GivenIHaveDrawnQueenAndSixAndThree()
        {
            _gameContext.Player.TakeCard(new Card(CardRank.Queen, CardSuit.Diamond));
            _gameContext.Player.TakeCard(new Card(CardRank.Six, CardSuit.Spade));
            _gameContext.Player.TakeCard(new Card(CardRank.Three, CardSuit.Heart));
        }

        [Given(@"dealer has drawn ten and eight")]
        public void GivenDealerHasDrawnTenAndEight()
        {
            _gameContext.Dealer.TakeCard(new Card(CardRank.Ten, CardSuit.Spade));
            _gameContext.Dealer.TakeCard(new Card(CardRank.Eight, CardSuit.Spade));
        }

        [When(@"I have more scores than dealer")]
        public void WhenIHaveMoreScoresThanDealer()
        {
            Assert.IsTrue(_gameContext.Player.TotalScore > _gameContext.Dealer.TotalScore);
        }

        [Given(@"dealer has drawn ten and jack")]
        public void GivenDealerHasDrawnTenAndJack()
        {
            _gameContext.Dealer.TakeCard(new Card(CardRank.Ten, CardSuit.Spade));
            _gameContext.Dealer.TakeCard(new Card(CardRank.Jack, CardSuit.Diamond));
        }

        [When(@"I have less scores than dealer")]
        public void WhenIHaveLessScoresThanDealer()
        {
            Assert.IsTrue(_gameContext.Player.TotalScore < _gameContext.Dealer.TotalScore);
        }

        [Given(@"dealer has drawn ten and nine")]
        public void GivenDealerHasDrawnTenAndNine()
        {
            _gameContext.Dealer.TakeCard(new Card(CardRank.Ten, CardSuit.Club));
            _gameContext.Dealer.TakeCard(new Card(CardRank.Nine, CardSuit.Heart));
        }

        [When(@"I have equal scores with dealer")]
        public void WhenIHaveEqualScoresWithDealer()
        {
            Assert.AreEqual(_gameContext.Player.TotalScore,_gameContext.Dealer.TotalScore);
        }

        [Given(@"I have drawn queen and king and three")]
        public void GivenIHaveDrawnQueenAndKingAndThree()
        {
            _gameContext.Player.TakeCard(new Card(CardRank.Queen, CardSuit.Diamond));
            _gameContext.Player.TakeCard(new Card(CardRank.King, CardSuit.Spade));
            _gameContext.Player.TakeCard(new Card(CardRank.Three, CardSuit.Heart));
        }

        [When(@"I have busted")]
        public void WhenIHaveBusted()
        {
            Assert.IsTrue(_gameContext.Player.IsBusted);
        }

        [Given(@"dealer has drawn queen and king and three")]
        public void GivenDealerHasDrawnQueenAndKingAndThree()
        {
            _gameContext.Dealer.TakeCard(new Card(CardRank.Queen, CardSuit.Diamond));
            _gameContext.Dealer.TakeCard(new Card(CardRank.Three, CardSuit.Heart));
            _gameContext.Dealer.TakeCard(new Card(CardRank.King, CardSuit.Spade));
        }

        [When(@"dealer has busted")]
        public void WhenDealerHasBusted()
        {
            Assert.IsTrue(_gameContext.Dealer.IsBusted);
        }

        [Given(@"I have two cards in hand")]
        public void GivenIHaveTwoCardsInHand()
        {
            _gameContext.Player.TakeCard(new Card(CardRank.Three, CardSuit.Diamond));
            _gameContext.Player.TakeCard(new Card(CardRank.Six, CardSuit.Spade));

            Assert.AreEqual(2,_gameContext.Player.CardsInHand);
        }

        [When(@"I take one more")]
        public void WhenITakeOneMore()
        {
            _gameContext.BlackJackGame.PlayerMove();
        }

        [Then(@"my total score is incresed")]
        public void ThenMyTotalScoreIsIncresed()
        {
            Assert.IsTrue(_gameContext.Player.TotalScore > 9);
        }
    }
}
