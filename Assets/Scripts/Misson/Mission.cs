using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Mission : MonoBehaviour
{
    [SerializeField] private CardCreator _cardCreator;
    [SerializeField] private MissionDisplay _missionDisplay;
    [SerializeField] private Level _level;
    [SerializeField] private string _missionLabel;
    [SerializeField] private string _lastMissionLabel;
    [SerializeField] private string _missionIdentifier;
    [SerializeField] private List<string> _lastMissions;

    [SerializeField] private Animations _animations;



    public void SelectMission()
    {
        Cards missionCard = _cardCreator.MissionCards[Random.Range(0, _cardCreator.MissionCards.Count - 1)];
        if (CompareLastMissionLabel(missionCard.CardLabel))
        {
            _missionLabel = missionCard.CardLabel;
            _missionIdentifier = missionCard.CardIdentifier;
            _missionDisplay.ChangeMission(_missionIdentifier, _missionLabel);
        }
    }

    public void CompareCardWithMission(GameObject compareCard)
    {
        if (compareCard.GetComponent<Card>().CurrentCardLabel == _missionLabel)
        {

            StartCoroutine(ClickOnCorrectCard(compareCard));
            
        }

        else
        {
            _animations.ChooseFalseCard(compareCard.transform);
        }
    }

    public void AddMissionToList()
    {
        _lastMissionLabel = _missionLabel;
        _lastMissions.Add(_lastMissionLabel);
    }

    public bool CompareLastMissionLabel(string cardLabel)
    {
        foreach (var label in _lastMissionLabel)
        {
            if (cardLabel == label.ToString())
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator ClickOnCorrectCard(GameObject compareCard)
    {
        _animations.ChooseCorrectCard(compareCard.transform);

        yield return new WaitForSeconds(1f);
        _level.ChangeLevel();
    }
}
