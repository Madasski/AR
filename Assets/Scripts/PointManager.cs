using System.Collections.Generic;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    public static PointManager Instance;

    [SerializeField] private List<ClickablePlane> _clickablePlanes;
    [SerializeField] private PointCollection _pointCollectionPrefab;

    private PointCollection _currentPointCollection;

    public EAppState CurrentState { get; private set; }

    private void Awake()
    {
        Instance = this;

        CurrentState = EAppState.MovingPoints;

        foreach (var clickablePlane in _clickablePlanes)
        {
            clickablePlane.Clicked += AddPointToCurrentPointCollection;
        }
    }

    public void ToggleState()
    {
        switch (CurrentState)
        {
            case EAppState.AddingPoints:
                CurrentState = EAppState.MovingPoints;
                _currentPointCollection.Finish();
                break;
            case EAppState.MovingPoints:
                CurrentState = EAppState.AddingPoints;
                CreatePointCollection();
                break;
        }
    }

    private void CreatePointCollection()
    {
        _currentPointCollection = Instantiate(_pointCollectionPrefab, transform);
    }

    private void AddPointToCurrentPointCollection(Vector3 position)
    {
        if (CurrentState != EAppState.AddingPoints) return;

        _currentPointCollection.AddPoint(position);
    }
}