using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detail : MonoBehaviour
{
    private bool _isSelect;
    public bool IsSelect
    {
        get => _isSelect;
        set
        {
            _isSelect = value;
            
            gameObject.layer = value ? 
                LayerMask.NameToLayer("Select") :
                LayerMask.NameToLayer("Default");
        }
    }
}
