using Newtonsoft.Json;
using UnityEngine;

namespace CardFace
{
    [CreateAssetMenu(fileName = "NewRank", menuName = "Rank")]
    [JsonObject(MemberSerialization.OptIn)]
    public class Rank : FaceComponent
    {
        [JsonProperty]
        public int index;
    }
}
