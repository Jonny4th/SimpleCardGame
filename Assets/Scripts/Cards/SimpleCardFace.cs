using CardFace;
using Newtonsoft.Json;
using UnityEngine;

namespace Cards
{
    public class SimpleCardFace : MonoBehaviour
    {
        public Suit Suit { get; set; }

        public Rank Rank { get; set; }

        public SimpleCardFace(Suit suit, Rank rank)
        {
            Suit = suit;
            Rank = rank;
        }
    }
}


