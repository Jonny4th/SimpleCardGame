using System.Collections.Generic;
using UnityEngine;

namespace CardFace
{
    [CreateAssetMenu(fileName ="NewFaceComponentList", menuName = "Face Component List")]
    public class FaceComponentLists : ScriptableObject
    {
        public List<FaceComponent> items;
    }
}
