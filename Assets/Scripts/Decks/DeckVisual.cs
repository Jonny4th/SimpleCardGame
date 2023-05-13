using Decks;
using TMPro;
using UnityEngine;

public class DeckVisual : MonoBehaviour
{
    [SerializeField]
    BaseDeck deck;

    [SerializeField]
    TMP_Text CardAmountText;

    void OnEnable()
    {
        deck.CardAmountUpdated += OnDeckUpdate;
    }

    void OnDisable()
    {
        deck.CardAmountUpdated -= OnDeckUpdate;
    }

    public void OnDeckUpdate()
    {
        CardAmountText.text = deck.Cards.Count.ToString();
    }
}
