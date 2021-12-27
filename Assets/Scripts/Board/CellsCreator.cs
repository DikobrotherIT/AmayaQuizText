using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CellsCreator : MonoBehaviour
{
    [SerializeField] private GameObject _cellPrefab;
    [SerializeField] private float _xSpace, _ySpace;
    [SerializeField] private float _xStart, _yStart;
    [SerializeField] private List<GameObject> _createdCells;
    [SerializeField] private Animations _animations;
    

    public void CreateBoard(int rows, int columns, int levelNumber)
    {
        CleanBoard();
        for (int i = 0; i < columns * rows; i++)
        {
            GameObject newCell = Instantiate(_cellPrefab, new Vector3(_xStart + (_xSpace * (i % columns)), _yStart + (-_ySpace*( i / columns))), Quaternion.identity);
            if(levelNumber == 1)
            {
                _animations.BounceEffect(newCell.transform);
            }
            _createdCells.Add(newCell);
            newCell.transform.parent = transform;
            
        }
    }

    public void CleanBoard()
    {
        
        foreach (GameObject cell in _createdCells)
        {
            Destroy(cell);
        }
        _createdCells.Clear();
    }
}
