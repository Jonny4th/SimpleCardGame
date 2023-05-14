using Cards;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Decks
{
    public abstract class BaseDeck : MonoBehaviour
    {
        protected List<SimpleCard> m_Cards = new();

        public List<SimpleCard> Cards
        {
            get => m_Cards;
        }

        public event Action CardAmountUpdated;

        protected virtual void OnCardAmountUpdated()
        {
            CardAmountUpdated?.Invoke();
        }

        public abstract void CreateDeck();

        public void Shuffle()
        {
            var r = new System.Random((int)DateTime.Now.Ticks);
            var shuffledList = m_Cards.Select(x => new { Number = r.Next(), Item = x }).OrderBy(x => x.Number).Select(x => x.Item).ToList();
            m_Cards = shuffledList;
        }

        public SimpleCard GetSingleCard()
        {
            var card = m_Cards[0];
            m_Cards.Remove(card);
            CardAmountUpdated?.Invoke();
            return card;
        }

        public SimpleCard GetCardAtIndex(int index)
        {
            if(index >= m_Cards.Count)
            {
                Debug.Log("No card.");
                return null;
            }

            var card = m_Cards[index];
            m_Cards.Remove(card);
            CardAmountUpdated?.Invoke();
            return card;
        }
    }
}