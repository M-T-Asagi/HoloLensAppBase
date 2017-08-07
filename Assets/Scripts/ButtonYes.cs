using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonYes : ButtonBase {
    protected override void OnButtonClick()
    {
        transform.parent.gameObject.SendMessageUpwards("OnClickYes");
    }
}
