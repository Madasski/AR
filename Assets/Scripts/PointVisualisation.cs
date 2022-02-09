using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class PointVisualisation : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public event Action<PointVisualisation> MovedCorrectly;
    public event Action FailedToMove;

    private PointManager _pointManager;
    private Vector3 _positionBeforeDrag;

    private void Start()
    {
        _pointManager = PointManager.Instance;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (_pointManager.CurrentState != EAppState.MovingPoints) return;

        _positionBeforeDrag = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (_pointManager.CurrentState != EAppState.MovingPoints) return;

        var ray = Camera.main.ScreenPointToRay(eventData.position);
        Physics.Raycast(ray, out var hitInfo, 200f, LayerMask.GetMask("Planes"));

        transform.position = hitInfo.point;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (_pointManager.CurrentState != EAppState.MovingPoints) return;
        
        var ray = Camera.main.ScreenPointToRay(eventData.position);
        var didHit = Physics.Raycast(ray, out var hitInfo, 200f, LayerMask.GetMask("Planes"));
        if (didHit == false)
        {
            transform.position = _positionBeforeDrag;
            FailedToMove?.Invoke();
            Debug.Log("New point position is incorrect");
        }
        else
        {
            MovedCorrectly?.Invoke(this);
        }
    }
}