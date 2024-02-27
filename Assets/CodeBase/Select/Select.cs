using System;
using System.Collections.Generic;
using UnityEngine;

public class Select : IDisposable
{
    public event Action<Detail> OnSelected;

    private readonly List<SelectEventTrigger> _triggerListeners;

    public Select(GameObject[] gameObjects)
    {
        _triggerListeners = new List<SelectEventTrigger>();

        foreach (GameObject gameObject in gameObjects)
        {
            var triggerListener = new SelectEventTrigger(gameObject);
            triggerListener.OnPointerClick += Selected;
            _triggerListeners.Add(triggerListener);
        }
    }

    private void Selected(GameObject gameObject) =>
        OnSelected?.Invoke(gameObject.GetComponent<Detail>());

    public void Dispose()
    {
        foreach (SelectEventTrigger triggerListener in _triggerListeners)
            triggerListener.OnPointerClick -= Selected;
    }
}
