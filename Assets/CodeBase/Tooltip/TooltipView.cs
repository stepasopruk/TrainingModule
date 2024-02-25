using UnityEngine;
using UnityEngine.UI;

public class TooltipView : MonoBehaviour
{
    [SerializeField] private Text title;
    [SerializeField] private Text description;
    public Text Title => title;
    public Text Description => description;

    private RectTransform _rectTransform;
    public RectTransform RectTransform => _rectTransform;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

}
