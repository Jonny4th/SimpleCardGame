using CardFace;
using Cards;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Decks
{
    public class SimpleDeck : MonoBehaviour
    {
        [SerializeField]
        FaceComponentLists m_Suits;

        [SerializeField]
        FaceComponentLists m_Ranks;

        List<SimpleCard> m_Cards;

        void Start()
        {
            CreateDeck();
        }

        public void CreateDeck()
        {
            m_Cards = (from Suit suit in m_Suits.items
                       from Rank rank in m_Ranks.items
                       select new SimpleCard(new SimpleCardFace(suit, rank))).ToList();

            Shuffle();
        }

        public void Shuffle()
        {
            var r = new System.Random((int)DateTime.Now.Ticks);
            var shuffledList = m_Cards.Select(x => new { Number = r.Next(), Item = x }).OrderBy(x => x.Number).Select(x => x.Item).ToList();
            m_Cards = shuffledList;
        }
    }
}
