using CardFace;
using Newtonsoft.Json;
using UnityEngine;

namespace Cards
{
    [JsonObject(MemberSerialization.OptIn)]
    public class SimpleCard
    {
        [JsonProperty]
        public Rank Rank { get; private set; }

        [JsonProperty]
        public Suit Suit { get; private set; }

        public SimpleCard(Suit suit, Rank rank)
        {
            Suit = suit;
            Rank = rank;
        }
    }
}


