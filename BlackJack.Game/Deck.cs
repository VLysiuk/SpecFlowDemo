using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpecFlowDemo
{
    public class Deck
    {
        private readonly List<Card> _cards;

        public Deck(IDeckFiller deckFiller)
        {
            _cards = deckFiller.Fill();
        }

        public Card DrawCard()
        {
            //TODO:add some custom shuffle strategy
            //TODO:remember which cards were drawn

            return _cards.Count > 0 ? _cards[GetRandomDeckIndex()] : null;
        }

        private int GetRandomDeckIndex()
        {
            var random = new Random();
            return random.Next(_cards.Count - 1);
        }
    }
}
