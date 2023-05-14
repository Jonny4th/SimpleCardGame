using Cards;
using Decks;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Players
{
    public class Player : MonoBehaviour
    {
        public List<SimpleCard> Hand => m_hand;
        public int CardAmount => m_hand.Count;

        int handLimit = 5;
        BaseDeck m_drawDeck;
        List<SimpleCard> m_hand = new();

        List<SimpleCard> m_Selected = new();

        public event Action<SimpleCard> CardAdded;
        public event Action<SimpleCard> CardRemoved;

        public void SetPlayDeck(BaseDeck deck)
        {
            m_drawDeck = deck;
        }

        public void DrawSingleCard()
        {
            if(!CheckDrawable())
            {
                Debug.Log("Hand Full.");
                return;
            }

            m_hand.Add(m_drawDeck.GetSingleCard());
            CardAdded?.Invoke(m_hand.Last());

            Debug.Log(m_hand.Last().Rank.Name);
            Debug.Log(m_hand.Last().Suit.Name);
        }

        public void DrawFullHand()
        {
            if(handLimit < 0) return;

            while(CheckDrawable())
            {
                DrawSingleCard();
            }
        }

        private void Discard(SimpleCard card)
        {
            CardRemoved?.Invoke(card);
            m_hand.Remove(card);
        }

        public void DiscardSelected()
        {
            foreach(SimpleCard card in m_Selected)
            {
                Discard(card);
            }

            m_Selected.Clear();
        }

        public bool CheckDrawable()
        {
            if(handLimit < 0) return true;

            if(CardAmount >= handLimit) return false;

            return true;
        }

        public void CardSelect(SimpleCardVisual card)
        {
            m_Selected ??= new();

            if(card.IsSelected)
            {
                m_Selected.Add(card.Card);
            }
            else
            {
                m_Selected.Remove(card.Card);
            }
        }
    }
}