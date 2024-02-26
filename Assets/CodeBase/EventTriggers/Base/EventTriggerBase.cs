using System;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.EventSystems.EventTrigger;

public abstract class EventTriggerBase : IDisposable
{
    protected EventTrigger _eventTrigger;

    public EventTriggerBase(GameObject gameObject)
    {
        _eventTrigger ??= gameObject.GetComponent<EventTrigger>();
        
        if(_eventTrigger == null)
            _eventTrigger = gameObject.AddComponent<EventTrigger>();
    }

    protected void AddListenerEventTrigger(EventTriggerType eventType, Action<BaseEventData> callback)
    {
        Entry entry = CreateEntry(eventType);
        entry.callback.AddListener(new UnityEngine.Events.UnityAction<BaseEventData>(callback));
        _eventTrigger.triggers.Add(entry);
    }

    private Entry CreateEntry(EventTriggerType eventType)
    {
        Entry entry = new Entry();
        entry.eventID = eventType;
        entry.callback = new TriggerEvent();
        return entry;
    }

    public void Dispose()
    {
        foreach (Entry entry in _eventTrigger.triggers)
            entry.callback.RemoveAllListeners();
    }
}
