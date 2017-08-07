using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonChar : ButtonBase {

    public string character;

    private void OnValidate()
    {
        character = character.Substring(0, 1);
    }

    protected override void OnButtonClick()
    {
        base.OnButtonClick();
        transform.parent.gameObject.SendMessageUpwards("OnClickChar", character);
    }
}
