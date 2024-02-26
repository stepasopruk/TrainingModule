using System;
using UnityEngine;
using UnityEngine.EventSystems;

public interface IPointerClickTrigger
{
    public event Action<GameObject> OnPointerClick;
    void PointerClick(BaseEventData eventData);
}