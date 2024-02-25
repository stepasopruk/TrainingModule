using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipBootstrapper : MonoBehaviour
{
    [SerializeField] private TooltipView tooltipView;
    [SerializeField] private TooltipDescription[] tooltipDescriptions;

    private TooltipController _tooltipController;

    private void Awake()
    {
        InitializeTooltip();
    }

    private void InitializeTooltip()
    {
        tooltipView.gameObject.SetActive(false);
        Tooltip tooltip = new Tooltip(tooltipDescriptions);
        TooltipViewController tooltipViewController = new TooltipViewController(tooltipView);
        _tooltipController = new TooltipController(tooltip, tooltipViewController);
    }
}