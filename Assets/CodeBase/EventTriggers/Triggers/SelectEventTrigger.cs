using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectEventTrigger : EventTriggerBase, IPointerClickTrigger
{
    public event Action<GameObject> OnPointerClick;

    public SelectEventTrigger(GameObject gameObject) : base(gameObject)
    {
        AddListenerEventTrigger(EventTriggerType.PointerClick, PointerClick);
    }

    public void PointerClick(BaseEventData eventData) => 
        OnPointerClick?.Invoke(_eventTrigger.gameObject);
}
