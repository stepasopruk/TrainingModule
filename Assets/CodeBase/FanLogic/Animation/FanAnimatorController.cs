using UnityEngine;

public class FanAnimatorController : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private bool _isPower;
    public bool IsPower
    {
        get => _isPower;
        set
        {
            _isPower = value;
            animator.SetBool("PowerOn", value);
            RotationBody();
        }
    }

    private bool _isRotation;
    public bool IsRotation
    {
        get => _isRotation;
        set
        {
            _isRotation = value;
            RotationBody();
        }
    }

    private void RotationBody()
    {
        animator.SetFloat("SpeedRotation", _isRotation && _isPower ? 1 : 0);
    }
}
