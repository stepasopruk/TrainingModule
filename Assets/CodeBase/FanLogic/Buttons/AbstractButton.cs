using UnityEngine;

public abstract class AbstractButton : MonoBehaviour
{
    private void OnMouseUp() => 
        OnClick();

    protected abstract void OnClick();
}
