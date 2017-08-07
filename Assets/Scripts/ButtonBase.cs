using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBase : MonoBehaviour {

    public Material StandardMaterial;
    public Material ClickedMaterial;

    protected void OnSelect()
    {
        OnButtonClick();
    }

    protected virtual void OnButtonClick()
    {

    }
}
