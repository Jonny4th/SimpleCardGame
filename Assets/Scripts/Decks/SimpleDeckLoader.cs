using System.Collections;
using UnityEngine;

namespace Decks
{
    public class SimpleDeckLoader : MonoBehaviour
    {
        [SerializeField]
        string fileName;

        [SerializeField]
        SimpleDeck deck;

        public void Load()
        {
            deck.LoadDeckFromJson(fileName);
        }
    }
}