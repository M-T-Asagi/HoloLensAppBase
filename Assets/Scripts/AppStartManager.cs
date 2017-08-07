using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Sharing;

public class AppStartManager : MonoBehaviour {
    GameObject dialog = null;
    int nowDialogNumber = 0;
    bool dialogWorks = true;

    bool sharing = false;

    // Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		switch(nowDialogNumber)
        {
            case 0:
                {
                    if (dialog == null)
                    {
                        dialog = Instantiate(DialogManager.Instance.YesNoDialog, transform);
                        dialog.GetComponent<YesNoDialogManager>().SetWindowText("Sharingしますか？");
                    }

                    YesNoDialogManager manager = dialog.GetComponent<YesNoDialogManager>();
                    if (!manager.IsButtonPushed)
                        break;

                    bool result = manager.Result;
                    if (result)
                    {
                        nowDialogNumber++;
                        BaseStates.Instance.Sharing = true;
                    }
                    else
                    {
                        BaseStates.Instance.Sharing = false;
                        dialogWorks = false;
                    }

                    Destroy(dialog);
                    dialog = null;
                }
                break;

            case 1:
                {
                    if (dialog == null)
                    {
                        dialog = Instantiate(DialogManager.Instance.TextInputDialog, transform);
                        dialog.GetComponent<TextInputDialogManager>().SetWindowText("Sharing IPを入力");
                        dialog.GetComponent<TextInputDialogManager>().SetInputFieldText(BaseStates.Instance.SharingAddress);
                    }

                    TextInputDialogManager manager = dialog.GetComponent<TextInputDialogManager>();
                    if (!manager.IsButtonPushed)
                        break;

                    string inputText = manager.InputText;
                    if (inputText == "" || inputText == null)
                        break;

                    nowDialogNumber++;
                    BaseStates.Instance.SharingAddress = inputText;
                    dialogWorks = false;

                    Destroy(dialog);
                    dialog = null;
                }
                break;
        }

        if(!dialogWorks)
        {
            StartApp();
            Destroy(this);
        }
	}

    void StartApp()
    {
        transform.Find("ConnectorBased").gameObject.SetActive(true);
    }
}
