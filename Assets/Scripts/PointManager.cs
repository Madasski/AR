using System.Collections.Generic;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    [SerializeField] private List<ClickablePlane> _clickablePlanes;
    [SerializeField] private PointCollection _pointCollectionPrefab;

    private bool _isDrawing;
    private PointCollection _currentPointCollection;

    private void Awake()
    {
        foreach (var clickablePlane in _clickablePlanes)
        {
            clickablePlane.Clicked += AddPointToCurrentPointCollection;
        }
    }

    public void ToggleDrawing()
    {
        _isDrawing = !_isDrawing;

        if (_isDrawing)
        {
            CreatePointCollection();
        }
        else
        {
            _currentPointCollection.Finish();
        }
    }

    private void CreatePointCollection()
    {
        _currentPointCollection = Instantiate(_pointCollectionPrefab, transform);
    }

    private void AddPointToCurrentPointCollection(Vector3 position)
    {
        if (_isDrawing == false) return;

        _currentPointCollection.AddPoint(position);
    }
}