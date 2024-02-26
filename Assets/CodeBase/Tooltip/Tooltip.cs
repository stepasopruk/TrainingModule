using System;
using System.Collections.Generic;
using UnityEngine;

public class Tooltip : IDisposable
{
    public event Action<TooltipDescription> OnDisplay;
    public event Action OnHide;

    private readonly List<TooltipEventTrigger> _triggerListeners;

    public Tooltip(TooltipDescription[] tooltipDescriptions)
    {
        _triggerListeners = new List<TooltipEventTrigger>();

        foreach (TooltipDescription tooltipDescription in tooltipDescriptions)
        {
            var triggerListener = new TooltipEventTrigger(tooltipDescription.gameObject);
            triggerListener.OnPointerEnter += Display;
            triggerListener.OnPointerExit += Hide;
            _triggerListeners.Add(triggerListener);
        }
    }

    public void Dispose()
    {
        foreach (TooltipEventTrigger triggerListener in _triggerListeners)
        {
            triggerListener.OnPointerEnter -= Display;
            triggerListener.OnPointerExit -= Hide;
        }
    }

    private void Display(GameObject gameObject) =>
        OnDisplay?.Invoke(gameObject.GetComponent<TooltipDescription>());

    private void Hide() =>
        OnHide?.Invoke();
}
