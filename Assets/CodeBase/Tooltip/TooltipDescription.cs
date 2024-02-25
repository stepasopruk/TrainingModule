using UnityEngine;


public class TooltipDescription : MonoBehaviour
{
    [SerializeField] private string title;
    [TextArea(10, 10), SerializeField] private string description;

    public string Title => title;
    public string Description => description;
}
