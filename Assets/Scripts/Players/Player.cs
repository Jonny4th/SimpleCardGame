using Cards;
using Decks;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Players
{
    public class Player : MonoBehaviour
    {
        BaseDeck m_drawDeck;

        List<SimpleCard> m_hand = new();

        public int CardAmount => m_hand.Count;

        int handLimit = 5;


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

        public bool CheckDrawable()
        {
            if(handLimit < 0) return true;

            if(CardAmount >= handLimit) return false;

            return true;
        }
    }
}