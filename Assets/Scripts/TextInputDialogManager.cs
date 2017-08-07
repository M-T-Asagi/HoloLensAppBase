using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextInputDialogManager : MonoBehaviour {

    const int MAX_WINDOW_TEXT_LENGTH = 11;

    public GameObject WindowText;
    public GameObject InputField;

    private bool isButtonPushed = false;
    public bool IsButtonPushed
    {
        get
        {
            return isButtonPushed;
        }
    }

    private string inputText = "";
    public string InputText {
        get
        {
            return inputText;
        }
    }
    public void SetWindowText(string text)
    {
        if (text.Length > MAX_WINDOW_TEXT_LENGTH)
        {
            text = text.Substring(0, MAX_WINDOW_TEXT_LENGTH - 1);
            text += "…";
        }

        WindowText.GetComponent<TextMesh>().text = text;
    }

    public void SetInputFieldText(string IPAddress)
    {
        InputField.GetComponent<InputField>().text = IPAddress;
    }

    void OnClickOK()
    {
        inputText = InputField.GetComponent<InputField>().text;
        isButtonPushed = true;
    }

    void OnClickDel()
    {
        inputText = InputField.GetComponent<InputField>().text;
        inputText = inputText.Substring(0, inputText.Length - 1);
        InputField.GetComponent<InputField>().text = inputText;
    }

    void OnClickChar(string character)
    {
        inputText = InputField.GetComponent<InputField>().text;
        inputText += character;
        InputField.GetComponent<InputField>().text = inputText;
    }
}
