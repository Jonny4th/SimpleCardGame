using Cards;
using System.Collections.Generic;
using UnityEngine;

namespace Players
{
    public class HandVisual : MonoBehaviour
    {
        [SerializeField]
        GameObject m_HandDisplay;

        [SerializeField]
        Player m_player;

        List<SimpleCardVisual> cards = new List<SimpleCardVisual>();

        void OnEnable()
        {
            m_player.CardAdded += OnPlayerHandAdded;
            m_player.CardRemoved += OnPlayerHandRemoved;
            m_HandDisplay.GetComponentsInChildren(true, cards);

            foreach(var card in cards)
            {
                card.CardSelected += m_player.CardSelect;
            }
        }

        void OnDisable()
        {
            m_player.CardAdded -= OnPlayerHandAdded;
            m_player.CardRemoved -= OnPlayerHandRemoved;

            foreach(var card in cards)
            {
                card.CardSelected -= m_player.CardSelect;
            }
        }

        void OnPlayerHandAdded(SimpleCard card)
        {
            cards.Find(x => x.Card == null).Assign(card);
        }

        void OnPlayerHandRemoved(SimpleCard card)
        {
            cards.Find(x => x.Card == card).Discard();
        }
    }
}