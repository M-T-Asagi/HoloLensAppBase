using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YesNoDialogManager : MonoBehaviour {

    const int MAX_WINDOW_TEXT_LENGTH = 11;

    public GameObject WindowText;

    private bool isButtonPushed = false;
    public bool IsButtonPushed
    {
        get
        {
            return isButtonPushed;
        }
    }

    private bool result = false;
    public bool Result
    {
        get
        {
            return result;
        }
    }

    public void SetWindowText(string text)
    {
        if(text.Length > MAX_WINDOW_TEXT_LENGTH)
        {
            text = text.Substring(0, MAX_WINDOW_TEXT_LENGTH - 1);
            text += "…";
        }

        WindowText.GetComponent<TextMesh>().text = text;
    }

    void OnClickNo()
    {
        result = false;
        isButtonPushed = true;
    }

    void OnClickYes()
    {
        result = true;
        isButtonPushed = true;
    }
}
