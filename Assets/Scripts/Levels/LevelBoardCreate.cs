using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBoardCreate : MonoBehaviour
{
    [SerializeField] private List<Levels> _levels;
    [SerializeField] private CellsCreator _cellsCreator;
    [SerializeField] private List<string> identifierList;

    public void CreateLevel(int levelNumber)
    {
        foreach (var level in _levels)
        {      
            if (level.LevelNumber == levelNumber)
            {
                _cellsCreator.CreateBoard(level.Rows, level.Columns, levelNumber);
            }
        }
    }

    public string RandomLevelIdentifier()
    {
        string identifier = identifierList[Random.Range(0, identifierList.Count)];
        return identifier;

    }
}
