using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tooltip : IDisposable
{
    public event Action<TooltipDescription> OnDisplay;
    public event Action OnHide;

    private readonly List<EventTriggerListener> _triggerListeners;

    public Tooltip(TooltipDescription[] tooltipDescriptions)
    {
        _triggerListeners = new List<EventTriggerListener>();

        foreach (TooltipDescription tooltipDescription in tooltipDescriptions)
        {
            var triggerListener = new EventTriggerListener(tooltipDescription);
            triggerListener.OnPointerEnter += Display;
            triggerListener.OnPointerExit += Hide;
            _triggerListeners.Add(triggerListener);
        }
    }

    public void Dispose()
    {
        foreach (var tooltipTrigger in _triggerListeners)
        {
            tooltipTrigger.OnPointerEnter -= Display;
            tooltipTrigger.OnPointerExit -= Hide;
            tooltipTrigger.Dispose();
        }
    }

    private void Display(TooltipDescription tooltipDescription) =>
        OnDisplay?.Invoke(tooltipDescription);

    private void Hide() =>
        OnHide?.Invoke();

    private class EventTriggerListener : IDisposable
    {
        public event Action<TooltipDescription> OnPointerEnter;
        public event Action OnPointerExit;

        EventTrigger.Entry _pointerEnterTrigger = new EventTrigger.Entry();
        EventTrigger.Entry _pointerExitTrigger = new EventTrigger.Entry();

        private EventTrigger _eventTrigger;
        private TooltipDescription _tooltipDescription;

        public EventTriggerListener(TooltipDescription tooltipDescription)
        {
            _tooltipDescription = tooltipDescription;
            _eventTrigger = tooltipDescription.gameObject.AddComponent<EventTrigger>();

            AddEventTriggerListener(_eventTrigger, EventTriggerType.PointerEnter, PointerEnter);
            AddEventTriggerListener(_eventTrigger, EventTriggerType.PointerExit, PointerExit);
        }

        private void AddEventTriggerListener(EventTrigger eventTrigger, EventTriggerType eventType, Action<BaseEventData> callback)
        {
            EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = eventType;
            entry.callback = new EventTrigger.TriggerEvent();
            entry.callback.AddListener(new UnityEngine.Events.UnityAction<BaseEventData>(callback));
            eventTrigger.triggers.Add(entry);
        }

        public void Dispose()
        {
            _pointerEnterTrigger.callback.RemoveListener(PointerEnter);
            _pointerExitTrigger.callback.RemoveListener(PointerExit);
        }

        private void PointerEnter(BaseEventData eventData) =>
            OnPointerEnter?.Invoke(_tooltipDescription);

        private void PointerExit(BaseEventData eventData) =>
            OnPointerExit?.Invoke();
    }
}

