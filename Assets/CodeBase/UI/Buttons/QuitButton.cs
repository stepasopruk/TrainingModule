using UnityEngine;

public class QuitButton : AbstractButtonUI
{
    protected override void OnClick() => 
        Application.Quit();
}
