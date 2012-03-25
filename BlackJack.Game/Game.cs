using System;

namespace SpecFlowDemo
{
    public class Game
    {
        private readonly Player _player;
        private readonly Dealer _dealer;
        private readonly Deck _deck;

        public Game(Player player, Dealer dealer, Deck deck)
        {
            _player = player;
            _dealer = dealer;
            _deck = deck;
        }

        public bool PlayerHasFinished { get; set; }

        public bool IsStarted { get; set; }

        public string GameMessage { get; set; }

        public void Start()
        {
            _player.TakeCard(_deck.DrawCard());
            _player.TakeCard(_deck.DrawCard());

            _dealer.TakeCard(_deck.DrawCard());
            _dealer.TakeCard(_deck.DrawCard());

            IsStarted = true;
        }

        public void PlayerMove()
        {
            _player.TakeCard(_deck.DrawCard());
        }

        public void DealerMove()
        {
            if(PlayerHasFinished)
            {
                while(_dealer.CanTakeAnotherCard)
                {
                    _dealer.TakeCard(_deck.DrawCard());
                }
            }
            else
                _dealer.TakeCard(_deck.DrawCard());
        }

        public void Check()
        {
            if (_player.IsBusted)
            {
                GameMessage = "You busted";
                return;
            }

            if(_dealer.IsBusted)
            {
                GameMessage = "You win";
                return;
            }

            if (_player.HasBlackJack && !_dealer.HasBlackJack)
                GameMessage = "Black Jack! You win";
            else if (_player.TotalScore > _dealer.TotalScore)
                GameMessage = "You win";

            if (_player.TotalScore < _dealer.TotalScore)
                GameMessage = "You lose";
            else if (_player.TotalScore == _dealer.TotalScore)
                GameMessage = "Draw";
        }

    }
}