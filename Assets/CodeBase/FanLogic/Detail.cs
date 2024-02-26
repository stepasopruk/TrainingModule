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
            Debug.Log($"Selected {gameObject} {value}");
        }
    }
}
