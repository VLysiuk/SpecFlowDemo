using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpecFlowDemo
{
    public class SimpleDeckFiller:IDeckFiller
    {
        public List<Card> Fill()
        {
            var ranks = Enum.GetValues(typeof (CardRank)).Cast<CardRank>();
            var suits = Enum.GetValues(typeof (CardSuit)).Cast<CardSuit>();

            return ranks.SelectMany(r => suits, (r, s) => new Card(r, s)).ToList();
        }
    }
}
