using System;
using UnityEngine.EventSystems;

public interface IPointerExitTrigger
{
    public event Action OnPointerExit;
    void PointerExit(BaseEventData eventData);
}
