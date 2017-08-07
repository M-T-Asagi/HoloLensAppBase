using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMappingState : MonoBehaviour
{

    BaseStates baseStates;

    // Use this for initialization
    void Start()
    {
        baseStates = GameObject.Find("HololensBase").GetComponent<BaseStates>();
    }

    // Update is called once per frame
    void Update()
    {
        if (baseStates.MappingState)
        {
            Destroy(this);
        }

        var headPosition = Camera.main.transform.position;
        var gazeDirection = Camera.main.transform.forward;

        RaycastHit hitInfo;
        if (!Physics.Raycast(headPosition, gazeDirection, out hitInfo))
        {
            return;
        }

        // If the raycast hit a hologram, use that as the focused object.
        GameObject focusedObject = hitInfo.collider.gameObject;
        focusedObject.SendMessageUpwards("OnMappingChecked", null, SendMessageOptions.DontRequireReceiver);
    }
}
