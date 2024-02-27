using UnityEngine;

public class DetailSelectController : MonoBehaviour
{
    private Detail _detail;
    private Detail _prevDetail;

    public void Selected(GameObject gameObject)
    {
        if(gameObject.TryGetComponent(out _detail))
                if (_detail == null)
                    return;

        if (_detail.IsSelect)
        {
            _detail.IsSelect = false;
            return;
        }

        if (_prevDetail != null && _prevDetail != _detail)
            _prevDetail.IsSelect = false;

        _detail.IsSelect = true;
        _prevDetail = _detail;
    }
}
