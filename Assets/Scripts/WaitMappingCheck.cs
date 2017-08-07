using UnityEngine;

public class WaitMappingCheck : MonoBehaviour
{

    void OnMappingChecked()
    {
        BaseStates.Instance.MappingState = true;
    }
}
