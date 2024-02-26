using System;
using UnityEngine;
using UnityEngine.EventSystems;

public interface IPointerEnterTrigger
{
    public event Action<GameObject> OnPointerEnter;
    void PointerEnter(BaseEventData eventData);
}
