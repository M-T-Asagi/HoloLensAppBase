using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitMappingCheck : MonoBehaviour {

	void OnMappingChecked()
    {
        GameObject.Find("HololensBase").GetComponent<BaseStates>().MappingState = true;
    }
}
