using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogoSetup : MonoBehaviour {
    const float DEFAULT_ALPHA = 0.5f;
    const float DISTANCE = 2.0f;

    public RawImage logoImage;

    BaseStates baseStates;
    Color color;
    GameObject mainCamera;

    bool LOGO_EXISTS = true;

    // Use this for initialization
    void Start () {
        baseStates = GameObject.Find("HololensBase").GetComponent<BaseStates>();
        mainCamera = GameObject.Find("Main Camera");

        LOGO_EXISTS = logoImage != null;

        if(LOGO_EXISTS)
        {
            color = logoImage.color;
            color.a = DEFAULT_ALPHA;
            logoImage.color = color;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if(LOGO_EXISTS)
        {
            if (baseStates.MappingState)
            {
                if (color.a > 0)
                {
                    color.a -= 0.1f;
                    if(logoImage != null)
                        logoImage.color = color;
                }
                else
                {
                    Destroy(gameObject);
                }
            }
        }
        
        Vector3 center = mainCamera.transform.position + mainCamera.transform.TransformDirection(Vector3.forward) * DISTANCE;
        this.transform.position = center;
        this.transform.rotation = mainCamera.transform.rotation;
	}
}
