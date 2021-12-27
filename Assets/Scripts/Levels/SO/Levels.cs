using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Level", menuName = "Create Level/New Level", order = 51)]
public class Levels : ScriptableObject
{
    [SerializeField] private int _levelNumber;
    [SerializeField] private int _coloumns;
    [SerializeField] private int _rows;

    public int Rows => _rows;
    public int Columns => _coloumns;
    public int LevelNumber => _levelNumber;
}
