using UnityEngine;

public class DetailSelectController : MonoBehaviour
{
    private Detail _detail;
    private Detail _prevDetail;

    public void Selected(GameObject gameObject)
    {
        _detail ??= gameObject.GetComponent<Detail>();

        if (_detail == null)
            return;


        if (_detail.IsSelect)
        {
            _detail.IsSelect = false;
            return;
        }

        if (_prevDetail != null)
            _prevDetail.IsSelect = false;

        _prevDetail = _detail;
        _prevDetail.IsSelect = true;
    }
}
