using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Level : MonoBehaviour
{
    [SerializeField] private int _currentLevel;
    [SerializeField] private string _levelIdentifier;
    [SerializeField] private LevelBoardCreate _levelBoardCreate;
    [SerializeField] private CardCreator _cardCreator;
    [SerializeField] private Mission _mission;
    [SerializeField] private List<Levels> _levels;
    [SerializeField] private GameOverScreen _gameOverScreen;

    private void Start()
    {
        _currentLevel = 1;
        _cardCreator.gameObject.SetActive(true);
        StartLevel(_currentLevel);
    }

    public void StartLevel(int level)
    {
        
        _levelBoardCreate.CreateLevel(level);
        _levelIdentifier = _levelBoardCreate.RandomLevelIdentifier();
        _cardCreator.CreateCurrentCardList(_levelIdentifier);
        _cardCreator.FillEmptyCard();
        _mission.SelectMission();
    }

    public void ChangeLevel()
    {
        if (_currentLevel < _levels.Count)
        {
            _mission.AddMissionToList();
            _currentLevel++;
            StartLevel(_currentLevel);
        }
        else
        {
            GameOver();
        }
    }


    public void GameOver()
    {
        _cardCreator.DeactivateColliders();
        _gameOverScreen.ActivateRestartButton();
    }


}
