using UnityEngine;

public class ButtonRotation : AbstractButton
{
    [SerializeField] private FanAnimatorController animatorController;

    protected override void OnClick() => 
        animatorController.IsRotation = !animatorController.IsRotation;
}
