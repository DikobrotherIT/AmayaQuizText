using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] private string _currentCardLabel;

    public string CurrentCardLabel => _currentCardLabel;

    public void SetLabelForCard(string cardLabel)
    {
        _currentCardLabel = cardLabel;
    }


}
