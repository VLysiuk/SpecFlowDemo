using NUnit.Framework;
using SpecFlowDemo;
using TechTalk.SpecFlow;

namespace BlackJack.Specs.Steps
{
    public class GameContext
    {
        public GameContext()
        {
            Player = new Player();
            Dealer= new Dealer();
            Deck = new Deck(new SimpleDeckFiller());
            BlackJackGame = new Game(Player, Dealer, Deck);
        }

        public Game BlackJackGame { get; set; }
        public Player Player { get; set; }
        public Dealer Dealer { get; set; }
        public Deck Deck { get; set; }
    }

    [Binding]
    public class StartGameSteps
    {
        private readonly GameContext _gameContext;

        public StartGameSteps(GameContext gameContext)
        {
            _gameContext = gameContext;
        }

        [Given(@"Game is not started yet")]
        public void GivenGameIsNotStartedYet()
        {
            Assert.IsFalse(_gameContext.BlackJackGame.IsStarted);
        }

        [When(@"I start the game")]
        public void WhenIStartTheGame()
        {
            _gameContext.BlackJackGame.Start();
        }

        [Then(@"I have 2 cards in my hand")]
        public void ThenIHave2CardsInMyHand()
        {
            Assert.AreEqual(2, _gameContext.Player.CardsInHand);
        }

        [Then(@"Dealer has 2 cards in his hand")]
        public void ThenDealerHas2CardsInHisHand()
        {
            Assert.AreEqual(2, _gameContext.Dealer.CardsInHand);
        }

    }
}
