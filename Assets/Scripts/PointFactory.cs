using System;
using UnityEngine;

public class PointFactory : MonoBehaviour
{
    public event Action<PointVisualisation> PointCreated;

    [SerializeField] private PointVisualisation _pointPrefab;

    public PointVisualisation CreatePoint(Vector3 position)
    {
        var point = Instantiate(_pointPrefab, position, Quaternion.identity);
        PointCreated?.Invoke(point);
        return point;
    }
}