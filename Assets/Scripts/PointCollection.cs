using System.Collections.Generic;
using UnityEngine;

public class PointCollection : MonoBehaviour
{
    [SerializeField] private Transform _pointPrefab;

    private List<Transform> _points;
    private LineRenderer _lineRenderer;

    private void Awake()
    {
        _points = new List<Transform>();
        _lineRenderer = GetComponent<LineRenderer>();
    }

    public void AddPoint(Vector3 position)
    {
        var point = Instantiate(_pointPrefab, position, Quaternion.identity);
        point.parent = transform;
        _points.Add(point.transform);

        _lineRenderer.positionCount++;
        _lineRenderer.SetPosition(_points.Count - 1, point.transform.position);
    }

    public void Finish()
    {
        _lineRenderer.loop = true;
    }
}