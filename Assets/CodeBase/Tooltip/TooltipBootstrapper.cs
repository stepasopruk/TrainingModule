using UnityEngine;

public class TooltipBootstrapper : MonoBehaviour
{
    [SerializeField] private TooltipView tooltipView;
    [SerializeField] private TooltipDescription[] tooltipDescriptions;

    private void Awake()
    {
        InitializeTooltip();
    }

    private void InitializeTooltip()
    {
        tooltipView.gameObject.SetActive(false);
        Tooltip tooltip = new Tooltip(tooltipDescriptions);
        TooltipViewController tooltipViewController = new TooltipViewController(tooltipView);
        TooltipController tooltipController = new TooltipController(tooltip, tooltipViewController);
    }
}