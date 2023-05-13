using CardFace;
using Cards;
using Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Decks
{
    public class SimpleDeck : BaseDeck
    {
        [SerializeField]
        FaceComponentLists m_Suits;

        [SerializeField]
        FaceComponentLists m_Ranks;

        public override void CreateDeck()
        {
            m_Cards = (from Suit suit in m_Suits.items
                       from Rank rank in m_Ranks.items
                       select new SimpleCard(suit, rank)).ToList();

            Shuffle();
            OnCardAmountUpdated();
            new JsonFileHelper().SaveToJson(this);

            Debug.Log(m_Cards[0].Rank.Name);
            Debug.Log(m_Cards[0].Suit.Name);
        }

        #region DATA RELATED
        /// <summary>
        /// file name includes .json 
        /// </summary>
        /// <param name="fileName"></param>
        public void LoadDeckFromJson(string fileName)
        {
            var helper = new JsonFileHelper();
            m_Cards = helper.LoadDeckFromJson(fileName);
            OnCardAmountUpdated();
            Debug.Log(m_Cards[0].Rank.Name);
            Debug.Log(m_Cards[0].Suit.Name);
        }
        #endregion
    }
}
