using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipEventTrigger : EventTriggerBase, IPointerEnterTrigger, IPointerExitTrigger
{
    public event Action<GameObject> OnPointerEnter;
    public event Action OnPointerExit;

    public TooltipEventTrigger(GameObject gameObject) : base(gameObject)
    {
        AddListenerEventTrigger(EventTriggerType.PointerEnter, PointerEnter);
        AddListenerEventTrigger(EventTriggerType.PointerExit, PointerExit);
    }

    public void PointerEnter(BaseEventData eventData) =>
        OnPointerEnter?.Invoke(_eventTrigger.gameObject);

    public void PointerExit(BaseEventData eventData) =>
        OnPointerExit?.Invoke();
}