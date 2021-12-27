using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MissionDisplay : MonoBehaviour
{
    [SerializeField] private Text _missionText;
    public UnityEvent OnTextShow;

    public void ChangeMission(string cardIdentidier, string cardLabel)
    {
        _missionText.gameObject.SetActive(true);
        OnTextShow?.Invoke();
        _missionText.text = "Find " + cardIdentidier.ToLower() + " " + cardLabel.ToString();
    }
}
