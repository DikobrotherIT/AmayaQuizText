using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCreator : MonoBehaviour
{
    [SerializeField] private List<Cards> _cards;
    [SerializeField] private List<Cards> _currentCards;
    [SerializeField] private List<Cards> _missionCards;


    public List<Cards> MissionCards => _missionCards;
    public void FillEmptyCard()
    {
        _missionCards.Clear();
        GameObject[] emptyCard = GameObject.FindGameObjectsWithTag("Card");
        foreach (var eCard in emptyCard)
        {
            SpriteRenderer emptySprite = eCard.GetComponent<SpriteRenderer>();
            Card card = eCard.GetComponent<Card>();

            if(emptySprite.sprite == null)
            {
                Cards cards = _currentCards[Random.Range(0, _currentCards.Count - 1)];
                _missionCards.Add(cards);
                card.SetLabelForCard(cards.CardLabel);
                emptySprite.sprite = cards.CardImage;
                _currentCards.Remove(cards);
            }
        }
    }

    public void CreateCurrentCardList(string cardIdentifier)
    {
        _currentCards.Clear();
        foreach (Cards card in _cards)
            {
                if (card.CardIdentifier == cardIdentifier)
                {
                    _currentCards.Add(card);
                }
            }
    }

    public void DeactivateColliders()
    {
        GameObject[] cardsForDeactivate = GameObject.FindGameObjectsWithTag("Card");
        foreach (var card in cardsForDeactivate)
        {
            card.GetComponent<Collider2D>().enabled = false;
        }
    }



    
}
