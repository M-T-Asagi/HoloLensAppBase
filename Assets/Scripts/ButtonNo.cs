using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonNo : ButtonBase
{
    protected override void OnButtonClick()
    {
        transform.parent.gameObject.SendMessageUpwards("OnClickNo");
    }
}
