using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDel : ButtonBase {

    protected override void OnButtonClick()
    {
        base.OnButtonClick();
        transform.parent.gameObject.SendMessageUpwards("OnClickDel");
    }
}
