using UnityEngine;
using UnityEngine.EventSystems;

public class PointVisualisation : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 _positionBeforeDrag;

    public void OnBeginDrag(PointerEventData eventData)
    {
        _positionBeforeDrag = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        var ray = Camera.main.ScreenPointToRay(eventData.position);
        Physics.Raycast(ray, out var hitInfo, 200f, LayerMask.GetMask("Planes"));

        transform.position = hitInfo.point;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        var ray = Camera.main.ScreenPointToRay(eventData.position);
        var didHit = Physics.Raycast(ray, out var hitInfo, 200f, LayerMask.GetMask("Planes"));
        if (didHit == false)
        {
            transform.position = _positionBeforeDrag;
        }
    }
}