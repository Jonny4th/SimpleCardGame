using CardFace;
using Cards;
using Helper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Unity.Mathematics;
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

        public List<SimpleCard> Cards 
        { 
            get => m_Cards;
        }

        public void CreateDeck()
        {
            m_Cards = (from Suit suit in m_Suits.items
                       from Rank rank in m_Ranks.items
                       select new SimpleCard(suit, rank)).ToList();

            Shuffle();
            SaveDeckToJson();

            Debug.Log(m_Cards[0].Rank.Name);
            Debug.Log(m_Cards[0].Suit.Name);
        }

        #region BEHAVIORS
        public void Shuffle()
        {
            var r = new System.Random((int)DateTime.Now.Ticks);
            var shuffledList = m_Cards.Select(x => new { Number = r.Next(), Item = x }).OrderBy(x => x.Number).Select(x => x.Item).ToList();
            m_Cards = shuffledList;
        }

        #endregion

        #region DATA RELATED
        public void SaveDeckToJson()
        {
            var helper = new JsonFileHelper();
            helper.SaveToJson(this);
        }

        /// <summary>
        /// file name includes .json 
        /// </summary>
        /// <param name="fileName"></param>
        public void LoadDeckFromJson(string fileName)
        {
            var helper = new JsonFileHelper();
            m_Cards = helper.LoadDeckFromJson(fileName);
            Debug.Log(m_Cards[0].Rank.Name);
            Debug.Log(m_Cards[0].Suit.Name);
        }
        #endregion
    }
}
