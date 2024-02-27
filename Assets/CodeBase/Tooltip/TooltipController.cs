using System;

public class TooltipController : IDisposable
{
    private Tooltip _tooltip;
    private TooltipViewController _tooltipView;

    public TooltipController(Tooltip tooltip, TooltipViewController tooltipView)
    {
        _tooltip = tooltip;
        _tooltipView = tooltipView;
        _tooltip.OnDisplay += Display;
        _tooltip.OnHide += Hide;
    }

    public void Dispose()
    {
        if (_tooltip == null)
            return;

        _tooltip.OnDisplay -= Display;
        _tooltip.OnHide -= Hide;

        _tooltip.Dispose();
    }

    private void Display(TooltipDescription tooltipDescription) =>
        _tooltipView.Display(tooltipDescription);

    private void Hide() =>
        _tooltipView.Hide();
}
