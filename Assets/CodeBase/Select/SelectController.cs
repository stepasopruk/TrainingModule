using System;
using UnityEngine;

public class SelectController
{
    public event Action<GameObject> OnSelected;
    
    private Select _select;

    public SelectController(Select select)
    {
        _select = select;
        _select.OnSelected += Select_OnSelected;
    }

    private void Select_OnSelected(GameObject gameObject) => 
        OnSelected?.Invoke(gameObject);
}