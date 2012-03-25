using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpecFlowDemo
{
    public class Player
    {
        protected readonly Hand MyHand;

        public Player()
        {
            MyHand = new Hand();
        }

        public int CardsInHand
        {
            get { return MyHand.CardsCount; }
        }

        public bool HasBlackJack    
        {
            get { return MyHand.TotalScore == Hand.BlackJackScore; }
        }

        public int TotalScore
        {
            get { return MyHand.TotalScore; }
        }

        public bool IsBusted    
        {
            get { return MyHand.TotalScore > Hand.BlackJackScore; }
        }

        public virtual void TakeCard(Card card)
        {
           MyHand.Add(card); 
        }
    }
}
