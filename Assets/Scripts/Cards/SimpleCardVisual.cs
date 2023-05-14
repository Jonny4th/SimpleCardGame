using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Cards
{
    public class SimpleCardVisual : MonoBehaviour
    {
        public SimpleCard Card { get; private set; }

        [SerializeField]
        TMP_Text cardFaceText;

        [SerializeField]
        Button cardButton;

        Image cardBG;

        readonly Color defaultColor = Color.white;

        public bool IsSelected { get; private set; } = false;

        readonly string cardFaceFormat = "{0}\nof\n{1}";

        public event Action<SimpleCardVisual> CardSelected;

        void OnEnable()
        {
            cardButton.onClick.AddListener(OnCardClick);
            cardBG = GetComponent<Image>();
        }

        void OnDisable()
        {
            cardButton.onClick.RemoveListener(OnCardClick);
        }

        private void OnCardClick()
        {
            IsSelected = !IsSelected;
            OnSelected();
            CardSelected?.Invoke(this);
        }

        public void Assign(SimpleCard card)
        {
            Card = card;
            Display();
        }

        public void Display()
        {
            cardFaceText.text = string.Format(cardFaceFormat, Card.Rank.Name, Card.Suit.Name);
            gameObject.SetActive(true);
            Debug.Log(Card);
        }

        public void Discard()
        {
            IsSelected = false;
            OnSelected();
            Card = null;
            cardFaceText.text = "";
            gameObject.SetActive(false);
        }

        public void OnSelected()
        {
            if (IsSelected)
            {
                cardBG.color = Color.yellow;
            }
            else
            {
                cardBG.color = defaultColor;
            }
        }
    }
}