using UnityEngine;
using UnityEngine.UI;

public abstract class AbstractButtonUI : MonoBehaviour
{
    protected Button _button;

    protected void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnClick);
    }

    protected void OnDestroy() => 
        _button.onClick.RemoveListener(OnClick);

    protected abstract void OnClick();    
}