using System.Collections.Generic;
using UnityEngine;

public class PointCollection : MonoBehaviour
{
    [SerializeField] private PointVisualisation _pointPrefab;

    private LineRenderer _lineRenderer;
    private List<PointVisualisation> _points;

    public bool IsDone { get; private set; }

    private void Awake()
    {
        _points = new List<PointVisualisation>();
        _lineRenderer = GetComponent<LineRenderer>();
    }

    public void AddPoint(Vector3 position)
    {
        var point = Instantiate(_pointPrefab, position, Quaternion.identity);
        point.transform.parent = transform;
        point.MovedCorrectly += RecalculateLineForPoint;
        _points.Add(point);

        _lineRenderer.positionCount++;
        _lineRenderer.SetPosition(_points.Count - 1, point.transform.position);
    }

    public void Finish()
    {
        _lineRenderer.loop = true;
        IsDone = true;
    }

    private void RecalculateLineForPoint(PointVisualisation pointVisualisation)
    {
        _lineRenderer.SetPosition(_points.IndexOf(pointVisualisation), pointVisualisation.transform.position);
    }
}