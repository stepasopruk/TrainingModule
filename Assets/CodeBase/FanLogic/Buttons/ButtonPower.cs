using UnityEngine;

public class ButtonPower : AbstractButton
{
    [SerializeField] private FanAnimatorController animatorController;

    protected override void OnClick() => 
        animatorController.IsPower = !animatorController.IsPower;
}
