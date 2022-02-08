using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickablePlane : MonoBehaviour, IPointerClickHandler
{
    public event Action<Vector3> Clicked;

    public void OnPointerClick(PointerEventData eventData)
    {
        var ray = Camera.main.ScreenPointToRay(eventData.position);
        bool didHit = Physics.Raycast(ray, out var hitInfo);
        if (didHit == false) return;

        Clicked?.Invoke(hitInfo.point);
    }
}