using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpecFlowDemo
{
    public class Dealer:Player
    {
        private const int ScoreLimit = 17;

        public bool CanTakeAnotherCard
        {
            get { return TotalScore < ScoreLimit; }
        }

        public override void TakeCard(Card card)
        {
            if(CanTakeAnotherCard)
                MyHand.Add(card);
        }
    }
}
