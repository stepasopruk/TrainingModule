using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectController : MonoBehaviour
{
    private Select _select;
    private Detail _currentDetail;

    public SelectController(Select select)
    {
        _select = select;
        _select.OnSelected += Select_OnSelected;
    }

    private void Select_OnSelected(Detail detail)
    {
        if (detail.IsSelect)
        {
            detail.IsSelect = false;
            return;
        }

        if(_currentDetail != null)
            _currentDetail.IsSelect = false;

        _currentDetail = detail;
        detail.IsSelect = true;
    }
}
