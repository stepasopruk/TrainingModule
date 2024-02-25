using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TooltipViewController
{
    private readonly TooltipView _tooltipView;

    public TooltipViewController(TooltipView tooltipView) =>
        _tooltipView = tooltipView;

    public void Display(TooltipDescription tooltipDescription)
    {
        _tooltipView.Title.text = tooltipDescription.Title;
        _tooltipView.Description.text = tooltipDescription.Description;

        float offsetX = _tooltipView.RectTransform.rect.width / 2;
        float offsetY = _tooltipView.RectTransform.rect.height;
        Vector2 offset = CalculatingOffset(offsetX, offsetY);
        
        Vector3 newPosition = new Vector3(Input.mousePosition.x + offset.x, Input.mousePosition.y + offset.y);
        _tooltipView.transform.position = newPosition;

        _tooltipView.gameObject.SetActive(true);
    }

    private Vector2 CalculatingOffset(float offsetX, float offsetY)
    {
        Vector2 offset = Vector2.zero;

        float cruX = Input.mousePosition.x + offsetX;
        float curY = Input.mousePosition.y + offsetY;

        if (cruX > Screen.width)
            offset.x = -offsetX;
        else if (Input.mousePosition.x < offsetX)
            offset.x = offsetX;

        offset.y = curY > Screen.height ? -offsetY : offsetY;

        return offset;
    }

    public void Hide() =>
        _tooltipView.gameObject.SetActive(false);
}
