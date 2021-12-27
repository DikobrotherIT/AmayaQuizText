using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Create Card/New Card", order = 51)]
public class Cards : ScriptableObject
{
    [SerializeField] private string _cardIdentifier;
    [SerializeField] private string _cardLabel;
    [SerializeField] private Sprite _cardImage;


    public string CardIdentifier => _cardIdentifier;
    public string CardLabel => _cardLabel;
    public Sprite CardImage => _cardImage;

}
