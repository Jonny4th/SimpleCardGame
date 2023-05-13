using Newtonsoft.Json;
using UnityEngine;

namespace CardFace
{
    [CreateAssetMenu(fileName = "NewSuit", menuName = "Suit")]
    [JsonObject(MemberSerialization.OptIn)]
    public class Suit : FaceComponent
    {
        [JsonProperty]
        public int index;
    }
}
