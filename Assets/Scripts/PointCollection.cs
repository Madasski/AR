using System.Collections.Generic;
using UnityEngine;

public class PointCollection : MonoBehaviour
{
    private PointFactory _pointFactory;
    private LineRenderer _lineRenderer;
    private List<PointVisualisation> _points;

    public bool IsDone { get; private set; }

    private void Awake()
    {
        _pointFactory = CompositionRoot.PointFactory;

        _points = new List<PointVisualisation>();
        _lineRenderer = GetComponent<LineRenderer>();
    }

    public void AddPoint(Vector3 position)
    {
        var point = _pointFactory.CreatePoint(position);
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