using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;

namespace CardFace
{
    [CreateAssetMenu(fileName ="NewFaceComponentList", menuName = "Face Component List")]
    [JsonObject(MemberSerialization.OptIn)]
    public class FaceComponentLists : ScriptableObject
    {
        [JsonProperty]
        public List<FaceComponent> items;
    }
}
