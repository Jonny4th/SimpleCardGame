using UnityEngine;

namespace Cards
{
    public class SimpleCard : MonoBehaviour
    {
        public SimpleCardFace Face { get; set; }

        public SimpleCard(SimpleCardFace face)
        {
            Face = face;
        }
    }
}