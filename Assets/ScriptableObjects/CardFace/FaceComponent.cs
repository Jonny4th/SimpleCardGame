using Newtonsoft.Json;
using UnityEngine;

namespace CardFace
{
    [CreateAssetMenu(fileName = "NewFaceComponent", menuName = "Face Component")]
    [JsonObject(MemberSerialization.OptIn)]
    public class FaceComponent : ScriptableObject
    {
        [JsonProperty]
        public string Name;
    }
}
